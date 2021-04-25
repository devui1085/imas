namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Location")]
    public partial class Location
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Text { get; set; }
    }
}
