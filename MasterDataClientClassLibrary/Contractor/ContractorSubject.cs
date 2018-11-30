using MasterData.Core;
using System.Runtime.Serialization;

namespace MasterData.Contractor
{
    [DataContract(Name = "ContractorInfo", Namespace = Const.DataContractNameSpace)]
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
        public int? CountryOfRegistration { get; set; }
        [DataMember]
        public int? TypeOfCounterparty { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string House { get; set; }
        [DataMember]
        public string Flat { get; set; }
        [DataMember]
        public string StringRepresentedAddress { get; set; }
    }
}
