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

namespace MS_Control.WebService {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SmsV1Soap", Namespace="http://www.sms-webservice.ir")]
    public partial class SmsV1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendMessageOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetMessagesStatusOperationCompleted;
        
        private System.Threading.SendOrPostCallback GeCreditOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllMessagesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SmsV1() {
            this.Url = global::MS_Control.Properties.Settings.Default.MS_Control_WebService_SmsV1;
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
        public event SendMessageCompletedEventHandler SendMessageCompleted;
        
        /// <remarks/>
        public event GetMessagesStatusCompletedEventHandler GetMessagesStatusCompleted;
        
        /// <remarks/>
        public event GeCreditCompletedEventHandler GeCreditCompleted;
        
        /// <remarks/>
        public event GetAllMessagesCompletedEventHandler GetAllMessagesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.sms-webservice.ir/SendMessage", RequestNamespace="http://www.sms-webservice.ir", ResponseNamespace="http://www.sms-webservice.ir", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public long[] SendMessage(string Username, string PassWord, string MessageBodie, string[] RecipientNumbers, string SenderNumber, int Type, int AllowedDelay) {
            object[] results = this.Invoke("SendMessage", new object[] {
                        Username,
                        PassWord,
                        MessageBodie,
                        RecipientNumbers,
                        SenderNumber,
                        Type,
                        AllowedDelay});
            return ((long[])(results[0]));
        }
        
        /// <remarks/>
        public void SendMessageAsync(string Username, string PassWord, string MessageBodie, string[] RecipientNumbers, string SenderNumber, int Type, int AllowedDelay) {
            this.SendMessageAsync(Username, PassWord, MessageBodie, RecipientNumbers, SenderNumber, Type, AllowedDelay, null);
        }
        
        /// <remarks/>
        public void SendMessageAsync(string Username, string PassWord, string MessageBodie, string[] RecipientNumbers, string SenderNumber, int Type, int AllowedDelay, object userState) {
            if ((this.SendMessageOperationCompleted == null)) {
                this.SendMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMessageOperationCompleted);
            }
            this.InvokeAsync("SendMessage", new object[] {
                        Username,
                        PassWord,
                        MessageBodie,
                        RecipientNumbers,
                        SenderNumber,
                        Type,
                        AllowedDelay}, this.SendMessageOperationCompleted, userState);
        }
        
        private void OnSendMessageOperationCompleted(object arg) {
            if ((this.SendMessageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMessageCompleted(this, new SendMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.sms-webservice.ir/GetMessagesStatus", RequestNamespace="http://www.sms-webservice.ir", ResponseNamespace="http://www.sms-webservice.ir", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public long[] GetMessagesStatus(string Username, string PassWord, long[] messagesId) {
            object[] results = this.Invoke("GetMessagesStatus", new object[] {
                        Username,
                        PassWord,
                        messagesId});
            return ((long[])(results[0]));
        }
        
        /// <remarks/>
        public void GetMessagesStatusAsync(string Username, string PassWord, long[] messagesId) {
            this.GetMessagesStatusAsync(Username, PassWord, messagesId, null);
        }
        
        /// <remarks/>
        public void GetMessagesStatusAsync(string Username, string PassWord, long[] messagesId, object userState) {
            if ((this.GetMessagesStatusOperationCompleted == null)) {
                this.GetMessagesStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessagesStatusOperationCompleted);
            }
            this.InvokeAsync("GetMessagesStatus", new object[] {
                        Username,
                        PassWord,
                        messagesId}, this.GetMessagesStatusOperationCompleted, userState);
        }
        
        private void OnGetMessagesStatusOperationCompleted(object arg) {
            if ((this.GetMessagesStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessagesStatusCompleted(this, new GetMessagesStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.sms-webservice.ir/GeCredit", RequestNamespace="http://www.sms-webservice.ir", ResponseNamespace="http://www.sms-webservice.ir", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double GeCredit(string Username, string PassWord) {
            object[] results = this.Invoke("GeCredit", new object[] {
                        Username,
                        PassWord});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void GeCreditAsync(string Username, string PassWord) {
            this.GeCreditAsync(Username, PassWord, null);
        }
        
        /// <remarks/>
        public void GeCreditAsync(string Username, string PassWord, object userState) {
            if ((this.GeCreditOperationCompleted == null)) {
                this.GeCreditOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGeCreditOperationCompleted);
            }
            this.InvokeAsync("GeCredit", new object[] {
                        Username,
                        PassWord}, this.GeCreditOperationCompleted, userState);
        }
        
        private void OnGeCreditOperationCompleted(object arg) {
            if ((this.GeCreditCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GeCreditCompleted(this, new GeCreditCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.sms-webservice.ir/GetAllMessages", RequestNamespace="http://www.sms-webservice.ir", ResponseNamespace="http://www.sms-webservice.ir", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] GetAllMessages(string Username, string PassWord, int numberOfMessages, string destNumber, ref int ErrNum) {
            object[] results = this.Invoke("GetAllMessages", new object[] {
                        Username,
                        PassWord,
                        numberOfMessages,
                        destNumber,
                        ErrNum});
            ErrNum = ((int)(results[1]));
            return ((string[][])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllMessagesAsync(string Username, string PassWord, int numberOfMessages, string destNumber, int ErrNum) {
            this.GetAllMessagesAsync(Username, PassWord, numberOfMessages, destNumber, ErrNum, null);
        }
        
        /// <remarks/>
        public void GetAllMessagesAsync(string Username, string PassWord, int numberOfMessages, string destNumber, int ErrNum, object userState) {
            if ((this.GetAllMessagesOperationCompleted == null)) {
                this.GetAllMessagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllMessagesOperationCompleted);
            }
            this.InvokeAsync("GetAllMessages", new object[] {
                        Username,
                        PassWord,
                        numberOfMessages,
                        destNumber,
                        ErrNum}, this.GetAllMessagesOperationCompleted, userState);
        }
        
        private void OnGetAllMessagesOperationCompleted(object arg) {
            if ((this.GetAllMessagesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllMessagesCompleted(this, new GetAllMessagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void SendMessageCompletedEventHandler(object sender, SendMessageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public long[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((long[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetMessagesStatusCompletedEventHandler(object sender, GetMessagesStatusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessagesStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMessagesStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public long[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((long[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GeCreditCompletedEventHandler(object sender, GeCreditCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GeCreditCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GeCreditCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetAllMessagesCompletedEventHandler(object sender, GetAllMessagesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllMessagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllMessagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[][] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[][])(this.results[0]));
            }
        }
        
        /// <remarks/>
        public int ErrNum {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[1]));
            }
        }
    }
}

#pragma warning restore 1591