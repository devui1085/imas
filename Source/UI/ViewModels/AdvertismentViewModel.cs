using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.UI.ViewModels
{
    public class AdvertismentViewModel
    {
        public AdvertismentPM Advertisment { get; set; }
        public List<string> Pictures { get; set; }
        public ContactInfoPM ContactInfo { get; set; } 
        public int TotalVisits { get; set; }
    }
}