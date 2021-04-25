using System.ComponentModel.DataAnnotations;
using IMAS.Localization.ExtensionMethod;

namespace IMAS.Validation.Attribute
{
    public class StringLengthRangeAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
    {
        public StringLengthRangeAttribute(int minimumLength, int maximumLength, string errorMessageResourceName = "InvalidStringLength")
            : base(maximumLength)
        {
            this.MinimumLength = minimumLength;
            this.ErrorMessageResourceName = errorMessageResourceName;
            this.ErrorMessageResourceType = typeof(IMAS.Localization.Resources);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("MsgStringLengthRange".Localize(), name, MinimumLength, MaximumLength );
        }
    }
}
