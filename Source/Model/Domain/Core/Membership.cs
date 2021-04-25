namespace IMAS.Model.Domain.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Membership")]
    public partial class Membership
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public byte[] Password { get; set; }

        public bool IsApproved { get; set; }

        public bool IsLockedOut { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastPasswordChangedDate { get; set; }

        public DateTime? LastLockoutDate { get; set; }

        public int FailedPasswordAttemptCount { get; set; }

        public Guid VerificationCode { get; set; }

        public DateTime VerificationCodeSendDate { get; set; }

        public Guid? PasswordResetToken { get; set; }

        public virtual User User { get; set; }
    }
}
