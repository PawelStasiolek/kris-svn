﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行库版本:2.0.50727.1882
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.CompactFramework.Design.Data 2.0.50727.1882 版自动生成。
// 
namespace RFID_Write.Webservice {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service1() {
            this.Url = "http://172.18.50.164/Rfid/MES_RFID_Interface_Service.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndHelloWorld(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetModuleInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public module_info GetModuleInfo(string moduleSN) {
            object[] results = this.Invoke("GetModuleInfo", new object[] {
                        moduleSN});
            return ((module_info)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetModuleInfo(string moduleSN, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetModuleInfo", new object[] {
                        moduleSN}, callback, asyncState);
        }
        
        /// <remarks/>
        public module_info EndGetModuleInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((module_info)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ResetWritedFlag", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ResetWritedFlag(string moduleSN, string flag) {
            object[] results = this.Invoke("ResetWritedFlag", new object[] {
                        moduleSN,
                        flag});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginResetWritedFlag(string moduleSN, string flag, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ResetWritedFlag", new object[] {
                        moduleSN,
                        flag}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndResetWritedFlag(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class module_info {
        
        private string serial_NoField;
        
        private string module_TypeField;
        
        private string uocField;
        
        private string iscField;
        
        private string umppField;
        
        private string imppField;
        
        private string pmppField;
        
        private string ffField;
        
        private string pallet_NoField;
        
        private string rateDIMField;
        
        private string test_DateField;
        
        private string module_ManufField;
        
        private string cell_ManufField;
        
        private string country_of_OriginField;
        
        private string certificateField;
        
        private string certificate_timeField;
        
        private string flagField;
        
        /// <remarks/>
        public string Serial_No {
            get {
                return this.serial_NoField;
            }
            set {
                this.serial_NoField = value;
            }
        }
        
        /// <remarks/>
        public string Module_Type {
            get {
                return this.module_TypeField;
            }
            set {
                this.module_TypeField = value;
            }
        }
        
        /// <remarks/>
        public string Uoc {
            get {
                return this.uocField;
            }
            set {
                this.uocField = value;
            }
        }
        
        /// <remarks/>
        public string Isc {
            get {
                return this.iscField;
            }
            set {
                this.iscField = value;
            }
        }
        
        /// <remarks/>
        public string Umpp {
            get {
                return this.umppField;
            }
            set {
                this.umppField = value;
            }
        }
        
        /// <remarks/>
        public string Impp {
            get {
                return this.imppField;
            }
            set {
                this.imppField = value;
            }
        }
        
        /// <remarks/>
        public string Pmpp {
            get {
                return this.pmppField;
            }
            set {
                this.pmppField = value;
            }
        }
        
        /// <remarks/>
        public string FF {
            get {
                return this.ffField;
            }
            set {
                this.ffField = value;
            }
        }
        
        /// <remarks/>
        public string Pallet_No {
            get {
                return this.pallet_NoField;
            }
            set {
                this.pallet_NoField = value;
            }
        }
        
        /// <remarks/>
        public string RateDIM {
            get {
                return this.rateDIMField;
            }
            set {
                this.rateDIMField = value;
            }
        }
        
        /// <remarks/>
        public string Test_Date {
            get {
                return this.test_DateField;
            }
            set {
                this.test_DateField = value;
            }
        }
        
        /// <remarks/>
        public string Module_Manuf {
            get {
                return this.module_ManufField;
            }
            set {
                this.module_ManufField = value;
            }
        }
        
        /// <remarks/>
        public string Cell_Manuf {
            get {
                return this.cell_ManufField;
            }
            set {
                this.cell_ManufField = value;
            }
        }
        
        /// <remarks/>
        public string Country_of_Origin {
            get {
                return this.country_of_OriginField;
            }
            set {
                this.country_of_OriginField = value;
            }
        }
        
        /// <remarks/>
        public string Certificate {
            get {
                return this.certificateField;
            }
            set {
                this.certificateField = value;
            }
        }
        
        /// <remarks/>
        public string Certificate_time {
            get {
                return this.certificate_timeField;
            }
            set {
                this.certificate_timeField = value;
            }
        }
        
        /// <remarks/>
        public string flag {
            get {
                return this.flagField;
            }
            set {
                this.flagField = value;
            }
        }
    }
}
