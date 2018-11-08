using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterData.Exceptions
{
    public class MasterDataValidationException : MasterDataException
    {
        public MasterDataValidationException()
        {

        }
        public MasterDataValidationException(string message) 
            : base(message)
        {

        }
        public MasterDataValidationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
