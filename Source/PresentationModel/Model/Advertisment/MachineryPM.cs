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
   public class MachineryPM :AdvertismentPM
    {
        [StringLengthRange(0, 100)]
        [LocalizedName]
        public string Model { get; set; }

        [LocalizedName]
        public Country ManufacturingCountry { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string ManufacturingFactory { get; set; }
        [LocalizedName]
        public int? ConstructionYear { get; set; }
        [LocalizedName]
        public int? Height { get; set; }
        [LocalizedName]
        public int? Width { get; set; }
        [LocalizedName]
        public int? Length { get; set; }
        [LocalizedName]
        public int? Wieght { get; set; }
        [LocalizedName]
        public HealthStatus HealthStatus { get; set; }
        [LocalizedName]
        public int? MaxWorkPieceWeight { get; set; }
    }
}
