namespace MasterData.Core
{
    public abstract class AbstractSubjectFactory
    {
        private AbstractConvertor convertor;
        private object externalEntity;

        public AbstractSubjectFactory(AbstractConvertor convertor, object externalEntity)
        {
            this.convertor = convertor;
            this.externalEntity = externalEntity;
        }

        public AbstractConvertor GetConvertor() => convertor;
        public object GetExternalEntity() => externalEntity;

        public abstract AbstractConnector CreateConnector();
        public abstract AbstractSubject CreateSubject();
    }
}
