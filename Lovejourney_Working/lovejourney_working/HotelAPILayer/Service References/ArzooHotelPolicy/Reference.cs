﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelAPILayer.ArzooHotelPolicy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://policy.hotel.com", ConfigurationName="ArzooHotelPolicy.HotelPolicyPortType")]
    public interface HotelPolicyPortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="out")]
        string getHotelPolicy(string in0, string in1);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HotelPolicyPortTypeChannel : HotelAPILayer.ArzooHotelPolicy.HotelPolicyPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HotelPolicyPortTypeClient : System.ServiceModel.ClientBase<HotelAPILayer.ArzooHotelPolicy.HotelPolicyPortType>, HotelAPILayer.ArzooHotelPolicy.HotelPolicyPortType {
        
        public HotelPolicyPortTypeClient() {
        }
        
        public HotelPolicyPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HotelPolicyPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelPolicyPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelPolicyPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getHotelPolicy(string in0, string in1) {
            return base.Channel.getHotelPolicy(in0, in1);
        }
    }
}
