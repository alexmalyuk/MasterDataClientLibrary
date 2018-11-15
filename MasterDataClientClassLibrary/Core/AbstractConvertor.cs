﻿namespace MasterData.Core
{
    abstract public class AbstractConvertor
    {
        public abstract TypeFactoryEnum TypeFactory { get; }

        public abstract void ConvertSubjectToExternal(AbstractSubject subject, object externalEntity);

        public abstract void ConvertExternalToSubject(object externalEntity, AbstractSubject subject);

    }
}
