using System.Runtime.Serialization;

namespace Aire.Domain
{
    [DataContract]
    public sealed class LoopEvent
    {
        [DataMember]
        public string ApplicationId { get; set; }

        [DataMember]
        public string Category { get; set; }
    }
}
