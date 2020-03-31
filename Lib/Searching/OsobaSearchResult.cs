﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HlidacStatu.Lib.Searching
{
	public class OsobaSearchResult : SearchDataResult<Data.Osoba>
	{
        public OsobaSearchResult()
            : base(getVZOrderList)
                {
                }

        public IEnumerable<Data.Osoba> Results { get; set; }


        public object ToRouteValues(int page)
		{
			return new
			{
				Q = string.IsNullOrEmpty(Q) ? OrigQuery : Q,
				Page = page,
			};
		}

       
        protected static Func<List<System.Web.Mvc.SelectListItem>> getVZOrderList = () =>
        {
            return
                new System.Web.Mvc.SelectListItem[] { new System.Web.Mvc.SelectListItem() { Value = "", Text = "---" } }
                .Union(
                    Devmasters.Core.Enums.EnumToEnumerable(typeof(Lib.Data.Osoba.Search.OrderResult))
                    .Select(
                        m => new System.Web.Mvc.SelectListItem() { Value = m.Value, Text = "Řadit " + m.Key }
                    )
                )
                .ToList();
        };



    }
}