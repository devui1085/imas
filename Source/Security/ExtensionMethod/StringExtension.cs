using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Security.Helper;

namespace IMAS.Security.ExtensionMethod
{
    public static class StringExtension
    {
        public static byte[] ComputeSha256Hash(this string str)
        {
            return HashHelper.ComputeSha256Hash(str);
        }
    }
}
