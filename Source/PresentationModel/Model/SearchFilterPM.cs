using IMAS.Common.Enum;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMAS.PresentationModel.Model
{
    public class SearchFilterPM
    {
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string Title { get; set; }
        //[LocalizedName]
        //public DateTime RegisterDateFrom { get; set; }
        //[LocalizedName]
        //public DateTime RegisterDateTo { get; set; }

        //public decimal PriceFrom
        //{
        //    get
        //    {
        //        return decimal.Parse(PriceValueFrom);
        //    }
        //    set
        //    {
        //        PriceValueFrom = string.Format("{0:n0}", value);
        //    }
        //}

        //[LocalizedName]
        //public string PriceValueFrom { get; set; }

        //public decimal PriceTo
        //{
        //    get
        //    {
        //        return decimal.Parse(PriceValueTo);
        //    }
        //    set
        //    {
        //        PriceValueTo = string.Format("{0:n0}", value);
        //    }
        //}

        //[LocalizedName]
        //public string PriceValueTo { get; set; }

        [LocalizedName]
        public Country ManufacturingCountry { get; set; }

        [LocalizedName]
        public int? ConstructionYearFrom { get; set; }
        [LocalizedName]
        public int? ConstructionYearTo { get; set; }
        [LocalizedName]
        public HealthStatus HealthStatus { get; set; }
        [LocalizedName]
        public AdvertismentType AdvertismentType { get; set; }
    }
}
