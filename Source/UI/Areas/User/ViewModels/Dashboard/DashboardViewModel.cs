using IMAS.PresentationModel.ModelContainer;

namespace IMAS.UI.Areas.User.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public DashboardModelContainer DashboardModelContainer { get; set; }

        public DashboardViewModel(DashboardModelContainer dashboardModelContainer)
        {
            DashboardModelContainer = dashboardModelContainer;
        }
    }
}