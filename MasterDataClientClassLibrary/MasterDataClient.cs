using MasterData.Contractor;
using MasterData.Exceptions;

namespace MasterData.Core
{
    public class MasterDataClient<ConvertorType> where ConvertorType : AbstractConvertor
    {
        AbstractConnector connector;
        AbstractConvertor convertor;
        AbstractSubject subject;
        object externalEntity = null;

        public MasterDataClient(ConvertorType convertor)
        {
            this.convertor = convertor;

            switch (convertor?.TypeFactory)
            {
                case TypeFactoryEnum.Contractor:
                    AbstractSubjectFactory sf = new ContractorFactory();
                    break;
            }

            //ConvertorType subjectFactory = new ConvertorType();

            //connector = subjectFactory.CreateConnector();
            //if (!connector.IsEnabled)
            //    throw new MasterDataNotEnabledException("MasterData is not enabled.");

            //convertor = subjectFactory.CreateConvertor();
            //subject = subjectFactory.CreateSubject();
        }

        public MasterDataClient(ConvertorType convertor, object externalEntity) : this(convertor)
        {
            ExternalEntity = externalEntity;
        }

        public object ExternalEntity
        {
            get { return externalEntity; }
            set
            {
                externalEntity = value;
                if (externalEntity != null)
                    ConvertExternalEntityToSubject();
            }
        }

        public void ConvertExternalEntityToSubject()
        {
            subject = convertor.CreateSubjectFrom(externalEntity);
        }

        public void ConvertSubjectToExternalEntity()
        {
            convertor.ConvertSubjectTo(subject, externalEntity);
        }

        public void Post()
        {
            connector.Post(subject);
        }

        public void Get()
        {
            subject = connector.Get(subject.Id);
            convertor.ConvertSubjectTo(subject, externalEntity);
        }

    }
}
