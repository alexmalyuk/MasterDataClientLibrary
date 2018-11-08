namespace MasterData.Core
{
    abstract public class AbstractConvertor
    {

        abstract public AbstractSubject CreateSubjectFrom(object externalEntity);
        abstract public void ConvertSubjectTo(AbstractSubject subject, object externalEntity);
    }
}
