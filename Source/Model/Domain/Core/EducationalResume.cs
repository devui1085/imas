namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.EducationalResume")]
    public partial class EducationalResume
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OrganizationId { get; set; }

        public int UniversityFieldId { get; set; }

        public byte EducationGrade { get; set; }

        public short? StartYear { get; set; }

        public short? EndYear { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual UniversityField UniversityField { get; set; }

        public virtual User User { get; set; }
    }
}
