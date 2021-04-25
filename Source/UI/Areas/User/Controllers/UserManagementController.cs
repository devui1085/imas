//using System.Web.Mvc;
//using IMAS.UI.Areas.User.Models.Profile;
//using IMAS.UI.Controllers;
//using System.Linq;
//using System.Web;
//using System.Drawing;
//using System.Drawing.Imaging;
//using Common.Security;
//using IMAS.UI.Areas.User.Models.UserManagement;
//using IMAS.UI.Security;

//namespace IMAS.UI.Areas.User.Controllers
//{
//    //[CustomAuthorize(Roles="Admin")]
//    public class UserManagementController : BaseController
//    {
//        public ActionResult Index()
//        {
//            var model = new UserManagementViewModel();
//            model.Users = UserManager.ReadUsers();
//            model.TotalUsersCount = model.Users.Count();
//            return View(model);
//        }

//        public ActionResult Edit(int id)
//        {
//            var user = UserManager.ReadUser(id);
//            var userRoles = user.Roles.ToList();
//            var viewModel = new EditUserViewModel(user);
//            viewModel.IsLockedOut = user.Membership.IsLockedOut;
//            viewModel.UserHasAdminRole = userRoles.Any(e => e.Name == "Admin");
//            viewModel.UserHasSuperUserRole = userRoles.Any(e => e.Name == "SuperUser");
//            return PartialView(viewModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(EditUserViewModel viewModel)
//        {
//            //if (!ModelState.IsValid)
//            //    return RedirectToAction("Index");

//            //var user = UserManager.ReadUser(viewModel.UserId);
//            //viewModel.CopyToUser(user);

//            //if (!string.IsNullOrWhiteSpace(viewModel.NewPassword))
//            //    user.Membership.Password = SecurityHelper.ComputeSha256Hash(viewModel.NewPassword);
            
//            //// Set user roles
//            //user.Roles.Remove(Repository.AsQueryable<IMAS.Model.Entity.Membership.Role>().Single(e => e.Name == "Admin"));
//            //user.Roles.Remove(Repository.AsQueryable<IMAS.Model.Entity.Membership.Role>().Single(e => e.Name == "SuperUser"));
//            //Repository.SaveChanges();

//            //if (viewModel.UserHasAdminRole)
//            //    Repository.AsQueryable<IMAS.Model.Entity.Membership.Role>().Single(e => e.Name == "Admin").Users.Add(user);
//            //if (viewModel.UserHasSuperUserRole)
//            //    Repository.AsQueryable<IMAS.Model.Entity.Membership.Role>().Single(e => e.Name == "SuperUser").Users.Add(user);
//            //Repository.SaveChanges();

//            return RedirectToAction("Index");
//        }

//    }
//}
