using MasterData.Core;
using MasterData.Exceptions;
using System;
using System.Collections.Generic;

namespace MasterData.Contractor
{
    public class ContractorConnector : AbstractConnector
    {
        public override AbstractSubject Get(int Id)
        {
            return HttpGetDataAs<ContractorSubject>("ContractorInfo/" + nodeAlias + "/" + Id.ToString());
        }

        public override List<AbstractSubject> GetMany()
        {
            throw new NotImplementedException();
            
            //List<ContractorSubject> list = HttpGetDataAs<List<ContractorSubject>>("ContractorInfo/" + nodeAlias);
            //return list as List<AbstractSubject>;
        }

        public override void Post(AbstractSubject subject)
        {
            if (subject == null)
                throw new MasterDataOtherException("", new ArgumentNullException("subject"));

            ContractorSubject contractorSubject = subject as ContractorSubject;

            HttpPostDataAs<ContractorSubject>("ContractorInfo/" + nodeAlias, contractorSubject);
        }

        public ContractorOpenDataModel GetOpenData(string okpo)
        {
            return HttpGetDataAs<ContractorOpenDataModel>("OpenData/" + okpo);
        }
    }
}
