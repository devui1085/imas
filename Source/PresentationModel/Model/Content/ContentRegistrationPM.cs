using System.Web.Mvc;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model
{
    public class ContentRegistrationPM
    {
        public int? Id { get; set; }
        public int AuthorId { get; set; }

        [RequiredField]
        [LocalizedName]
        public string Title { get; set; }

        [AllowHtml]
        [RequiredField]
        public string Text { get; set; }

        [RequiredField]
        [LocalizedName]
        public bool Published { get; set; }

        [LocalizedName]
        public string ShortAbstract { get; set; }

        public string AuthorFullName { get; set; }
    }
}
