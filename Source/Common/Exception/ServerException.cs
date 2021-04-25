using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exception
{
    public class ServerException : BusinessException
    {
        public ServerException(string message) : base(message)
        {
            ShowMessage = true;
        }
    }
}
