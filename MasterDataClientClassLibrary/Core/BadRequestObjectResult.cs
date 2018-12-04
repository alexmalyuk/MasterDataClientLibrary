using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MasterData.Core
{
    [DataContract]
    public class BadRequestObjectResult
    {
        [DataMember]
        public string Message;
        [DataMember]
        public Dictionary<string, string[]> ModelState;
    }
}
