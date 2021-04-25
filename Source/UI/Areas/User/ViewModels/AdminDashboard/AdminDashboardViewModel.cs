using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.ModelContainer;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.UI.Areas.User.ViewModels.AdminDashboard
{
    public class AdminDashboardViewModel
    {
        public AdminDashboardViewModel(AdminDashboardModelContainer container)
        {
            TotalUsersCount = container.TotalUsersCount;
            TotalAdvertismentCount = container.TotalAdvertismentCount;
            TotalActiveAdvertismentCount = container.TotalActiveAdvertismentCount;
            TodayVisitsCount = container.TodayVisitsCount;
            NewAdvertisments = container.NewAdvertisments;
            NewUsers = container.NewUsers;
        }

        public int TotalUsersCount { get; set; }
        public int TotalAdvertismentCount { get; set; }
        public int TotalActiveAdvertismentCount { get; set; }
        public int TodayVisitsCount { get; set; }

        public IEnumerable<AdminDashboardNewUserPm> NewUsers { get; set; }
        public IEnumerable<AdvertismentPM> NewAdvertisments { get; set; }
    }
}