using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Exceptions
{
    public class GameException : Exception
    {
        public GameException(string message): base(message)
        {

        }
    }
}