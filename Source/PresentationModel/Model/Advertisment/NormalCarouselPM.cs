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
    public class NormalCarouselPM : MachineryPM
    {
        [LocalizedName]
        public int? MaximumRotationalDiameter { get; set; }
        [LocalizedName]
        public int? TableDiameter { get; set; }
        [LocalizedName]
        public int? MaximumHiegh { get; set; }
        [LocalizedName]
        public int? MaximumAllowedLoad { get; set; }
        [LocalizedName]
        public int? TableRotationSpeed { get; set; }
        [LocalizedName]
        public int? RotationSpeedNumber { get; set; }
        [LocalizedName]
        public int? MovementSpeed { get; set; }
        [LocalizedName]
        public int? MovementSpeedNumber { get; set; }
        [LocalizedName]
        public int? RamHorizontalCourse { get; set; }
        [LocalizedName]
        public int? RamVerticalCourse { get; set; }
        [LocalizedName]
        public int? MainEnginePower { get; set; }
    }
}
