using EDR_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EDR_api.Services
{
    public class APIService
    {
        public async Task<CompanyModel> GetDataByOKPO(string okpo)
        {
            using (var http = new HttpClient())
            {
                var result = await http.GetAsync(new Uri("http://edr.data-gov-ua.org/api/companies?where={\"edrpou\":{\"contains\":\""+ okpo + "\"}}"));
                result.EnsureSuccessStatusCode();

                var users = await result.Content.ReadAsAsync<IEnumerable<CompanyModel>>();

                return users.Where(c => c.edrpou == okpo).FirstOrDefault();
            }
        }
    }
}
