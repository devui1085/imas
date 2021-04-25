using System.Collections.Generic;
using System.Web.Mvc;
using IMAS.Common.Data;
using IMAS.Facade.Core;
using IMAS.UI.Controllers;
using IMAS.UI.Infrastructure.Filters.Authorization;
using IMAS.UI.Infrastructure.SignalR;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class MediaController : BaseController
    {
        public FileService FileService { get; set; }

        public MediaController()
        {
            FileService = new FileService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReadUserMedia(DataSourceRequest request)
        {
            return Json(FileService.ReadUserMediaList(request, User), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            FileService.DeleteUserMedia(id, User);
            return Json(true);
        }
    }
}