using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMAS.Facade.Core;
using IMAS.PresentationModel.ModelContainer.Blog;
using IMAS.UI.ViewModels.Blog;

namespace IMAS.UI.Controllers
{
    public class PublicationController : Controller
    {
        public PublicationService PublicationService { get; set; }

        public PublicationController()
        {
            PublicationService = new PublicationService();
        }

        //[Route("{publicationName:regex(^[a-zA-Z]{4,20}$)}", Order = 10)]
        public ActionResult Index(string publicationName)
        {
            var container = PublicationService.ReadPublicationHomePageData(publicationName);
            if (container is BlogHomePageModelContainer) {
                var viewModel = new BlogHomePageViewModel(container as BlogHomePageModelContainer);
                return View("~/Views/Blog/Index.cshtml", viewModel);
            }
            else {
                return View("~/Views/Channel/Index.cshtml", container);
            }
        }
    }
}