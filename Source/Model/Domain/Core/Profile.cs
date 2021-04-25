using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Profile")]
    public partial class Profile
    {
        public Profile()
        {
        }

        public Profile(ProfileKeyValueType type, string value)
        {
            Type = type;
            Value = value;
        }
        public int Id { get; set; }

        public int UserId { get; set; }

        public ProfileKeyValueType Type { get; set; }

        [Required]
        [StringLength(4000)]
        public string Value { get; set; }

        public virtual User User { get; set; }
    }
}
