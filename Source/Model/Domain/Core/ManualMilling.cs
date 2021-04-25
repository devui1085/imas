using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.ManualMilling")]
    public partial class ManualMilling : Machinery
    {
        public int? TableWidth { get; set; }
        public int? TableHeight { get; set; }
        public int? XCourse { get; set; }
        public string XCourseMinSpeed { get; set; }
        public string XCourseMaxSpeed { get; set; }
        public int? YCourse { get; set; }
        public string YCourseMinSpeed { get; set; }
        public string YCourseMaxSpeed { get; set; }
        public int? ZCourse { get; set; }
        public string ZCourseMinSpeed { get; set; }
        public string ZCourseMaxSpeed { get; set; }
        public HavingEnum HasMeterFunctionality { get; set; }
        public LubricationType LubricationType { get; set; }
        public HavingEnum HasSoapWaterPump { get; set; }
        public MillingRailType MillingRailType { get; set; }
        public RailsHealthStatus RailsHealthStatus { get; set; }
        public HavingEnum HasLEDLighting { get; set; }
        public HavingEnum HasToolbox { get; set; }
        public AxisType AxisType { get; set; }
        public SpindleType SpindleType { get; set; }
        public int? SpindleMaxSpeed{get;set;}
        public int? SpindleMinSpeed { get; set; }
        public HavingEnum HasDrillCapability { get; set; }
        public HavingEnum HasRulerAndDRO { get; set; }
        public HavingEnum HasClamp { get; set; }
    }
}
