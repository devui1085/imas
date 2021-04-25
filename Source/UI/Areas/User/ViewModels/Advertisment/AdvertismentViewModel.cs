using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.UI.Areas.User.ViewModels.Advertisment
{
    public class AdvertismentViewModel : ViewModelBase
    {
        public AdvertismentPM Advertisment { get; set; }
        public string AdvertismentTypeName { get; set; }
    }
}