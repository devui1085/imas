using System.Collections.Generic;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.UI.ViewModels.Search
{
    public class SearchViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<AdvertismentPM> Advertisments { get; set; }
        public int TotallRows { get; set; }
        public string Keyword { get; set; }
        public SearchFilterPM Filter { get; set; }
    }
}