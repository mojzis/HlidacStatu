﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:cz:isvs:rzp:schemas:VerejnaCast:v1")]
[System.Xml.Serialization.XmlRootAttribute("VerejnyWebDotaz", Namespace="urn:cz:isvs:rzp:schemas:VerejnaCast:v1", IsNullable=false)]
public partial class TVerejnyWebDotaz {
    
    private object[] itemsField;
    
    private ItemsChoiceType[] itemsElementNameField;
    
    private decimal versionField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DruhVypisu", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("Historie", typeof(int))]
    [System.Xml.Serialization.XmlElementAttribute("Kriteria", typeof(TKriteria))]
    [System.Xml.Serialization.XmlElementAttribute("KriteriaOsoba", typeof(TKriteriaOsoba))]
    [System.Xml.Serialization.XmlElementAttribute("OsobaID", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("OsobaRole", typeof(SeznamRoliOsoby))]
    [System.Xml.Serialization.XmlElementAttribute("PlatnostZaznamu", typeof(int))]
    [System.Xml.Serialization.XmlElementAttribute("PodnikatelID", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("StatutarniOrganPravnickeOsobyID", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName {
        get {
            return this.itemsElementNameField;
        }
        set {
            this.itemsElementNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal version {
        get {
            return this.versionField;
        }
        set {
            this.versionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:cz:isvs:rzp:schemas:VerejnaCast:v1")]
public partial class TKriteria {
    
    private object[] itemsField;
    
    private SeznamRoliSubjektu subjektRoleField;
    
    private bool subjektRoleFieldSpecified;
    
    private int platnostZaznamuField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Adresa", typeof(TAdresa))]
    [System.Xml.Serialization.XmlElementAttribute("CastecneDohledani", typeof(int))]
    [System.Xml.Serialization.XmlElementAttribute("IdentifikacniCislo", typeof(uint))]
    [System.Xml.Serialization.XmlElementAttribute("ObchodniJmeno", typeof(string))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    public SeznamRoliSubjektu SubjektRole {
        get {
            return this.subjektRoleField;
        }
        set {
            this.subjektRoleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SubjektRoleSpecified {
        get {
            return this.subjektRoleFieldSpecified;
        }
        set {
            this.subjektRoleFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int PlatnostZaznamu {
        get {
            return this.platnostZaznamuField;
        }
        set {
            this.platnostZaznamuField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:cz:isvs:rzp:schemas:VerejnaCast:v1")]
public partial class TAdresa {
    
    private ushort kodOkresuField;
    
    private bool kodOkresuFieldSpecified;
    
    private string obecField;
    
    private int vyberKonkretniObceField;
    
    private bool vyberKonkretniObceFieldSpecified;
    
    private string nazevCastiObceField;
    
    private string nazevUliceField;
    
    private ushort cisloOrientacniField;
    
    private bool cisloOrientacniFieldSpecified;
    
    private string znakCislaOrientacnihoField;
    
    private ushort cisloDomovniField;
    
    private bool cisloDomovniFieldSpecified;
    
    /// <remarks/>
    public ushort KodOkresu {
        get {
            return this.kodOkresuField;
        }
        set {
            this.kodOkresuField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool KodOkresuSpecified {
        get {
            return this.kodOkresuFieldSpecified;
        }
        set {
            this.kodOkresuFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string Obec {
        get {
            return this.obecField;
        }
        set {
            this.obecField = value;
        }
    }
    
    /// <remarks/>
    public int VyberKonkretniObce {
        get {
            return this.vyberKonkretniObceField;
        }
        set {
            this.vyberKonkretniObceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool VyberKonkretniObceSpecified {
        get {
            return this.vyberKonkretniObceFieldSpecified;
        }
        set {
            this.vyberKonkretniObceFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string NazevCastiObce {
        get {
            return this.nazevCastiObceField;
        }
        set {
            this.nazevCastiObceField = value;
        }
    }
    
    /// <remarks/>
    public string NazevUlice {
        get {
            return this.nazevUliceField;
        }
        set {
            this.nazevUliceField = value;
        }
    }
    
    /// <remarks/>
    public ushort CisloOrientacni {
        get {
            return this.cisloOrientacniField;
        }
        set {
            this.cisloOrientacniField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CisloOrientacniSpecified {
        get {
            return this.cisloOrientacniFieldSpecified;
        }
        set {
            this.cisloOrientacniFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string ZnakCislaOrientacniho {
        get {
            return this.znakCislaOrientacnihoField;
        }
        set {
            this.znakCislaOrientacnihoField = value;
        }
    }
    
    /// <remarks/>
    public ushort CisloDomovni {
        get {
            return this.cisloDomovniField;
        }
        set {
            this.cisloDomovniField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CisloDomovniSpecified {
        get {
            return this.cisloDomovniFieldSpecified;
        }
        set {
            this.cisloDomovniFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:cz:isvs:rzp:schemas:VerejnaCast:v1")]
public partial class TKriteriaOsoba {
    
    private string osobaJmenoField;
    
    private string osobaPrijmeniField;
    
    private string osobaDatumNarozeniField;
    
    private SeznamRoliOsoby osobaRoleField;
    
    private bool osobaRoleFieldSpecified;
    
    private int platnostZaznamuField;
    
    /// <remarks/>
    public string OsobaJmeno {
        get {
            return this.osobaJmenoField;
        }
        set {
            this.osobaJmenoField = value;
        }
    }
    
    /// <remarks/>
    public string OsobaPrijmeni {
        get {
            return this.osobaPrijmeniField;
        }
        set {
            this.osobaPrijmeniField = value;
        }
    }
    
    /// <remarks/>
    public string OsobaDatumNarozeni {
        get {
            return this.osobaDatumNarozeniField;
        }
        set {
            this.osobaDatumNarozeniField = value;
        }
    }
    
    /// <remarks/>
    public SeznamRoliOsoby OsobaRole {
        get {
            return this.osobaRoleField;
        }
        set {
            this.osobaRoleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OsobaRoleSpecified {
        get {
            return this.osobaRoleFieldSpecified;
        }
        set {
            this.osobaRoleFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int PlatnostZaznamu {
        get {
            return this.platnostZaznamuField;
        }
        set {
            this.platnostZaznamuField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:cz:isvs:rzp:schemas:VerejnaCast:v1")]
public enum SeznamRoliOsoby {
    
    /// <remarks/>
    O,
    
    /// <remarks/>
    P,
    
    /// <remarks/>
    S,
    
    /// <remarks/>
    Z,
    
    /// <remarks/>
    D,
    
    /// <remarks/>
    ZS,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:cz:isvs:rzp:schemas:VerejnaCast:v1")]
public enum SeznamRoliSubjektu {
    
    /// <remarks/>
    P,
    
    /// <remarks/>
    S,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:cz:isvs:rzp:schemas:VerejnaCast:v1", IncludeInSchema=false)]
public enum ItemsChoiceType {
    
    /// <remarks/>
    DruhVypisu,
    
    /// <remarks/>
    Historie,
    
    /// <remarks/>
    Kriteria,
    
    /// <remarks/>
    KriteriaOsoba,
    
    /// <remarks/>
    OsobaID,
    
    /// <remarks/>
    OsobaRole,
    
    /// <remarks/>
    PlatnostZaznamu,
    
    /// <remarks/>
    PodnikatelID,
    
    /// <remarks/>
    StatutarniOrganPravnickeOsobyID,
}
