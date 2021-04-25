namespace IMAS.Model.Domain.Core
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Follow")]
    public partial class Follow
    {
        public int Id { get; set; }

        public int FollowerId { get; set; }

        public int FollowedId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
