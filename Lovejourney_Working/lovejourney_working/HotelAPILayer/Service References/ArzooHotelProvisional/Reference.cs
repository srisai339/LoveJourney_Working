﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelAPILayer.ArzooHotelProvisional {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://provisional.hotel.com", ConfigurationName="ArzooHotelProvisional.HotelProvisionalPortType")]
    public interface HotelProvisionalPortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="out")]
        string getHotelProvisional(string in0, string in1);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HotelProvisionalPortTypeChannel : HotelAPILayer.ArzooHotelProvisional.HotelProvisionalPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HotelProvisionalPortTypeClient : System.ServiceModel.ClientBase<HotelAPILayer.ArzooHotelProvisional.HotelProvisionalPortType>, HotelAPILayer.ArzooHotelProvisional.HotelProvisionalPortType {
        
        public HotelProvisionalPortTypeClient() {
        }
        
        public HotelProvisionalPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HotelProvisionalPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelProvisionalPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelProvisionalPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getHotelProvisional(string in0, string in1) {
            return base.Channel.getHotelProvisional(in0, in1);
        }
    }
}