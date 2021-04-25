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
    public class DrillPM : MachineryPM
    {
        [LocalizedName]
        public DrillType DrillType { get; set; }
        [LocalizedName]
        public int? DiameterDrillMaxAllowed { get; set; }
        [LocalizedName]
        public string Morse { get; set; }
        [LocalizedName]
        public int? MaxDistanceFromColumn { get; set; }
        [LocalizedName]
        public int? MaxDistanceFromTable { get; set; }
        [LocalizedName]
        public int? TableWidth { get; set; }
        [LocalizedName]
        public int? TableHeight { get; set; }
        [LocalizedName]
        public int? NumberOfSpindleSpeeds { get; set; }
        [LocalizedName]
        public GearboxType GearboxType { get; set; }
        [LocalizedName]
        public HavingEnum MillerCapability { get; set; }
        [LocalizedName]
        public HoleType HoleType { get; set; }
        [LocalizedName]
        public int? ColumnHeadDiameter { get; set; }
        [LocalizedName]
        public HavingEnum RotatingTable { get; set; }
        [LocalizedName]
        public int? TableMaxRotation { get; set; }
        [LocalizedName]
        public HavingEnum CoolingPump { get; set; }
    }
}
