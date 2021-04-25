using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Common.Exception;
using Common.Web.Mvc;
using IMAS.Common.Enum;
using IMAS.Facade.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;
using IMAS.UI.Areas.User.ViewModels.Advertisment;
using IMAS.UI.Areas.User.ViewModels.Article;
using IMAS.UI.Controllers;
using IMAS.Localization.ExtensionMethod;
using IMAS.UI.Classes;
using System.Reflection;
using IMAS.Common.Data;
using IMAS.UI.Infrastructure.Filters.Authorization;

namespace IMAS.UI.Areas.User.Controllers
{
    [AuthorizeUser]
    public class AdvertismentController : BaseController
    {

        public AdvertismentService AdvertismentService { get; }
        public AdvertismentController()
        {
            AdvertismentService = new AdvertismentService();
        }

        public AdvertismentPM CreateAdvertisment(string machinary)
        {
            AdvertismentPM advertisment = null;
            switch (machinary.ToLower())
            {
                case "machinery":
                    advertisment = new MachineryPM();
                    break;
                case "normallathe":
                    advertisment = new NormalLathePM();
                    break;
                case "cnclathe":
                    advertisment = new CncLathePM();
                    break;
                case "normalcarousel":
                    advertisment = new NormalCarouselPM();
                    break;
                case "flatstone":
                    advertisment = new FlatStonePM();
                    break;
                case "cncmilling":
                    advertisment = new CncMillingPM();
                    break;
                case "manualmilling":
                    advertisment = new ManualMillingPM();
                    break;
                case "drill":
                    advertisment = new DrillPM();
                    break;
            }
            return advertisment;
        }
        [HttpGet]
        public ActionResult Add(string machinary)
        {
            if (machinary == null) return View();
            var viewModel = new AdvertismentViewModel()
            {
                Advertisment = CreateAdvertisment(machinary),
                PageMode = PageMode.Add
            };
            return View($"EditAdvertisment", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "BadRequest");
            var advertisment = AdvertismentService.GetAdvertisment(User, id.Value);
            var viewModel = new AdvertismentViewModel() { Advertisment = advertisment , PageMode = PageMode.Edit };
            return View($"EditAdvertisment", viewModel);
        }

        #region save action methods
        [HttpPost]
        public ActionResult Save(AdvertismentViewModel viewModel)
        {
            var advertisment = CreateAdvertisment(viewModel.AdvertismentTypeName);
            TryUpdateModelWithType(advertisment);

            if (advertisment.UserId == 0)
                advertisment.UserId = User.UserId;

            if (viewModel.PageMode == PageMode.Edit)
            {
                AdvertismentService.UpdateAdvertisment(advertisment);
            }
            else
            {
                AdvertismentService.AddAdvertisment(advertisment);
            }

            return Json(new ProcessResult(new { AdvertismentId = advertisment.Id }));
        }
        public bool TryUpdateModelWithType(object model, string prefix = null,
                                           string[] includeProperties = null, string[] excludeProperties = null,
                                           IValueProvider valueProvider = null)
        {
            if (model == null) return false;

            var methodInfo = GetType()
                .GetMethods(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "TryUpdateModel" && x.GetParameters().Count() == 5)
                .MakeGenericMethod(new[] { model.GetType() });

            return (bool)methodInfo.Invoke(this, new[] { model, prefix, includeProperties, excludeProperties, valueProvider ?? ValueProvider });
        }
        #endregion
        [HttpPost]
        public ActionResult Delete(IEnumerable<int> ids)
        {
            // ContentService.ChangeContentsState(ids, ContentState.Trashed, User);
            return Json(true);
        }


        [HttpPost]
        public JsonResult UplodMultiple(HttpPostedFileBase[] uploadedFiles, int advertismentId)
        {
            if (uploadedFiles != null && uploadedFiles.Length > 0)
            {
                var advertisment = AdvertismentService.GetAdvertisment(User, advertismentId);

                if (advertisment == null)
                    throw new ServerException("IllegalInput".Localize());


                List<PicturePM> newPictureList = new List<PicturePM>();
                Dictionary<string, HttpPostedFileBase> fileListToSave = new Dictionary<string, HttpPostedFileBase>();
                foreach (var file in uploadedFiles)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        PicturePM newPicture = new PicturePM();
                        newPicture.Name = Guid.NewGuid().ToString();
                        newPicture.AdvertismentId = advertismentId;
                        newPictureList.Add(newPicture);
                        fileListToSave.Add(newPicture.Name, file);
                        // PictureManager.SavePicture(file, newPicture.Name);
                    }
                }
                AdvertismentService.SavePictures(newPictureList);

                //save files on disk
                foreach (var file in fileListToSave)
                {
                    PictureManager.SavePicture(file.Value, file.Key);
                }


                var pictureList = AdvertismentService.GetPictures(advertismentId);
                return Json(new
                {
                    statusCode = 200,
                    status = "success",
                    pictures = pictureList,
                    uploadedCount = uploadedFiles.Length
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    statusCode = 201,
                    status = "success",
                });
            }
        }

        [HttpDelete]
        public ActionResult RemovePicture(string name, int advertismentId)
        {
            var advertisment = AdvertismentService.GetAdvertisment(User, advertismentId);

            if (advertisment == null)
                throw new ServerException("IllegalInput".Localize());

            AdvertismentService.RemovePicture(advertisment.Id, name);
            PictureManager.RemovePicture(name);
            return Json(new { }, JsonRequestBehavior.DenyGet);
        }

        [HttpGet]
        public ActionResult ActiveAdvertisments()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetActiveAdvertisment(DataSourceRequest request)
        {
            return Json(AdvertismentService.GetActiveAdvertisments(User, request), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAdvertismentPictures(int advertismentId)
        {
            var pictureList = AdvertismentService.GetPictures(advertismentId);
            return Json(new
            {
                statusCode = 200,
                status = "success",
                pictures = pictureList,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}