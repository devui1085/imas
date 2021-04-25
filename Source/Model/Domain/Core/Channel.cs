namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Channel")]
    public partial class Channel : Publication
    {
        //public virtual Publication Publication { get; set; }
    }
}
