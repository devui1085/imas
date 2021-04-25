using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        public int ContentId { get; set; }

        public int SenderId { get; set; }

        [Required]
        [StringLength(4000)]
        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsPrivate { get; set; }

        public CommentStatus Status { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        public virtual Content Content { get; set; }

        public virtual User Sender { get; set; }
    }
}
