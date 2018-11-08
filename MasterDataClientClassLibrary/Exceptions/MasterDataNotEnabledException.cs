using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterData.Exceptions
{
    public class MasterDataNotEnabledException : MasterDataException
    {
        public MasterDataNotEnabledException()
        {

        }
        public MasterDataNotEnabledException(string message) 
            : base(message)
        {

        }
        public MasterDataNotEnabledException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
