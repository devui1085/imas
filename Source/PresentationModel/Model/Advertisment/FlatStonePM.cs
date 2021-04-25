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
    public class FlatStonePM : MachineryPM
    {
        [LocalizedName]
        public StoneType StoneType { get; set; }
        [LocalizedName]
        public int? MaximumGrindingWidth { get; set; }
        [LocalizedName]
        public int? MaximumGrindingLength { get; set; }
        [LocalizedName]
        public int? MaximumGrindingHeight { get; set; }
        [LocalizedName]
        public int? MaximumAllowedLoad { get; set; }
        [LocalizedName]
        public int? StoneWidth { get; set; }
        [LocalizedName]
        public int? StoneHeight { get; set; }
        [LocalizedName]
        public int? SpindleSpeed { get; set; }
        [LocalizedName]
        public int? HydraulicReservoirPressure { get; set; }
        [LocalizedName]
        public int? HydraulicOilTankCapacity { get; set; }
    }
}
