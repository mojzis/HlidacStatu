﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HlidacStatu.Lib.Data;
using static HlidacStatu.Lib.Data.WatchDog;

namespace HlidacStatu.Lib.Watchdogs
{
    public partial class SingleEmailPerUserProcessor
    {

        public static void Send(IEnumerable<WatchDog> watchdogs,
            bool force = false, string[] specificContacts = null,
            DateTime? fromSpecificDate = null, DateTime? toSpecificDate = null,
            string openingText = null,
            int maxDegreeOfParallelism = 20,
            Action<string> logOutputFunc = null,
            Action<Devmasters.Core.Batch.ActionProgressData> progressOutputFunc = null
            )
        {
            bool saveWatchdogStatus =
                force == false
                && fromSpecificDate.HasValue == false
                && toSpecificDate.HasValue == false;

            Dictionary<string, WatchDog[]> groupedByUserNoSpecContact = watchdogs
                .Where(w => w != null)
                .Where(m => string.IsNullOrEmpty(m.SpecificContact))
                .GroupBy(k => k.UnconfirmedUser().Id,
                        v => v,
                        (k, v) => new { key = k, val = v.ToArray() }
                        )
                .ToDictionary(k => k.key, v => v.val);

            Devmasters.Core.Batch.Manager.DoActionForAll<KeyValuePair<string, WatchDog[]>>(groupedByUserNoSpecContact,
                (kv) =>
                {
                    WatchDog[] wds = kv.Value;

                    AspNetUser user = null;
                    using (Lib.Data.DbEntities db = new DbEntities())
                    {
                        user = db.AspNetUsers
                        .Where(m => m.Id == kv.Key)
                        .FirstOrDefault();
                    }
                    if (user == null)
                    {
                        foreach (var wdtmp in wds)
                        {
                            if (wdtmp != null && wdtmp.StatusId != 0)
                            {
                                wdtmp.StatusId = 0;
                                wdtmp.Save();
                            }
                        }
                        return new Devmasters.Core.Batch.ActionOutputData();
                    }
                    if (user.EmailConfirmed == false)
                    {
                        bool repeated = false;
                        foreach (var wdtmp in wds)
                        {
                            if (wdtmp != null && wdtmp.StatusId > 0)
                            {
                                wdtmp.DisableWDBySystem(DisabledBySystemReasons.NoConfirmedEmail, repeated);
                                repeated = true;
                            }
                        }
                        return new Devmasters.Core.Batch.ActionOutputData();
                    } //user.EmailConfirmed == false
                    string emailContact = user.Email;

                    //process wds

                    List<RenderedContent> parts = new List<RenderedContent>();
                    foreach (var wd1 in wds)
                    {
                        if ((force || Tools.ReadyToRun(wd1.Period, wd1.LastSearched, DateTime.Now)) == false)
                            continue;


                        //specific Watchdog
                        List<IWatchdogProcessor> wdProcessorsForWD1 = wd1.GetWatchDogProcessors();

                        DateTime? fromDate = fromSpecificDate;
                        DateTime? toDate = toSpecificDate;
                        if (fromDate.HasValue == false && wd1.LatestRec.HasValue)
                            fromDate = new DateTime(wd1.LatestRec.Value.Ticks, DateTimeKind.Utc);
                        if (fromDate.HasValue == false) //because of first search (=> no .LastSearched)
                            fromDate = DateTime.Now.Date.AddMonths(-1); //from previous month


                        if (toDate.HasValue == false)
                            toDate = Tools.RoundWatchdogTime(wd1.Period, DateTime.Now);

                        List<RenderedContent> wdParts = new List<RenderedContent>();
                        foreach (var wdp in wdProcessorsForWD1)
                        {
                            try
                            {

                                var results = wdp.GetResults(fromDate, toDate, 30);
                                if (results.Total > 0)
                                {
                                    RenderedContent rres = wdp.RenderResults(results, 5);
                                    wdParts.Add(Template.DataContent(results.Total, rres));
                                    wdParts.Add(Template.Margin(50));

                                }
                            }
                            catch (Exception ex)
                            {
                                Util.Consts.Logger.Error("SingleEmailPerUserProcessor GetResults/RenderResults error", ex);
                            }
                        }
                        if (wdParts.Count() > 0)
                        {
                            //add watchdog header
                            parts.Add(Template.TopHeader(wd1.Name, Util.RenderData.GetIntervalString(fromDate.Value, toDate.Value)));
                            parts.AddRange(wdParts);


                        }

                        if (saveWatchdogStatus)
                        {
                            wd1.LastSearched = toDate.Value;
                            wd1.Save();
                        }
                    } //foreach wds

                    if (parts.Count > 0)
                    {
                        //send it

                        if (!string.IsNullOrEmpty(openingText))
                            parts.Insert(0, Template.Paragraph(openingText));

                        parts.Insert(0, Template.Paragraph(
                        "<b style='color:red'>NOVINKA!</b> "
                        + "Pokud máte na Hlídači státu nastaveno více hlídačů nových informací, nebudeme Vám je už posílat v jednotlivých mailech. "
                        + "Místo toho obdržíte jeden souhrnný, ve kterém najdete vše najednou!  "
                        + "Napište nám, jak se Vám to líbí, co bychom mohli změnit a vylepšit (stačí odpovědět na tento mail)."
                        ,
                        "NOVINKA! "
                        + "Pokud máte na Hlídači státu nastaveno více hlídačů nových informací, nebudeme Vám je už posílat v jednotlivých mailech. "
                        + "Místo toho obdržíte jeden souhrnný, ve kterém najdete vše najednou!  "
                        + "Napište nám, jak se Vám to líbí, co bychom mohli změnit a vylepšit (stačí odpovědět na tento mail)."
                        ));
                        parts.Insert(0, Template.Margin());

                        var content = RenderedContent.Merge(parts);

                        content.ContentHtml = Template.EmailBodyTemplateHtml
                            .Replace("#BODY#", content.ContentHtml)
                            .Replace("#FOOTERMSG#", Template.DefaultEmailFooterHtml)
                            ;
                        content.ContentText = null;
                        //Template.EmailBodyTemplateText
                        //.Replace("#BODY#", content.ContentText)
                        //.Replace("#FOOTERMSG#", Template.DefaultEmailFooterText);

                        bool sent = false;
                        if (specificContacts != null && specificContacts.Length > 0)
                        {
                            foreach (var email in specificContacts)
                            {
                                Email.SendEmail(email, $"({DateTime.Now.ToShortDateString()}) Nové informace nalezené na Hlídači státu", content);
                            }
                        }
                        else
                        {
                            sent = Email.SendEmail(emailContact, $"({DateTime.Now.ToShortDateString()}) Nové informace nalezené na Hlídači státu", content);
                        }
                        if (sent)
                        {
                            if (saveWatchdogStatus)
                            {
                                DateTime dt = DateTime.Now;
                                foreach (var wd in wds)
                                {
                                    wd.LastSent = dt;
                                    wd.Save();
                                }
                            }
                        }
                    }



                    return new Devmasters.Core.Batch.ActionOutputData();
                },
                logOutputFunc, progressOutputFunc,
                true, maxDegreeOfParallelism: maxDegreeOfParallelism
                );

        }
    }
}
