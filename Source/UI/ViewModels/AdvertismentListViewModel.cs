using System.Collections.Generic;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.UI.ViewModels
{
    public class AdvertismentListViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<AdvertismentPM> Advertisments { get; set; }
        public int TotallRows { get; set; }
    }
}