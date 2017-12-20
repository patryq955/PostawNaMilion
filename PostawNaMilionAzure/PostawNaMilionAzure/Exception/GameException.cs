using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Exception
{
    public class GameException : System.Exception
    {
        public GameException(string message): base(message)
        {

        }
    }
}