using MasterData.Core;

namespace MasterData.Contractor
{
    public class ContractorFactory : AbstractSubjectFactory
    {
        public ContractorFactory() : base()
        {
        }

        public override AbstractConnector CreateConnector()
        {
            return new ContractorConnector();
        }
        public override AbstractConvertor CreateConvertor()
        {
            return new ContractorConvertor();
        }

        public override AbstractSubject CreateSubject()
        {
            return new ContractorSubject();
        }
    }
}
