﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiTokenAuthentication.servicio {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FormsResponseFUN", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class FormsResponseFUN : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int statusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string errorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<WebApiTokenAuthentication.servicio.FormsFUN> msgField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int status {
            get {
                return this.statusField;
            }
            set {
                if ((this.statusField.Equals(value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string error {
            get {
                return this.errorField;
            }
            set {
                if ((object.ReferenceEquals(this.errorField, value) != true)) {
                    this.errorField = value;
                    this.RaisePropertyChanged("error");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public System.Collections.Generic.List<WebApiTokenAuthentication.servicio.FormsFUN> msg {
            get {
                return this.msgField;
            }
            set {
                if ((object.ReferenceEquals(this.msgField, value) != true)) {
                    this.msgField = value;
                    this.RaisePropertyChanged("msg");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FormsFUN", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class FormsFUN : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<WebApiTokenAuthentication.servicio.InputsFUN> inputsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public System.Collections.Generic.List<WebApiTokenAuthentication.servicio.InputsFUN> inputs {
            get {
                return this.inputsField;
            }
            set {
                if ((object.ReferenceEquals(this.inputsField, value) != true)) {
                    this.inputsField = value;
                    this.RaisePropertyChanged("inputs");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InputsFUN", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class InputsFUN : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string typeField;
        
        private bool requiredField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string type {
            get {
                return this.typeField;
            }
            set {
                if ((object.ReferenceEquals(this.typeField, value) != true)) {
                    this.typeField = value;
                    this.RaisePropertyChanged("type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public bool required {
            get {
                return this.requiredField;
            }
            set {
                if ((this.requiredField.Equals(value) != true)) {
                    this.requiredField = value;
                    this.RaisePropertyChanged("required");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="servicio.IForms")]
    public interface IForms {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento ObtenerFormsResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IForms/ObtenerForms", ReplyAction="http://tempuri.org/IForms/ObtenerFormsResponse")]
        WebApiTokenAuthentication.servicio.ObtenerFormsResponse ObtenerForms(WebApiTokenAuthentication.servicio.ObtenerFormsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IForms/ObtenerForms", ReplyAction="http://tempuri.org/IForms/ObtenerFormsResponse")]
        System.Threading.Tasks.Task<WebApiTokenAuthentication.servicio.ObtenerFormsResponse> ObtenerFormsAsync(WebApiTokenAuthentication.servicio.ObtenerFormsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerFormsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerForms", Namespace="http://tempuri.org/", Order=0)]
        public WebApiTokenAuthentication.servicio.ObtenerFormsRequestBody Body;
        
        public ObtenerFormsRequest() {
        }
        
        public ObtenerFormsRequest(WebApiTokenAuthentication.servicio.ObtenerFormsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ObtenerFormsRequestBody {
        
        public ObtenerFormsRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerFormsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerFormsResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApiTokenAuthentication.servicio.ObtenerFormsResponseBody Body;
        
        public ObtenerFormsResponse() {
        }
        
        public ObtenerFormsResponse(WebApiTokenAuthentication.servicio.ObtenerFormsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObtenerFormsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WebApiTokenAuthentication.servicio.FormsResponseFUN ObtenerFormsResult;
        
        public ObtenerFormsResponseBody() {
        }
        
        public ObtenerFormsResponseBody(WebApiTokenAuthentication.servicio.FormsResponseFUN ObtenerFormsResult) {
            this.ObtenerFormsResult = ObtenerFormsResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFormsChannel : WebApiTokenAuthentication.servicio.IForms, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FormsClient : System.ServiceModel.ClientBase<WebApiTokenAuthentication.servicio.IForms>, WebApiTokenAuthentication.servicio.IForms {
        
        public FormsClient() {
        }
        
        public FormsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FormsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FormsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FormsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApiTokenAuthentication.servicio.ObtenerFormsResponse WebApiTokenAuthentication.servicio.IForms.ObtenerForms(WebApiTokenAuthentication.servicio.ObtenerFormsRequest request) {
            return base.Channel.ObtenerForms(request);
        }
        
        public WebApiTokenAuthentication.servicio.FormsResponseFUN ObtenerForms() {
            WebApiTokenAuthentication.servicio.ObtenerFormsRequest inValue = new WebApiTokenAuthentication.servicio.ObtenerFormsRequest();
            inValue.Body = new WebApiTokenAuthentication.servicio.ObtenerFormsRequestBody();
            WebApiTokenAuthentication.servicio.ObtenerFormsResponse retVal = ((WebApiTokenAuthentication.servicio.IForms)(this)).ObtenerForms(inValue);
            return retVal.Body.ObtenerFormsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApiTokenAuthentication.servicio.ObtenerFormsResponse> WebApiTokenAuthentication.servicio.IForms.ObtenerFormsAsync(WebApiTokenAuthentication.servicio.ObtenerFormsRequest request) {
            return base.Channel.ObtenerFormsAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApiTokenAuthentication.servicio.ObtenerFormsResponse> ObtenerFormsAsync() {
            WebApiTokenAuthentication.servicio.ObtenerFormsRequest inValue = new WebApiTokenAuthentication.servicio.ObtenerFormsRequest();
            inValue.Body = new WebApiTokenAuthentication.servicio.ObtenerFormsRequestBody();
            return ((WebApiTokenAuthentication.servicio.IForms)(this)).ObtenerFormsAsync(inValue);
        }
    }
}
