using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;

namespace IMAS.PresentationModel.ModelContainer
{
    public class DashboardModelContainer
    {
        public int TotalAdvertismentCount { get; set; }
        public int ActiveAdvertismentCount { get; set; }
        public int TodayTotallVisits { get; set; }
        public bool UserIsApproved { get; set; }
    }
}
