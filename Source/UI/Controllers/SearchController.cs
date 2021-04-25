using System.Web.Mvc;
using IMAS.Facade.Core;
using IMAS.UI.Infrastructure.SignalR;
using IMAS.UI.ViewModels.Article;
using IMAS.UI.ViewModels.Search;
using IMAS.UI.ViewModels.Tag;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;
using System.Collections.Generic;

namespace IMAS.UI.Controllers
{
    public class SearchController : BaseController
    {
        public ArticleService ArticleService { get; set; }
        public AdvertismentService AdvertismentService { get; }

        public SearchController()
        {
            ArticleService = new ArticleService();
            AdvertismentService = new AdvertismentService();
        }

        [Route("search/", Name = "Search")]
        public ActionResult Index(SearchFilterPM filter)
        {
            IEnumerable<AdvertismentPM> result = null;
            if (ModelState.IsValid)
            {
               result = AdvertismentService.SearchAdvertisments(filter);
            }
            var viewModel = new SearchViewModel()
            {
                Advertisments = result,
                Keyword = filter.Title,
                Filter = filter
            };
            return View(viewModel);
        }
    }
}