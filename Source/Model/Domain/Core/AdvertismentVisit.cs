namespace IMAS.Model.Domain.Core
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.AdvertismentVisit")]
    public partial class AdvertismentVisit
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public int AdvertismentId { get; set; }
        public int Count { get; set; }
        public virtual Advertisment Advertisment { get; set; }
    }
}
