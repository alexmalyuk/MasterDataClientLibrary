using MasterData.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterData;

namespace Using
{
    public class ContractorConvertor : AbstractConvertor
    {
        public override TypeFactoryEnum TypeFactory => TypeFactoryEnum.Contractor;

        public override void ConvertExternalToSubject(object externalEntity, AbstractSubject subject)
        {
            //throw new NotImplementedException();
        }

        public override void ConvertSubjectToExternal(AbstractSubject subject, object externalEntity)
        {
            //throw new NotImplementedException();
        }
    }
}
