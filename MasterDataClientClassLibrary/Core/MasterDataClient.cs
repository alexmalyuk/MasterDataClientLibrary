using MasterData.Exceptions;

namespace MasterData.Core
{
    public class MasterDataClient
    {
        AbstractConnector connector;
        AbstractConvertor convertor;
        AbstractSubject subject;
        object externalEntity;

        public MasterDataClient(AbstractSubjectFactory sf)
        {
            subject = null;
            connector = sf.CreateConnector();
            if (!connector.IsEnabled)
                throw new MasterDataNotEnabledException("MasterData is not enabled.");

            convertor = sf.GetConvertor();
            externalEntity = sf.GetExternalEntity();
            if (externalEntity != null)
                ConvertExternalEntityToSubject();
        }

        public void ConvertExternalEntityToSubject()
        {
            subject = convertor.CreateSubjectFrom(externalEntity);
        }

        public void ConvertSubjectToExternalEntity()
        {
            convertor.ConvertSubjectTo(subject, externalEntity);
        }

        public object ExternalEntity => externalEntity;

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
