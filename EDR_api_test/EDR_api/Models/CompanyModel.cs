using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDR_api.Models
{
    public class CompanyModel
    {
        public string id { get; set;}
        public string edrpou { get; set; }
        public string officialName { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string mainPerson { get; set; }
        public string occupation { get; set; }
        public string status { get; set; }
    }
}
