using EDR_api.Models;
using EDR_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EDR_api_test
{

    class Program
    {

        static void Main(string[] args)
        {
            string okpo = "2552549";
            APIService api = new APIService();
            CompanyModel company = api.GetDataByOKPO(okpo).GetAwaiter().GetResult();

            if(company != null)
            {
                Console.WriteLine("edrpou = {0}", company.edrpou);
                Console.WriteLine("name = {0}", company.name);
            }
            else
            {
                Console.WriteLine("Not found {0}", okpo);
            }

            Console.ReadKey();
        }
    }
}
