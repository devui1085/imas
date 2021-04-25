namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.ForbiddenIdentifier")]
    public partial class ForbiddenIdentifier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Identifier { get; set; }

        public byte Context { get; set; }
    }
}
