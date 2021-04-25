namespace IMAS.Model.Domain.Core
{
    using IMAS.Common.Enum;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Drill")]
    public partial class Drill : Machinery
    {
        public DrillType DrillType { get; set; }
        public int? DiameterDrillMaxAllowed { get; set; }
        [StringLength(100)]
        public string Morse { get; set; }
        public int? MaxDistanceFromColumn { get; set; }
        public int? MaxDistanceFromTable { get; set; }
        public int? TableWidth { get; set; }
        public int? TableHeight { get; set; }
        public int? NumberOfSpindleSpeeds { get; set; }
        public GearboxType GearboxType { get; set; }
        public HavingEnum MillerCapability { get; set; }
        public HoleType HoleType { get; set; }
        public int? ColumnHeadDiameter { get; set; }
        public HavingEnum RotatingTable { get; set; }
        public int? TableMaxRotation { get; set; }
        public HavingEnum CoolingPump { get; set; }
    }
}
