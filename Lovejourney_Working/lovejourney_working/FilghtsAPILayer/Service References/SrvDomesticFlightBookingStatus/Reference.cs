﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilghtsAPILayer.SrvDomesticFlightBookingStatus {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://bookingstatus.flight.arzoo.com", ConfigurationName="SrvDomesticFlightBookingStatus.DOMFlightBookingStatusPortType")]
    public interface DOMFlightBookingStatusPortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="out")]
        string getBookingStatus(string in0);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DOMFlightBookingStatusPortTypeChannel : FilghtsAPILayer.SrvDomesticFlightBookingStatus.DOMFlightBookingStatusPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DOMFlightBookingStatusPortTypeClient : System.ServiceModel.ClientBase<FilghtsAPILayer.SrvDomesticFlightBookingStatus.DOMFlightBookingStatusPortType>, FilghtsAPILayer.SrvDomesticFlightBookingStatus.DOMFlightBookingStatusPortType {
        
        public DOMFlightBookingStatusPortTypeClient() {
        }
        
        public DOMFlightBookingStatusPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DOMFlightBookingStatusPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DOMFlightBookingStatusPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DOMFlightBookingStatusPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getBookingStatus(string in0) {
            return base.Channel.getBookingStatus(in0);
        }
    }
}
