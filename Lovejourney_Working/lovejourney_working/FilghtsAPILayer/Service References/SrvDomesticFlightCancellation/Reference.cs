﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilghtsAPILayer.SrvDomesticFlightCancellation {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://cancelation.flight.arzoo.com", ConfigurationName="SrvDomesticFlightCancellation.DOMFlightCancellationPortType")]
    public interface DOMFlightCancellationPortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="out")]
        string getCancelation(string in0);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DOMFlightCancellationPortTypeChannel : FilghtsAPILayer.SrvDomesticFlightCancellation.DOMFlightCancellationPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DOMFlightCancellationPortTypeClient : System.ServiceModel.ClientBase<FilghtsAPILayer.SrvDomesticFlightCancellation.DOMFlightCancellationPortType>, FilghtsAPILayer.SrvDomesticFlightCancellation.DOMFlightCancellationPortType {
        
        public DOMFlightCancellationPortTypeClient() {
        }
        
        public DOMFlightCancellationPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DOMFlightCancellationPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DOMFlightCancellationPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DOMFlightCancellationPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getCancelation(string in0) {
            return base.Channel.getCancelation(in0);
        }
    }
}
