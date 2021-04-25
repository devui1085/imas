using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Common.Enum;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model.Advertisment
{
  public  class NormalLathePM : MachineryPM
    {
        [LocalizedName]
        public HavingEnum RailsArePlated { get; set; }
        [LocalizedName]
        public HavingEnum HasRulerAndViewer { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string RulerMark { get; set; }
        [LocalizedName]
        public HavingEnum HasMorghak { get; set; }
        [LocalizedName]
        public int? MorghakDiagonal { get; set; }
        [LocalizedName]
        public int? MorghakDisplacementLength { get; set; }
        [LocalizedName]
        public HavingEnum HasLapent { get; set; }
        [LocalizedName]
        public int? MaximumBorderDiameter { get; set; }
        [LocalizedName]
        public int? MaximumDiameter { get; set; }
        [LocalizedName]
        public int? BedWidth { get; set; }
        [LocalizedName]
        public int? MaximumMachiningLength { get; set; }
        [LocalizedName]
        public int? SpindleSpinsNumber { get; set; }
        [LocalizedName]
        public int? SpindleSpinsFrom { get; set; }
        [LocalizedName]
        public int? SpindleSpinsTo { get; set; }
        [LocalizedName]
        public int? AxisMovementSpeedFrom { get; set; }
        [LocalizedName]
        public int? AxisMovementSpeedTo { get; set; }
        [LocalizedName]
        public int? MetricScrewFrom { get; set; }
        [LocalizedName]
        public int? MetricScrewTo { get; set; }
        [LocalizedName]
        public int? InkyScrewFrom { get; set; }
        [LocalizedName]
        public int? InkyScrewTo { get; set; }
        [LocalizedName]
        public HavingEnum HasSoapAndWaterSystem { get; set; }
        [LocalizedName]
        public HavingEnum HasThreeOrder { get; set; }
        [LocalizedName]
        public int? ThreeOrderDiameter { get; set; }
        [LocalizedName]
        public HavingEnum HasFourOrder { get; set; }
        [LocalizedName]
        public int? FourOrderDiameter { get; set; }
        [LocalizedName]
        public HavingEnum HasLift { get; set; }
    }
}
