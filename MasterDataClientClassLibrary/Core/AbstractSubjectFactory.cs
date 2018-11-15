namespace MasterData.Core
{
    public abstract class AbstractSubjectFactory
    {

        public AbstractSubjectFactory()
        {
        }

        public abstract AbstractConvertor CreateConvertor();
        public abstract AbstractConnector CreateConnector();
        public abstract AbstractSubject CreateSubject();
    }
}
