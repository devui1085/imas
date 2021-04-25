using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;
using IMAS.PresentationModel.ModelContainer;

namespace IMAS.UI.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<AdvertismentPM> LatestAdvertisments{ get; set; }
    }
}