using System.Runtime.Serialization;

namespace MasterData.Core
{
    [DataContract]
    abstract public class AbstractSubject
    {
        [DataMember(Name = "NativeId")]
        public int? Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string User { get; set; }
    }
}
