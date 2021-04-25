using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model.Business
{
    public class BusinessIntroducePM
    {
        [RequiredField]
        [LocalizedName("BusinessIntroduceText")]
        [StringLengthRange(10, 200)]
        public string Text { get; set; }
    }
}
