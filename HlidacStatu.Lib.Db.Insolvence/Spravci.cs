//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HlidacStatu.Lib.Db.Insolvence
{
    using System;
    using System.Collections.Generic;
    
    public partial class Spravci
    {
        public long pk { get; set; }
        public string RizeniId { get; set; }
        public string IdPuvodce { get; set; }
        public string IdOsoby { get; set; }
        public string PlneJmeno { get; set; }
        public string Role { get; set; }
        public string Typ { get; set; }
        public string RC { get; set; }
        public Nullable<System.DateTime> DatumNarozeni { get; set; }
        public string ICO { get; set; }
        public string Mesto { get; set; }
        public string Okres { get; set; }
        public string Zeme { get; set; }
        public string PSC { get; set; }
        public string OsobaId { get; set; }
    }
}
