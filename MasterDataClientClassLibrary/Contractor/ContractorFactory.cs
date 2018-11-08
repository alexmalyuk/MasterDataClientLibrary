using MasterData.Core;

namespace MasterData.Contractor
{
    public class ContractorFactory : AbstractSubjectFactory
    {
        public ContractorFactory(AbstractConvertor convertor, object externalEntity) : base(convertor, externalEntity)
        {
        }

        public override AbstractConnector CreateConnector()
        {
            return new ContractorConnector();
        }

        public override AbstractSubject CreateSubject()
        {
            return new ContractorSubject();
        }
    }
}
