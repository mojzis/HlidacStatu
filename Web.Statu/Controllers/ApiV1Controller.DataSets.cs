﻿using HlidacStatu.Lib.Data.External.DataSets;
using HlidacStatu.Util;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HlidacStatu.Web.Controllers
{
    public partial class ApiV1Controller : Controllers.GenericAuthController
    {


        [System.Web.Mvc.NonAction]
        public ActionResult _templateAction(string query, int? page, int? order)
        {
            page = page ?? 1;
            order = order ?? 0;

            if (!Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("query", query),
                    new Framework.ApiCall.CallParameter("page", page?.ToString()),
                    new Framework.ApiCall.CallParameter("order", order?.ToString())
                })
                .Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Ok = true }, JsonRequestBehavior.AllowGet);
            }
        }


        [System.Web.Mvc.NonAction]
        public ActionResult FindOsobaId(string jmeno, string prijmeni, string narozeni)
        {

            if (!Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("jmeno", jmeno),
                    new Framework.ApiCall.CallParameter("prijmeni", prijmeni),
                    new Framework.ApiCall.CallParameter("narozeni", narozeni)
                })
                .Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
            }
            else
            {
                DateTime? dt = ParseTools.ToDateTime(narozeni, "yyyy-MM-dd");
                if (dt.HasValue == false)
                {
                    var status = ApiResponseStatus.InvalidFormat;
                    status.error.errorDetail = "invalid date format for parameter 'narozeni'. Use yyyy-MM-dd format.";
                    return Json(status, JsonRequestBehavior.AllowGet);
                }

                var found = HlidacStatu.Lib.StaticData.Politici.Get()
                    .Where(o =>
                    string.Equals(o.Jmeno, jmeno, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(o.Prijmeni, prijmeni, StringComparison.OrdinalIgnoreCase)
                    && o.Narozeni == dt.Value)
                    .FirstOrDefault();
                if (found == null) //try without diacritics
                {
                    string jmenoasc = Devmasters.Core.TextUtil.RemoveDiacritics(jmeno);
                    string prijmeniasc = Devmasters.Core.TextUtil.RemoveDiacritics(prijmeni);
                    found = HlidacStatu.Lib.StaticData.Politici.Get()
                    .Where(o =>
                    string.Equals(o.JmenoAscii, jmenoasc, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(o.PrijmeniAscii, prijmeniasc, StringComparison.OrdinalIgnoreCase)
                    && o.Narozeni == dt.Value)
                    .FirstOrDefault();
                }

                if (found == null)
                    return Json(new { }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new
                    {
                        Jmeno = found.Jmeno,
                        Prijmeni = found.Prijmeni,
                        Narozeni = found.Narozeni.Value.ToString("yyyy-MM-dd"),
                        OsobaId = found.NameId
                    }
                            , JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult FindCompanyID(string companyName)
        {
            return CompanyID(companyName);
        }
        [HttpGet]
        public ActionResult CompanyID(string companyName)
        {
            if (!Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("companyName", companyName)
                })
                .Authentificated)
            {
                return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(companyName))
                        return Json(new { }, JsonRequestBehavior.AllowGet);
                    else
                    {
                        //HlidacStatu.Lib.Data.Firma f = HlidacStatu.Lib.Validators.FirmaInText(companyName);
                        var name = HlidacStatu.Lib.Data.Firma.JmenoBezKoncovky(companyName);
                        var found = HlidacStatu.Lib.Data.Firmy.FindAll(name, 1).FirstOrDefault();
                        if (found == null)
                            return Json(new { }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { ICO = found.ICO, Jmeno = found.Jmeno, DatovaSchranka = found.DatovaSchranka }, JsonRequestBehavior.AllowGet);
                    }


                }
                catch (DataSetException dse)
                {
                    return Json(dse.APIResponse, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    HlidacStatu.Util.Consts.Logger.Error("Dataset API", ex);
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [HttpPost, ActionName("Datasets")]
        [ValidateInput(false)]
        public ActionResult Datasets_Create()
        {
            var data = ReadRequestBody(this.Request);
            var apiAuth = Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("data", data)
                });
            if (!apiAuth.Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess);
            }
            else
            {
                try
                {

                    using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
                    {
                        var m = new System.Net.Mail.MailMessage()
                        {
                            From = new System.Net.Mail.MailAddress("info@hlidacstatu.cz"),
                            Subject = "Nova DATASET registrace od " + apiAuth.ApiCall.User,
                            IsBodyHtml = false,
                            Body = data
                        };
                        m.BodyEncoding = System.Text.Encoding.UTF8;
                        m.SubjectEncoding = System.Text.Encoding.UTF8;

                        m.To.Add("michal@michalblaha.cz");
                        try
                        {
                            smtp.Send(m);
                        }
                        catch (Exception)
                        { }
                    }

                    var reg = Newtonsoft.Json.JsonConvert.DeserializeObject<Registration>(data, DataSet.DefaultDeserializationSettings);
                    reg.created = DateTime.Now;
                    reg.createdBy = apiAuth.ApiCall.User;
                    reg.NormalizeShortName();

                    HlidacStatu.Lib.Data.External.DataSets.DataSet.RegisterNew(reg);

                    //HlidacStatu.Web.Framework.TemplateVirtualFileCacheManager.InvalidateTemplateCache(reg.datasetId);

                    return Json(new { datasetId = reg.datasetId });

                }
                catch (Newtonsoft.Json.JsonSerializationException jex)
                {
                    var status = ApiResponseStatus.DatasetItemInvalidFormat;
                    status.error.errorDetail = jex.Message;
                    return Json(status, JsonRequestBehavior.AllowGet);
                }
                catch (DataSetException dse)
                {
                    return Json(dse.APIResponse, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    HlidacStatu.Util.Consts.Logger.Error("Dataset API", ex);
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);

                }


            }
        }


        [HttpPut, ActionName("Datasets")]
        [ValidateInput(false)]
        public ActionResult Datasets_Update(string id)
        {
            var data = ReadRequestBody(this.Request);
            var apiAuth = Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id)
                });
            if (!apiAuth.Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess);
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(id))
                        return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);

                    var oldReg = DataSetDB.Instance.GetRegistration(id);
                    if (oldReg == null)
                        return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);

                    if (string.IsNullOrEmpty(oldReg.createdBy))
                        oldReg.createdBy = apiAuth.ApiCall?.User?.ToLower();

                    if (apiAuth.ApiCall?.User?.ToLower() != oldReg?.createdBy?.ToLower() && apiAuth.ApiCall.User.ToLower() != "michal@michalblaha.cz")
                    {
                        return Json(ApiResponseStatus.DatasetNoPermision, JsonRequestBehavior.AllowGet);
                    }

                    using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
                    {
                        var m = new System.Net.Mail.MailMessage()
                        {
                            From = new System.Net.Mail.MailAddress("info@hlidacstatu.cz"),
                            Subject = "update DATASET registrace od " + apiAuth.ApiCall?.User?.ToLower(),
                            IsBodyHtml = false,
                            Body = data
                        };
                        m.BodyEncoding = System.Text.Encoding.UTF8;
                        m.SubjectEncoding = System.Text.Encoding.UTF8;
                        m.To.Add("michal@michalblaha.cz");
                        try
                        {
                            smtp.Send(m);
                        }
                        catch (Exception)
                        {
                        }
                    }


                    var newReg = Newtonsoft.Json.JsonConvert.DeserializeObject<Registration>(data, DataSet.DefaultDeserializationSettings);
                    //use everything from newReg, instead of jsonSchema, datasetId
                    //update object
                    newReg.jsonSchema = oldReg.jsonSchema;
                    newReg.datasetId = oldReg.datasetId;
                    newReg.created = DateTime.Now;
                    if (apiAuth.ApiCall.User.ToLower() != oldReg?.createdBy?.ToLower()
                        && apiAuth.ApiCall.User.ToLower() != "michal@michalblaha.cz")
                        newReg.createdBy = apiAuth.ApiCall.User;

                    DataSetDB.Instance.AddData(newReg);

                    //HlidacStatu.Web.Framework.TemplateVirtualFileCacheManager.InvalidateTemplateCache(oldReg.datasetId);

                    return Json(ApiResponseStatus.Valid(), JsonRequestBehavior.AllowGet);

                }
                catch (DataSetException dse)
                {
                    return Json(dse.APIResponse, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    HlidacStatu.Util.Consts.Logger.Error("Dataset API", ex);
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);
                }


            }
        }

        [HttpPut, ActionName("DatasetsPart")]
        [ValidateInput(false)]
        public ActionResult DatasetsPart_Update(string id, string atribut)
        {
            if (string.IsNullOrEmpty(atribut))
                return Json(ApiResponseStatus.InvalidFormat, JsonRequestBehavior.AllowGet);

            var data = ReadRequestBody(this.Request);
            var apiAuth = Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id),
                    new Framework.ApiCall.CallParameter("atribut", atribut)
                });
            if (!apiAuth.Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess);
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(id))
                        return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);

                    var oldReg = DataSetDB.Instance.GetRegistration(id);
                    if (oldReg == null)
                        return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);

                    if (string.IsNullOrEmpty(oldReg.createdBy))
                        oldReg.createdBy = apiAuth.ApiCall?.User?.ToLower();

                    if (apiAuth.ApiCall?.User?.ToLower() != oldReg?.createdBy?.ToLower() && apiAuth.ApiCall.User.ToLower() != "michal@michalblaha.cz")
                    {
                        return Json(ApiResponseStatus.DatasetNoPermision, JsonRequestBehavior.AllowGet);
                    }

                    using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
                    {
                        var m = new System.Net.Mail.MailMessage()
                        {
                            From = new System.Net.Mail.MailAddress("info@hlidacstatu.cz"),
                            Subject = "update DATASET registrace od " + apiAuth.ApiCall?.User?.ToLower(),
                            IsBodyHtml = false,
                            Body = data
                        };
                        m.BodyEncoding = System.Text.Encoding.UTF8;
                        m.SubjectEncoding = System.Text.Encoding.UTF8;
                        m.To.Add("michal@michalblaha.cz");
                        try
                        {
                            smtp.Send(m);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    switch (atribut.ToLower())
                    {
                        case "name":
                            oldReg.name = data;
                            break;
                        case "origurl":
                            oldReg.origUrl = data;
                            break;
                        case "sourcecodeurl":
                            oldReg.sourcecodeUrl = data;
                            break;
                        case "description":
                            oldReg.description = data;
                            break;
                        case "betaversion":
                            oldReg.betaversion = data == "true";
                            break;
                        case "allowwriteaccess":
                            oldReg.allowWriteAccess = data == "true";
                            break;
                        case "searchresulttemplate":
                            oldReg.searchResultTemplate = Newtonsoft.Json.JsonConvert.DeserializeObject<Registration.Template>(data);
                            break;
                        case "detailtemplate":
                            oldReg.detailTemplate = Newtonsoft.Json.JsonConvert.DeserializeObject<Registration.Template>(data);
                            break;
                        default:
                            return Json(ApiResponseStatus.InvalidFormat, JsonRequestBehavior.AllowGet);
                    }


                    DataSetDB.Instance.AddData(oldReg);


                    return Json(ApiResponseStatus.Valid(), JsonRequestBehavior.AllowGet);

                }
                catch (DataSetException dse)
                {
                    return Json(dse.APIResponse, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    HlidacStatu.Util.Consts.Logger.Error("Dataset API", ex);
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);
                }


            }
        }


        [HttpPatch, ActionName("Datasets")]
        public ActionResult Datasets_Patch(string id)
        {
            return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
        }
        [HttpOptions, ActionName("Datasets")]
        public ActionResult Datasets_Options(string id)
        {
            return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
        }
        [HttpGet, ActionName("Datasets")]
        public ActionResult Datasets_GET(string id)
        {
            if (!Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id)
                })
                .Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(id))
                        return Content(Newtonsoft.Json.JsonConvert.SerializeObject(DataSetDB.Instance.SearchData("*", 1, 100).Result,
                                Newtonsoft.Json.Formatting.None,
                                new JsonSerializerSettings() { ContractResolver = Serialization.PublicDatasetContractResolver.Instance })
                            , "application/json");
                    else
                        return Content(Newtonsoft.Json.JsonConvert.SerializeObject(DataSetDB.Instance.SearchData("id:" + id, 1, 100).Result), "application/json");

                }
                catch (DataSetException dse)
                {
                    return Json(dse.APIResponse, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    HlidacStatu.Util.Consts.Logger.Error("Dataset API", ex);
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);

                }

            }
        }

        [HttpDelete, ActionName("Datasets")]
        public ActionResult Datasets_Delete(string id)
        {
            var apiAuth = Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id)
                });
            if (!apiAuth.Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(id))
                        return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);

                    id = id.ToLower();
                    var r = DataSetDB.Instance.GetRegistration(id);
                    if (r == null)
                        return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);

                    if (r.createdBy != null && apiAuth.ApiCall.User.ToLower() != r.createdBy?.ToLower())
                    {
                        return Json(ApiResponseStatus.DatasetNoPermision, JsonRequestBehavior.AllowGet);
                    }

                    var res = DataSetDB.Instance.DeleteRegistration(id);
                    return Json(new ApiResponseStatus() { valid = res }, JsonRequestBehavior.AllowGet);

                }
                catch (DataSetException dse)
                {
                    return Json(dse.APIResponse, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    HlidacStatu.Util.Consts.Logger.Error("Dataset API", ex);
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);

                }

            }
        }


        [HttpGet, ActionName("DatasetSearch")]
        [ValidateInput(false)]
        public ActionResult DatasetSearch(string id, string q, int? page, string sort = null, bool desc = false)
        {
            page = page ?? 1;
            if (page < 1)
                page = 1;
            if (page > 200)
                page = 200;

            if (!Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id),
                    new Framework.ApiCall.CallParameter("q", q),
                    new Framework.ApiCall.CallParameter("page", page?.ToString()),
                    new Framework.ApiCall.CallParameter("sort", sort)
                })
                .Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess);
            }
            else
            {
                try
                {
                    var ds = DataSet.CachedDatasets.Get(id?.ToLower());

                    if (false)
                    {
                        var res = ds.SearchDataRaw(q, page.Value, 50, null);

                        System.Text.StringBuilder sb = new System.Text.StringBuilder(512 * (int)res.Total);
                        sb.Append($"{{ \"total\": {res.Total}, \"page\": {page}, \"results\" : [ ");
                        foreach (var item in res.Result)
                        {
                            sb.Append(item.Item2 + ", ");
                        }
                        sb.Remove(sb.Length - 2, 2);
                        sb.Append($"]}}");

                        return Content(sb.ToString(), "application/json");
                    }
                    else
                    {
                        var res = ds.SearchData(q, page.Value, 50, sort + (desc ? " desc" : ""));
                        res.Result = res.Result.Select(m => { m.DbCreatedBy = null; return m; });


                        return Content(
                            Newtonsoft.Json.JsonConvert.SerializeObject(
                            new { total = res.Total, page = res.Page, results = res.Result }
                        )
                        , "application/json");

                    }

                }
                catch (DataSetException)
                {
                    return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [HttpGet, ActionName("DatasetItem")]
        public ActionResult DatasetItem_Get(string id, string dataid)
        {
            if (!Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id),
                    new Framework.ApiCall.CallParameter("dataid", dataid)
                })
                .Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var ds = DataSet.CachedDatasets.Get(id.ToLower());
                    var value = ds.GetDataObj(dataid);
                    //remove from item
                    if (value == null)
                    {
                        return Content("null", "application/json");
                    }
                    else
                    {
                        value.DbCreatedBy = null;
                        return Content(Newtonsoft.Json.JsonConvert.SerializeObject(value) ?? "null", "application/json");
                    }
                }
                catch (DataSetException)
                {
                    return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [HttpGet, ActionName("DatasetItem_Exists")]
        public ActionResult DatasetItem_Exists(string id, string dataid)
        {
            if (!Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id),
                    new Framework.ApiCall.CallParameter("dataid", dataid)
                })
                .Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var ds = DataSet.CachedDatasets.Get(id.ToLower());
                    var value = ds.ItemExists(dataid);
                    //remove from item
                    if (value == null)
                        return Content(Newtonsoft.Json.JsonConvert.SerializeObject(false), "application/json");
                    else
                        return Content(Newtonsoft.Json.JsonConvert.SerializeObject(true) , "application/json");
                }
                catch (DataSetException)
                {
                    return Json(ApiResponseStatus.DatasetNotFound, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);
                }

            }
        }
        [HttpPost, ActionName("DatasetItem")]
        [ValidateInput(false)]
        public ActionResult DatasetItem_Post(string id, string dataid, bool? rewrite = false)
        {
            var apiAuth = Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id),
                    new Framework.ApiCall.CallParameter("dataid", dataid)
                });
            if (!apiAuth.Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess);
            }
            else
            {
                var data = ReadRequestBody(this.Request);
                id = id.ToLower();
                try
                {
                    var ds = DataSet.CachedDatasets.Get(id);
                    var newId = id;
                    if (rewrite == true || ds.ItemExists(dataid) == false)
                    {
                        newId = ds.AddData(data, dataid, apiAuth.ApiCall.User, true);
                    }
                    return Json(new { id = newId }, JsonRequestBehavior.AllowGet);
                }
                catch (DataSetException dse)
                {
                    return Json(dse.APIResponse, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    HlidacStatu.Util.Consts.Logger.Error("Dataset API", ex);
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);

                }


            }
        }


        public ActionResult DatasetSendNotifications(string id)
        {
            var apiAuth = Framework.ApiAuth.IsApiAuth(this,
                parameters: new Framework.ApiCall.CallParameter[] {
                    new Framework.ApiCall.CallParameter("id", id)
                });
            if (!apiAuth.Authentificated)
            {
                //Response.StatusCode = 401;
                return Json(ApiResponseStatus.ApiUnauthorizedAccess);
            }
            else
            {
                try
                {
                    var ds = DataSet.CachedDatasets.Get(id);
                    HlidacStatu.Lib.Data.WatchDog.Send.SendWatchDogs(predicate: wd => wd.dataType == "DataSet." + ds.DatasetId, type: "dataset");

                    return Json(ApiResponseStatus.ApiUnauthorizedAccess);
                }
                catch (DataSetException dse)
                {
                    return Json(dse.APIResponse, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    HlidacStatu.Util.Consts.Logger.Error("Dataset API", ex);
                    return Json(ApiResponseStatus.GeneralExceptionError, JsonRequestBehavior.AllowGet);

                }



            }
        }
    }
}


