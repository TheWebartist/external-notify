namespace ExternalNotify.Demos.Uwp.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ExternalNotifyDemoMessage
    {
        #region Properties

        [DataMember(Name = "type")]
        public string MessageType { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        #endregion Properties
    }
}