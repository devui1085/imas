using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;
using IMAS.Common.Globalization;
using IMAS.Localization.ExtensionMethod;
using IMAS.Common.Enum;

namespace IMAS.PresentationModel.Model.Advertisment
{
   public class AdvertismentPM
    {
        public AdvertismentPM()
        {
            PriceValue = "0";
        }
        public int Id { get; set; }

        [RequiredField]
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string Title { get; set; }
        [LocalizedName]
        public DateTime RegisterDate { get; set; }
        [LocalizedName]
        public DateTime? ExpireDate { get; set; }
        [LocalizedName]
        [MaxLengthAttribute(200)]
        public string Comment { get; set; }
        [LocalizedName]
        [MaxLengthAttribute(200)]
        public string AdvertiserNote { get; set; }
        public int UserId { get; set; }

        public AdvertismentStatus Status { get; set; }
        public string TypeIdentity { get; set; }

        public decimal Price
        {
            get
            {
                return decimal.Parse(PriceValue);
            }
            set
            {
                PriceValue = string.Format("{0:n0}", value);
            }
        }

        [RequiredField]
        [LocalizedName]
        public string PriceValue { get; set; }
        public string RegisterDateString => RegisterDate.ToEstimatedDateTimeString();
        public string StatusTitle => $"AdvertismentStatus_{Status}".Localize();
        public string TypeIdentityLocalized => TypeIdentity.Localize();
        public string FistImageName { get; set; }
    }
}
