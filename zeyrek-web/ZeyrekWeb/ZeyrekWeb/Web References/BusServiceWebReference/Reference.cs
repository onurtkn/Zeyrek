﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ZeyrekWeb.BusServiceWebReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GetBusServiceSoap", Namespace="http://tempuri.org/")]
    public partial class GetBusService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getBusServiceListOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GetBusService() {
            this.Url = global::ZeyrekWeb.Properties.Settings.Default.ZeyrekWeb_BusServiceWebReference_GetBusService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event getBusServiceListCompletedEventHandler getBusServiceListCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getBusServiceList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ZBusSrv[] getBusServiceList() {
            object[] results = this.Invoke("getBusServiceList", new object[0]);
            return ((ZBusSrv[])(results[0]));
        }
        
        /// <remarks/>
        public void getBusServiceListAsync() {
            this.getBusServiceListAsync(null);
        }
        
        /// <remarks/>
        public void getBusServiceListAsync(object userState) {
            if ((this.getBusServiceListOperationCompleted == null)) {
                this.getBusServiceListOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetBusServiceListOperationCompleted);
            }
            this.InvokeAsync("getBusServiceList", new object[0], this.getBusServiceListOperationCompleted, userState);
        }
        
        private void OngetBusServiceListOperationCompleted(object arg) {
            if ((this.getBusServiceListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getBusServiceListCompleted(this, new getBusServiceListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ZBusSrv {
        
        private int idField;
        
        private string servisGuzergahiField;
        
        private string plakaField;
        
        private string surucuAdField;
        
        private string surucuTelField;
        
        /// <remarks/>
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string ServisGuzergahi {
            get {
                return this.servisGuzergahiField;
            }
            set {
                this.servisGuzergahiField = value;
            }
        }
        
        /// <remarks/>
        public string Plaka {
            get {
                return this.plakaField;
            }
            set {
                this.plakaField = value;
            }
        }
        
        /// <remarks/>
        public string SurucuAd {
            get {
                return this.surucuAdField;
            }
            set {
                this.surucuAdField = value;
            }
        }
        
        /// <remarks/>
        public string SurucuTel {
            get {
                return this.surucuTelField;
            }
            set {
                this.surucuTelField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void getBusServiceListCompletedEventHandler(object sender, getBusServiceListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getBusServiceListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getBusServiceListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ZBusSrv[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ZBusSrv[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591