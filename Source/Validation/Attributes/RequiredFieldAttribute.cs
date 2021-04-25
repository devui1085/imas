namespace IMAS.Validation.Attribute
{
    public class RequiredFieldAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredFieldAttribute(string errorMessageResourceName = "Required")
        {
            this.ErrorMessageResourceName = errorMessageResourceName;
            this.ErrorMessageResourceType = typeof(IMAS.Localization.Resources);
        }
    }
}
