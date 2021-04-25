using IMAS.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMAS.Common.Data
{
  public  class SearchFilter
    {
        [StringLengthRange(0, 100)]
        public string Title { get; set; }
        public DateTime RegisterDate { get; set; }
        public AdvertismentStatus Status { get; set; }
        public string TypeIdentity { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public string Model { get; set; }

        public Country ManufacturingCountry { get; set; }

        public string ManufacturingFactory { get; set; }

        public int? ConstructionYear { get; set; }

        public int? Height { get; set; }

        public int? Width { get; set; }

        public int? Length { get; set; }

        public int? Wieght { get; set; }

        public HealthStatus HealthStatus { get; set; }

        public int? MaxWorkPieceWeight { get; set; }
    }
}
