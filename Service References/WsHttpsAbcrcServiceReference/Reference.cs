﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Solum.WsHttpsAbcrcServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AbcrcERBill", Namespace="http://schemas.datacontract.org/2004/07/AbcrcContract")]
    [System.SerializableAttribute()]
    public partial class AbcrcERBill : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Solum.WsHttpsAbcrcServiceReference.AbcrcOtherShippingContainer[] AdditionalShippingContainersField;
        
        private Solum.WsHttpsAbcrcServiceReference.AbcrcERBillBag[] BagsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> CarrierCrisIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoadReferenceField;
        
        private int PlantCrisIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProBillNumberField;
        
        private string RBillNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SealNumberField;
        
        private System.DateTime ShippedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TrailerNumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Solum.WsHttpsAbcrcServiceReference.AbcrcOtherShippingContainer[] AdditionalShippingContainers {
            get {
                return this.AdditionalShippingContainersField;
            }
            set {
                if ((object.ReferenceEquals(this.AdditionalShippingContainersField, value) != true)) {
                    this.AdditionalShippingContainersField = value;
                    this.RaisePropertyChanged("AdditionalShippingContainers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public Solum.WsHttpsAbcrcServiceReference.AbcrcERBillBag[] Bags {
            get {
                return this.BagsField;
            }
            set {
                if ((object.ReferenceEquals(this.BagsField, value) != true)) {
                    this.BagsField = value;
                    this.RaisePropertyChanged("Bags");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> CarrierCrisID {
            get {
                return this.CarrierCrisIDField;
            }
            set {
                if ((this.CarrierCrisIDField.Equals(value) != true)) {
                    this.CarrierCrisIDField = value;
                    this.RaisePropertyChanged("CarrierCrisID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoadReference {
            get {
                return this.LoadReferenceField;
            }
            set {
                if ((object.ReferenceEquals(this.LoadReferenceField, value) != true)) {
                    this.LoadReferenceField = value;
                    this.RaisePropertyChanged("LoadReference");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int PlantCrisID {
            get {
                return this.PlantCrisIDField;
            }
            set {
                if ((this.PlantCrisIDField.Equals(value) != true)) {
                    this.PlantCrisIDField = value;
                    this.RaisePropertyChanged("PlantCrisID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProBillNumber {
            get {
                return this.ProBillNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.ProBillNumberField, value) != true)) {
                    this.ProBillNumberField = value;
                    this.RaisePropertyChanged("ProBillNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string RBillNumber {
            get {
                return this.RBillNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.RBillNumberField, value) != true)) {
                    this.RBillNumberField = value;
                    this.RaisePropertyChanged("RBillNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SealNumber {
            get {
                return this.SealNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.SealNumberField, value) != true)) {
                    this.SealNumberField = value;
                    this.RaisePropertyChanged("SealNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime ShippedDate {
            get {
                return this.ShippedDateField;
            }
            set {
                if ((this.ShippedDateField.Equals(value) != true)) {
                    this.ShippedDateField = value;
                    this.RaisePropertyChanged("ShippedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TrailerNumber {
            get {
                return this.TrailerNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.TrailerNumberField, value) != true)) {
                    this.TrailerNumberField = value;
                    this.RaisePropertyChanged("TrailerNumber");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AbcrcOtherShippingContainer", Namespace="http://schemas.datacontract.org/2004/07/AbcrcContract")]
    [System.SerializableAttribute()]
    public partial class AbcrcOtherShippingContainer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ContainersShippedField;
        
        private int ShippingContainerTypeCrisIDField;
        
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
        public int ContainersShipped {
            get {
                return this.ContainersShippedField;
            }
            set {
                if ((this.ContainersShippedField.Equals(value) != true)) {
                    this.ContainersShippedField = value;
                    this.RaisePropertyChanged("ContainersShipped");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ShippingContainerTypeCrisID {
            get {
                return this.ShippingContainerTypeCrisIDField;
            }
            set {
                if ((this.ShippingContainerTypeCrisIDField.Equals(value) != true)) {
                    this.ShippingContainerTypeCrisIDField = value;
                    this.RaisePropertyChanged("ShippingContainerTypeCrisID");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AbcrcERBillBag", Namespace="http://schemas.datacontract.org/2004/07/AbcrcContract")]
    [System.SerializableAttribute()]
    public partial class AbcrcERBillBag : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string BagTagField;
        
        private int ItemTypeCrisIDField;
        
        private int ShippingContainerTypeCrisIDField;
        
        private int UnitsShippedField;
        
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
        public string BagTag {
            get {
                return this.BagTagField;
            }
            set {
                if ((object.ReferenceEquals(this.BagTagField, value) != true)) {
                    this.BagTagField = value;
                    this.RaisePropertyChanged("BagTag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ItemTypeCrisID {
            get {
                return this.ItemTypeCrisIDField;
            }
            set {
                if ((this.ItemTypeCrisIDField.Equals(value) != true)) {
                    this.ItemTypeCrisIDField = value;
                    this.RaisePropertyChanged("ItemTypeCrisID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ShippingContainerTypeCrisID {
            get {
                return this.ShippingContainerTypeCrisIDField;
            }
            set {
                if ((this.ShippingContainerTypeCrisIDField.Equals(value) != true)) {
                    this.ShippingContainerTypeCrisIDField = value;
                    this.RaisePropertyChanged("ShippingContainerTypeCrisID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int UnitsShipped {
            get {
                return this.UnitsShippedField;
            }
            set {
                if ((this.UnitsShippedField.Equals(value) != true)) {
                    this.UnitsShippedField = value;
                    this.RaisePropertyChanged("UnitsShipped");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AbcrcSubmitResponse", Namespace="http://schemas.datacontract.org/2004/07/AbcrcContract")]
    [System.SerializableAttribute()]
    public partial class AbcrcSubmitResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool ErrorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        private bool IsValidField;
        
        private bool SubmitSuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Solum.WsHttpsAbcrcServiceReference.AbcrcValidationMessage[] ValidationMessagesField;
        
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
        public bool Error {
            get {
                return this.ErrorField;
            }
            set {
                if ((this.ErrorField.Equals(value) != true)) {
                    this.ErrorField = value;
                    this.RaisePropertyChanged("Error");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool IsValid {
            get {
                return this.IsValidField;
            }
            set {
                if ((this.IsValidField.Equals(value) != true)) {
                    this.IsValidField = value;
                    this.RaisePropertyChanged("IsValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool SubmitSuccess {
            get {
                return this.SubmitSuccessField;
            }
            set {
                if ((this.SubmitSuccessField.Equals(value) != true)) {
                    this.SubmitSuccessField = value;
                    this.RaisePropertyChanged("SubmitSuccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Solum.WsHttpsAbcrcServiceReference.AbcrcValidationMessage[] ValidationMessages {
            get {
                return this.ValidationMessagesField;
            }
            set {
                if ((object.ReferenceEquals(this.ValidationMessagesField, value) != true)) {
                    this.ValidationMessagesField = value;
                    this.RaisePropertyChanged("ValidationMessages");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AbcrcValidationMessage", Namespace="http://schemas.datacontract.org/2004/07/AbcrcContract")]
    [System.SerializableAttribute()]
    public partial class AbcrcValidationMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ValidationCodeField;
        
        private string ValidationMessageField;
        
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
        public int ValidationCode {
            get {
                return this.ValidationCodeField;
            }
            set {
                if ((this.ValidationCodeField.Equals(value) != true)) {
                    this.ValidationCodeField = value;
                    this.RaisePropertyChanged("ValidationCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ValidationMessage {
            get {
                return this.ValidationMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ValidationMessageField, value) != true)) {
                    this.ValidationMessageField = value;
                    this.RaisePropertyChanged("ValidationMessage");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AbcrcValidationResponse", Namespace="http://schemas.datacontract.org/2004/07/AbcrcContract")]
    [System.SerializableAttribute()]
    public partial class AbcrcValidationResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool ErrorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        private bool IsValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Solum.WsHttpsAbcrcServiceReference.AbcrcValidationMessage[] ValidationMessagesField;
        
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
        public bool Error {
            get {
                return this.ErrorField;
            }
            set {
                if ((this.ErrorField.Equals(value) != true)) {
                    this.ErrorField = value;
                    this.RaisePropertyChanged("Error");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool IsValid {
            get {
                return this.IsValidField;
            }
            set {
                if ((this.IsValidField.Equals(value) != true)) {
                    this.IsValidField = value;
                    this.RaisePropertyChanged("IsValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Solum.WsHttpsAbcrcServiceReference.AbcrcValidationMessage[] ValidationMessages {
            get {
                return this.ValidationMessagesField;
            }
            set {
                if ((object.ReferenceEquals(this.ValidationMessagesField, value) != true)) {
                    this.ValidationMessagesField = value;
                    this.RaisePropertyChanged("ValidationMessages");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WsHttpsAbcrcServiceReference.IWsHttpsAbcrcService")]
    public interface IWsHttpsAbcrcService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHttpsAbcrcService/SubmitErBill", ReplyAction="http://tempuri.org/IWsHttpsAbcrcService/SubmitErBillResponse")]
        Solum.WsHttpsAbcrcServiceReference.AbcrcSubmitResponse SubmitErBill(Solum.WsHttpsAbcrcServiceReference.AbcrcERBill eRBill);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsHttpsAbcrcService/ValidateErBill", ReplyAction="http://tempuri.org/IWsHttpsAbcrcService/ValidateErBillResponse")]
        Solum.WsHttpsAbcrcServiceReference.AbcrcValidationResponse ValidateErBill(Solum.WsHttpsAbcrcServiceReference.AbcrcERBill eRBill);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWsHttpsAbcrcServiceChannel : Solum.WsHttpsAbcrcServiceReference.IWsHttpsAbcrcService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WsHttpsAbcrcServiceClient : System.ServiceModel.ClientBase<Solum.WsHttpsAbcrcServiceReference.IWsHttpsAbcrcService>, Solum.WsHttpsAbcrcServiceReference.IWsHttpsAbcrcService {
        
        public WsHttpsAbcrcServiceClient() {
        }
        
        public WsHttpsAbcrcServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WsHttpsAbcrcServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsHttpsAbcrcServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsHttpsAbcrcServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Solum.WsHttpsAbcrcServiceReference.AbcrcSubmitResponse SubmitErBill(Solum.WsHttpsAbcrcServiceReference.AbcrcERBill eRBill) {
            return base.Channel.SubmitErBill(eRBill);
        }
        
        public Solum.WsHttpsAbcrcServiceReference.AbcrcValidationResponse ValidateErBill(Solum.WsHttpsAbcrcServiceReference.AbcrcERBill eRBill) {
            return base.Channel.ValidateErBill(eRBill);
        }
    }
}
