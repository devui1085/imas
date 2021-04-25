using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Machinery")]
    public partial class Machinery : Advertisment
    {
        [StringLength(100)]
        public string Model { get; set; }

        public Country ManufacturingCountry { get; set; }

        [StringLength(100)]
        public string ManufacturingFactory { get; set; }

        public int? ConstructionYear { get; set; }

        public int? Height { get; set; }

        public int? Width { get; set; }

        public int? Length { get; set; }

        public int? Wieght { get; set; }

        public HealthStatus HealthStatus { get; set; }

        public int? MaxWorkPieceWeight { get; set; }
    }
}
