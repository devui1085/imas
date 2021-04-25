using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.NormalCarousel")]
    public partial class NormalCarousel : Machinery
    {
        public int? MaximumRotationalDiameter { get; set; }
        public int? TableDiameter { get; set; }
        public int? MaximumHiegh { get; set; }
        public int? MaximumAllowedLoad { get; set; }
        public int? TableRotationSpeed { get; set; }
        public int? RotationSpeedNumber { get; set; }
        public int? MovementSpeed { get; set; }
        public int? MovementSpeedNumber { get; set; }
        public int? RamHorizontalCourse { get; set; }
        public int? RamVerticalCourse { get; set; }
        public int? MainEnginePower { get; set; }
    }
}

