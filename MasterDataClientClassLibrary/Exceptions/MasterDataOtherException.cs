﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterData.Exceptions
{
    class MasterDataOtherException : MasterDataException
    {
        public MasterDataOtherException()
        {

        }
        public MasterDataOtherException(string message) 
            : base(message)
        {

        }
        public MasterDataOtherException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
