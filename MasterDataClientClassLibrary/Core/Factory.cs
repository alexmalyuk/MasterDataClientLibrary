using MasterData.Contractor;
using MasterData.Exceptions;

namespace MasterData.Core
{
    public class Factory<ConvertorType> where ConvertorType : AbstractConvertor, new()
    {
        AbstractConvertor convertor;

        public Factory()
        {
            convertor = new ConvertorType();
        }

        public AbstractConvertor CreateConvertor()
        {
            return convertor;
        }

        public AbstractConnector CreateConnector()
        {
            switch (convertor.TypeFactory)
            {
                case TypeFactoryEnum.Contractor:
                    return new ContractorConnector();
                //case TypeFactoryEnum.Contract:
                //    return new ContractConnector();
                default:
                    throw new MasterDataOtherException();
            }
        }

        public AbstractSubject CreateSubject()
        {
            switch (convertor.TypeFactory)
            {
                case TypeFactoryEnum.Contractor:
                    return new ContractorSubject();
                //case TypeFactoryEnum.Contract:
                //    return new ContractSubject();
                default:
                    throw new MasterDataOtherException();
            }
        }
    }
}
