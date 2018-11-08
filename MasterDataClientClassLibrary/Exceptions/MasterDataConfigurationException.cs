using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterData.Exceptions
{
    public class MasterDataConfigurationException : MasterDataException
    {
        public MasterDataConfigurationException()
        {

        }
        public MasterDataConfigurationException(string message) 
            : base(message)
        {

        }
        public MasterDataConfigurationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
