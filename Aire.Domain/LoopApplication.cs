using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Aire.Domain
{
    [DataContract]
    public sealed class LoopApplication
    {
        [DataMember]
        [Key]
        public string Applicant { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
    }
}
