﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", ConfigurationName="HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH")]
    public interface rozhraniCRPDPH {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://adis.mfcr.cz/rozhraniCRPDPH/getStatusNespolehlivyPlatce", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceResponse getStatusNespolehlivyPlatce(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://adis.mfcr.cz/rozhraniCRPDPH/getStatusNespolehlivyPlatce", ReplyAction="*")]
        System.Threading.Tasks.Task<HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceResponse> getStatusNespolehlivyPlatceAsync(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://adis.mfcr.cz/rozhraniCRPDPH/getSeznamNespolehlivyPlatce", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceResponse getSeznamNespolehlivyPlatce(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://adis.mfcr.cz/rozhraniCRPDPH/getSeznamNespolehlivyPlatce", ReplyAction="*")]
        System.Threading.Tasks.Task<HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceResponse> getSeznamNespolehlivyPlatceAsync(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://adis.mfcr.cz/rozhraniCRPDPH/getStatusNespolehlivyPlatceRozsireny", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRozsirenyResponse getStatusNespolehlivyPlatceRozsireny(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest1 request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://adis.mfcr.cz/rozhraniCRPDPH/getStatusNespolehlivyPlatceRozsireny", ReplyAction="*")]
        System.Threading.Tasks.Task<HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRozsirenyResponse> getStatusNespolehlivyPlatceRozsirenyAsync(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest1 request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public partial class StatusType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime odpovedGenerovanaField;
        
        private int statusCodeField;
        
        private string statusTextField;
        
        private BezVypisuUctuType bezVypisuUctuField;
        
        private bool bezVypisuUctuFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
        public System.DateTime odpovedGenerovana {
            get {
                return this.odpovedGenerovanaField;
            }
            set {
                this.odpovedGenerovanaField = value;
                this.RaisePropertyChanged("odpovedGenerovana");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int statusCode {
            get {
                return this.statusCodeField;
            }
            set {
                this.statusCodeField = value;
                this.RaisePropertyChanged("statusCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string statusText {
            get {
                return this.statusTextField;
            }
            set {
                this.statusTextField = value;
                this.RaisePropertyChanged("statusText");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public BezVypisuUctuType bezVypisuUctu {
            get {
                return this.bezVypisuUctuField;
            }
            set {
                this.bezVypisuUctuField = value;
                this.RaisePropertyChanged("bezVypisuUctu");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool bezVypisuUctuSpecified {
            get {
                return this.bezVypisuUctuFieldSpecified;
            }
            set {
                this.bezVypisuUctuFieldSpecified = value;
                this.RaisePropertyChanged("bezVypisuUctuSpecified");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public enum BezVypisuUctuType {
        
        /// <remarks/>
        ANO,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public partial class Adresa : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string uliceCisloField;
        
        private string castObceField;
        
        private string mestoField;
        
        private string pscField;
        
        private string statField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string uliceCislo {
            get {
                return this.uliceCisloField;
            }
            set {
                this.uliceCisloField = value;
                this.RaisePropertyChanged("uliceCislo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string castObce {
            get {
                return this.castObceField;
            }
            set {
                this.castObceField = value;
                this.RaisePropertyChanged("castObce");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string mesto {
            get {
                return this.mestoField;
            }
            set {
                this.mestoField = value;
                this.RaisePropertyChanged("mesto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string psc {
            get {
                return this.pscField;
            }
            set {
                this.pscField = value;
                this.RaisePropertyChanged("psc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string stat {
            get {
                return this.statField;
            }
            set {
                this.statField = value;
                this.RaisePropertyChanged("stat");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public partial class NestandardniUcetType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string cisloField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string cislo {
            get {
                return this.cisloField;
            }
            set {
                this.cisloField = value;
                this.RaisePropertyChanged("cislo");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public partial class StandardniUcetType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string predcisliField;
        
        private string cisloField;
        
        private string kodBankyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string predcisli {
            get {
                return this.predcisliField;
            }
            set {
                this.predcisliField = value;
                this.RaisePropertyChanged("predcisli");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string cislo {
            get {
                return this.cisloField;
            }
            set {
                this.cisloField = value;
                this.RaisePropertyChanged("cislo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string kodBanky {
            get {
                return this.kodBankyField;
            }
            set {
                this.kodBankyField = value;
                this.RaisePropertyChanged("kodBanky");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public partial class ZverejnenyUcetType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object itemField;
        
        private System.DateTime datumZverejneniField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("nestandardniUcet", typeof(NestandardniUcetType), Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("standardniUcet", typeof(StandardniUcetType), Order=0)]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
        public System.DateTime datumZverejneni {
            get {
                return this.datumZverejneniField;
            }
            set {
                this.datumZverejneniField = value;
                this.RaisePropertyChanged("datumZverejneni");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InformaceOPlatciRozsireneType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public partial class InformaceOPlatciType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private ZverejnenyUcetType[] zverejneneUctyField;
        
        private string dicField;
        
        private NespolehlivyPlatceType nespolehlivyPlatceField;
        
        private System.DateTime datumZverejneniNespolehlivostiField;
        
        private bool datumZverejneniNespolehlivostiFieldSpecified;
        
        private string cisloFuField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ucet", IsNullable=false)]
        public ZverejnenyUcetType[] zverejneneUcty {
            get {
                return this.zverejneneUctyField;
            }
            set {
                this.zverejneneUctyField = value;
                this.RaisePropertyChanged("zverejneneUcty");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dic {
            get {
                return this.dicField;
            }
            set {
                this.dicField = value;
                this.RaisePropertyChanged("dic");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public NespolehlivyPlatceType nespolehlivyPlatce {
            get {
                return this.nespolehlivyPlatceField;
            }
            set {
                this.nespolehlivyPlatceField = value;
                this.RaisePropertyChanged("nespolehlivyPlatce");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
        public System.DateTime datumZverejneniNespolehlivosti {
            get {
                return this.datumZverejneniNespolehlivostiField;
            }
            set {
                this.datumZverejneniNespolehlivostiField = value;
                this.RaisePropertyChanged("datumZverejneniNespolehlivosti");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool datumZverejneniNespolehlivostiSpecified {
            get {
                return this.datumZverejneniNespolehlivostiFieldSpecified;
            }
            set {
                this.datumZverejneniNespolehlivostiFieldSpecified = value;
                this.RaisePropertyChanged("datumZverejneniNespolehlivostiSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string cisloFu {
            get {
                return this.cisloFuField;
            }
            set {
                this.cisloFuField = value;
                this.RaisePropertyChanged("cisloFu");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public enum NespolehlivyPlatceType {
        
        /// <remarks/>
        NE,
        
        /// <remarks/>
        ANO,
        
        /// <remarks/>
        NENALEZEN,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/")]
    public partial class InformaceOPlatciRozsireneType : InformaceOPlatciType {
        
        private string nazevSubjektuField;
        
        private Adresa adresaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string nazevSubjektu {
            get {
                return this.nazevSubjektuField;
            }
            set {
                this.nazevSubjektuField = value;
                this.RaisePropertyChanged("nazevSubjektu");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Adresa adresa {
            get {
                return this.adresaField;
            }
            set {
                this.adresaField = value;
                this.RaisePropertyChanged("adresa");
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="StatusNespolehlivyPlatceRequest", WrapperNamespace="http://adis.mfcr.cz/rozhraniCRPDPH/", IsWrapped=true)]
    public partial class getStatusNespolehlivyPlatceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("dic")]
        public string[] dic;
        
        public getStatusNespolehlivyPlatceRequest() {
        }
        
        public getStatusNespolehlivyPlatceRequest(string[] dic) {
            this.dic = dic;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="StatusNespolehlivyPlatceResponse", WrapperNamespace="http://adis.mfcr.cz/rozhraniCRPDPH/", IsWrapped=true)]
    public partial class getStatusNespolehlivyPlatceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", Order=0)]
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("statusPlatceDPH")]
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciType[] statusPlatceDPH;
        
        public getStatusNespolehlivyPlatceResponse() {
        }
        
        public getStatusNespolehlivyPlatceResponse(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType status, HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciType[] statusPlatceDPH) {
            this.status = status;
            this.statusPlatceDPH = statusPlatceDPH;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SeznamNespolehlivyPlatceRequest", WrapperNamespace="http://adis.mfcr.cz/rozhraniCRPDPH/", IsWrapped=true)]
    public partial class getSeznamNespolehlivyPlatceRequest {
        
        public getSeznamNespolehlivyPlatceRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SeznamNespolehlivyPlatceResponse", WrapperNamespace="http://adis.mfcr.cz/rozhraniCRPDPH/", IsWrapped=true)]
    public partial class getSeznamNespolehlivyPlatceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", Order=0)]
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("statusPlatceDPH")]
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciType[] statusPlatceDPH;
        
        public getSeznamNespolehlivyPlatceResponse() {
        }
        
        public getSeznamNespolehlivyPlatceResponse(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType status, HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciType[] statusPlatceDPH) {
            this.status = status;
            this.statusPlatceDPH = statusPlatceDPH;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="StatusNespolehlivyPlatceRozsirenyRequest", WrapperNamespace="http://adis.mfcr.cz/rozhraniCRPDPH/", IsWrapped=true)]
    public partial class getStatusNespolehlivyPlatceRequest1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("dic")]
        public string[] dic;
        
        public getStatusNespolehlivyPlatceRequest1() {
        }
        
        public getStatusNespolehlivyPlatceRequest1(string[] dic) {
            this.dic = dic;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="StatusNespolehlivyPlatceRozsirenyResponse", WrapperNamespace="http://adis.mfcr.cz/rozhraniCRPDPH/", IsWrapped=true)]
    public partial class getStatusNespolehlivyPlatceRozsirenyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", Order=0)]
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://adis.mfcr.cz/rozhraniCRPDPH/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("statusPlatceDPH")]
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciRozsireneType[] statusPlatceDPH;
        
        public getStatusNespolehlivyPlatceRozsirenyResponse() {
        }
        
        public getStatusNespolehlivyPlatceRozsirenyResponse(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType status, HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciRozsireneType[] statusPlatceDPH) {
            this.status = status;
            this.statusPlatceDPH = statusPlatceDPH;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface rozhraniCRPDPHChannel : HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class rozhraniCRPDPHClient : System.ServiceModel.ClientBase<HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH>, HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH {
        
        public rozhraniCRPDPHClient() {
        }
        
        public rozhraniCRPDPHClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public rozhraniCRPDPHClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public rozhraniCRPDPHClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public rozhraniCRPDPHClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceResponse HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH.getStatusNespolehlivyPlatce(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest request) {
            return base.Channel.getStatusNespolehlivyPlatce(request);
        }
        
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType getStatusNespolehlivyPlatce(string[] dic, out HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciType[] statusPlatceDPH) {
            HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest inValue = new HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest();
            inValue.dic = dic;
            HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceResponse retVal = ((HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH)(this)).getStatusNespolehlivyPlatce(inValue);
            statusPlatceDPH = retVal.statusPlatceDPH;
            return retVal.status;
        }
        
        public System.Threading.Tasks.Task<HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceResponse> getStatusNespolehlivyPlatceAsync(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest request) {
            return base.Channel.getStatusNespolehlivyPlatceAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceResponse HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH.getSeznamNespolehlivyPlatce(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceRequest request) {
            return base.Channel.getSeznamNespolehlivyPlatce(request);
        }
        
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType getSeznamNespolehlivyPlatce(out HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciType[] statusPlatceDPH) {
            HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceRequest inValue = new HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceRequest();
            HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceResponse retVal = ((HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH)(this)).getSeznamNespolehlivyPlatce(inValue);
            statusPlatceDPH = retVal.statusPlatceDPH;
            return retVal.status;
        }
        
        public System.Threading.Tasks.Task<HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceResponse> getSeznamNespolehlivyPlatceAsync(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getSeznamNespolehlivyPlatceRequest request) {
            return base.Channel.getSeznamNespolehlivyPlatceAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRozsirenyResponse HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH.getStatusNespolehlivyPlatceRozsireny(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest1 request) {
            return base.Channel.getStatusNespolehlivyPlatceRozsireny(request);
        }
        
        public HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.StatusType getStatusNespolehlivyPlatceRozsireny(string[] dic, out HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.InformaceOPlatciRozsireneType[] statusPlatceDPH) {
            HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest1 inValue = new HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest1();
            inValue.dic = dic;
            HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRozsirenyResponse retVal = ((HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.rozhraniCRPDPH)(this)).getStatusNespolehlivyPlatceRozsireny(inValue);
            statusPlatceDPH = retVal.statusPlatceDPH;
            return retVal.status;
        }
        
        public System.Threading.Tasks.Task<HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRozsirenyResponse> getStatusNespolehlivyPlatceRozsirenyAsync(HlidacStatu.Lib.Data.External.NespolehlivyPlatceDPH.getStatusNespolehlivyPlatceRequest1 request) {
            return base.Channel.getStatusNespolehlivyPlatceRozsirenyAsync(request);
        }
    }
}
