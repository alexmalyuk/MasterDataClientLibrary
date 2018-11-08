using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterData.Exceptions
{
    public class MasterDataException : Exception
    {
        public MasterDataException()
        {

        }
        public MasterDataException(string message) 
            : base(message)
        {

        }
        public MasterDataException(string message, Exception inner)
            : base(message, inner)
        {

        }

    }
}
