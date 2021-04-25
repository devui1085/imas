using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.PresentationModel.ModelContainer
{
    public class AdminDashboardModelContainer
    { 
        public int TotalUsersCount { get; set; }
        public int TotalAdvertismentCount { get; set; }
        public int TotalActiveAdvertismentCount { get; set; }
        public int TodayVisitsCount { get; set; }
        public IEnumerable<AdminDashboardNewUserPm> NewUsers { get; set; }
        public IEnumerable<AdvertismentPM> NewAdvertisments { get; set; }
    }
}
