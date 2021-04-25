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
    public class ManualMillingPM : MachineryPM
    {
        [LocalizedName]
        public int? TableWidth { get; set; }
        [LocalizedName]
        public int? TableHeight { get; set; }
        [LocalizedName]
        public int? XCourse { get; set; }
        [LocalizedName]
        public string XCourseMinSpeed { get; set; }
        [LocalizedName]
        public string XCourseMaxSpeed { get; set; }
        [LocalizedName]
        public int? YCourse { get; set; }
        [LocalizedName]
        public string YCourseMinSpeed { get; set; }
        [LocalizedName]
        public string YCourseMaxSpeed { get; set; }
        [LocalizedName]
        public int? ZCourse { get; set; }
        [LocalizedName]
        public string ZCourseMinSpeed { get; set; }
        [LocalizedName]
        public string ZCourseMaxSpeed { get; set; }
        [LocalizedName]
        public HavingEnum HasMeterFunctionality { get; set; }
        [LocalizedName]
        public LubricationType LubricationType { get; set; }
        [LocalizedName]
        public HavingEnum HasSoapWaterPump { get; set; }
        [LocalizedName]
        public MillingRailType MillingRailType { get; set; }
        [LocalizedName]
        public RailsHealthStatus RailsHealthStatus { get; set; }
        [LocalizedName]
        public HavingEnum HasLEDLighting { get; set; }
        [LocalizedName]
        public HavingEnum HasToolbox { get; set; }
        [LocalizedName]
        public AxisType AxisType { get; set; }
        [LocalizedName]
        public SpindleType SpindleType { get; set; }
        [LocalizedName]
        public int? SpindleMaxSpeed { get; set; }
        [LocalizedName]
        public int? SpindleMinSpeed { get; set; }
        [LocalizedName]
        public HavingEnum HasDrillCapability { get; set; }
        [LocalizedName]
        public HavingEnum HasRulerAndDRO { get; set; }
        [LocalizedName]
        public HavingEnum HasClamp { get; set; }
    }
}
