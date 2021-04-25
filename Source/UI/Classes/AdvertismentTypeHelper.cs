using IMAS.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMAS.UI.Classes
{
    public static class AdvertismentTypeHelper
    {
        public static string GetAdvertismentCategory(string advertismentType)
        {
            string categoryName = string.Empty;
            AdvertismentType currentType = (AdvertismentType)Enum.Parse(typeof(AdvertismentType), advertismentType);
            switch (currentType)
            {
                case AdvertismentType.CncLathe:
                case AdvertismentType.NormalLathe:
                case AdvertismentType.NormalCarousel:
                    categoryName = "Lathe";
                    break;
                case AdvertismentType.FlatStone:
                    categoryName = "Stone";
                    break;
                case AdvertismentType.CncMilling:
                case AdvertismentType.ManualMilling:
                    categoryName = "Milling";
                    break;
                default:
                    categoryName = "Advertisment";
                    break;
            }
            return categoryName;
        }
    }
}