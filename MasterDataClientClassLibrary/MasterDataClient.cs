using MasterData.Contractor;
using MasterData.Exceptions;

namespace MasterData.Core
{
    public class MasterDataClient<ConvertorType> where ConvertorType : AbstractConvertor, new()
    {
        AbstractConnector connector;
        AbstractConvertor convertor;
        AbstractSubject subject;
        object externalEntity = null;

        public MasterDataClient()
        {
            Factory<ConvertorType> factory = new Factory<ConvertorType>();

            connector = factory.CreateConnector();
            convertor = factory.CreateConvertor();
            subject = factory.CreateSubject();
        }

        public MasterDataClient(object externalEntity) : this()
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
            convertor.ConvertExternalToSubject(externalEntity, subject);
        }

        public void ConvertSubjectToExternalEntity()
        {
            convertor.ConvertSubjectToExternal(subject, externalEntity);
        }

        public void Post()
        {
            connector.Post(subject);
        }

        public void Get()
        {
            if (subject.Id != null)
            {
                subject = connector.Get((int)subject.Id);
                convertor.ConvertSubjectToExternal(subject, externalEntity);
            }
        }

        public AbstractSubject Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
    }
}
