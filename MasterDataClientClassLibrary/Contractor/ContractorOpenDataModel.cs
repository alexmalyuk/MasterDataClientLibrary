using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MasterData.Contractor
{
    [DataContract(Name = "ContractorOpenData", Namespace = Const.DataContractNameSpace)]
    public class ContractorOpenDataModel
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string shortName { get; set; }
        [DataMember]
        public string edrpou { get; set; }
        [DataMember]
        public string location { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string boss { get; set; }
        [DataMember]
        public string kved { get; set; }
        [DataMember]
        public string inn { get; set; }
        [DataMember]
        public DateTime? registrationDate { get; set; }
    }
}
