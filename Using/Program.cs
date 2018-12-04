using MasterData.Contractor;
using MasterData.Core;
using MasterData.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    class Program
    {
        static void Main(string[] args)
        {
            ContractorSubject contractorSubj = new ContractorSubject()
            {
                Id = 6716,
                Name = "ЧП \"IMT Плюс\"",
                FullName = "ЧП IMT Плюс *********************",
                INN = "3552784041*81",
                OKPO = "3552//7842",
                VATNumber = "100323119",
                CountryOfRegistration = 804,
                TypeOfCounterparty = 1,
                PostalCode = "51274",
                Country = "УКРАИНА",
                Region = "Днепропетровская обл.",
                District = "",
                City = "г. Днепр",
                Street = "ул. Пушкина",
                House = "12",
                Flat = "17",
                StringRepresentedAddress = null,
                User = "Test"
            };

            MasterDataClient<ContractorConvertor> mdClient = new MasterDataClient<ContractorConvertor>();
            mdClient.Subject = contractorSubj;

            try
            {
                mdClient.Post();
                Console.WriteLine("{0} - Ok", contractorSubj);
            }
            catch (MasterDataValidationException ex)
            {
                Console.WriteLine("{0} - {1}", contractorSubj, ex.Message);

                StringBuilder sb = new StringBuilder();
                foreach (DictionaryEntry item in ex.Data)
                {
                    sb.AppendLine(item.Value.ToString());
                }
                Console.WriteLine("{0}", sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} - {1}", contractorSubj, ex.Message);
            }

            Console.ReadKey();
        }
    }
}
