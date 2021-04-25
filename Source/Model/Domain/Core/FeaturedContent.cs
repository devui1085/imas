namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.FeaturedContent")]
    public partial class FeaturedContent
    {
        public int Id { get; set; }

        public int ContentId { get; set; }

        public virtual Content Content { get; set; }
    }
}
