using MasterData.Core;
using System.Runtime.Serialization;

namespace MasterData.Contractor
{
    [DataContract(Name = "ContractorInfo", Namespace = "http://www.metrans.com.ua")]
    public class ContractorSubject : AbstractSubject
    {
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string INN { get; set; }
        [DataMember]
        public string OKPO { get; set; }
        [DataMember]
        public string VATNumber { get; set; }
        [DataMember]
        public string LegalAddress { get; set; }
    }
}
