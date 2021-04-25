using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using IMAS.Localization.ExtensionMethod;

namespace IMAS.Localization.Attribute
{
    public class LocalizedNameAttribute : DisplayNameAttribute
    {
        public LocalizedNameAttribute([CallerMemberName] string propertyName = null)
            : base(propertyName)
        {
        }

        public LocalizedNameAttribute(string displayNameValue, [CallerMemberName] string propertyName = null)
            : base(displayNameValue)
        {
        }

        public override string DisplayName
        {
            get
            {
                return DisplayNameValue.Localize();
            }
        }
    }
}
