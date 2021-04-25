using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Localization.ExtensionMethod;

namespace IMAS.Validation.Attributes
{
    public class MaxLengthAttribute : StringLengthAttribute
    {
        public MaxLengthAttribute(int length) : base(length)
        {
            ErrorMessage = string.Format("MsgStringMaxLength".Localize(), "توضیح", MaximumLength);
            ErrorMessage = "this is error messages";
        }
    }
}
