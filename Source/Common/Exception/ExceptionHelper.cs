using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMAS.Common
{
    public static class ExceptionHelper
    {
        public static string GetExceptionText(Exception ex)
        {
            var writer = new StringBuilder();
            writer.AppendLine("Message : " + ex.Message + "<br/>" + Environment.NewLine + "StackTrace : " + ex.StackTrace + "<br/>" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
            return writer.ToString();
        }
    }
}
