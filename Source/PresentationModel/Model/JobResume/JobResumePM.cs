using IMAS.Common.Enum;
using IMAS.Localization.Attribute;
using IMAS.Localization.ExtensionMethod;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model.JobResume
{
    public class JobResumePM
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public int OrganizationId { get; set; }

        [RequiredField]
        [LocalizedName("OrganizationName")]
        [StringLengthRange(3, 50)]
        public string OrganizationName { get; set; }

        [RequiredField]
        [LocalizedName("JobName")]
        [StringLengthRange(3, 50)]
        public string JobName { get; set; }

        [LocalizedName]
        public short? StartYear { get; set; }

        [LocalizedName]
        public short? EndYear { get; set; }

    }
}
