using IMAS.Common.Enum;
using IMAS.Localization.Attribute;
using IMAS.Localization.ExtensionMethod;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model.Organization
{
    public class EducationalResumePM
    {
        public int Id { get; set; }

        [RequiredField]
        [LocalizedName("EducationalOrganizationName")]
        [StringLengthRange(3, 50)]
        public string OrganizationName { get; set; }

        [RequiredField]
        [LocalizedName]
        [StringLengthRange(3, 50)]
        public string UniversityFieldName { get; set; }

        [RequiredField]
        [LocalizedName]
        public EducationGrade EducationGrade { get; set; }

        public string EducationGradeString
        {
            get
            {
                return $"EducationGrade_{EducationGrade}".Localize();
            }
        }

        [LocalizedName]
        public short? StartYear { get; set; }

        [LocalizedName]
        public short? EndYear { get; set; }
    }
}
