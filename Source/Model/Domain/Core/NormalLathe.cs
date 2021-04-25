using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.NormalLathe")]
    public partial class NormalLathe : Machinery
    {
        public HavingEnum RailsArePlated { get; set; }

        public HavingEnum HasRulerAndViewer { get; set; }

        [StringLength(100)]
        public string RulerMark { get; set; }

        public HavingEnum HasMorghak { get; set; }

        public int? MorghakDiagonal { get; set; }

        public int? MorghakDisplacementLength { get; set; }

        public HavingEnum HasLapent { get; set; }

        public int? MaximumBorderDiameter { get; set; }

        public int? MaximumDiameter { get; set; }

        public int? BedWidth { get; set; }

        public int? MaximumMachiningLength { get; set; }

        public int? SpindleSpinsNumber { get; set; }

        public int? SpindleSpinsFrom { get; set; }

        public int? SpindleSpinsTo { get; set; }

        public int? AxisMovementSpeedFrom { get; set; }

        public int? AxisMovementSpeedTo { get; set; }

        public int? MetricScrewFrom { get; set; }

        public int? MetricScrewTo { get; set; }

        public int? InkyScrewFrom { get; set; }

        public int? InkyScrewTo { get; set; }

        public HavingEnum HasSoapAndWaterSystem { get; set; }

        public HavingEnum HasThreeOrder { get; set; }

        public int? ThreeOrderDiameter { get; set; }

        public HavingEnum HasFourOrder { get; set; }

        public int? FourOrderDiameter { get; set; }

        public HavingEnum HasLift { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Id { get; set; }

        //public virtual Machinery Machinery { get; set; }
    }
}
