using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.FlatStone")]
    public partial class FlatStone : Machinery
    {
        public StoneType StoneType { get; set; }
        public int? MaximumGrindingWidth { get; set; }
        public int? MaximumGrindingLength { get; set; }
        public int? MaximumGrindingHeight { get; set; }
        public int? MaximumAllowedLoad { get; set; }
        public int? StoneWidth { get; set; }
        public int? stoneHeight { get; set; }
        public int? SpindleSpeed { get; set; }
        public int? HydraulicReservoirPressure { get; set; }
        public int? HydraulicOilTankCapacity { get; set; }
    }
}

