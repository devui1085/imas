using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Notification")]
    public partial class Notification
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public NotificationType Type { get; set; }

        public bool IsRead { get; set; }

        public int? SubjectId { get; set; }

        public int? ObjectId { get; set; }

        public int ReceiverId { get; set; }

        public virtual User Subject { get; set; }

        public virtual User Receiver { get; set; }

        #region Not Mapped Properties
        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public string Title { get; set; }

        [NotMapped]
        public string Url { get; set; }

        [NotMapped]
        public string ImageUrl { get; set; }
        #endregion
    }
}
