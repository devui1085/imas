using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.ModelContainer;

namespace IMAS.UI.ViewModels.UserHomePage
{
    public class UserHomePageViewModel
    {
        public UserHomePageViewModel(UserInfoForHomePageModelContainer userHomePageModelContainer)
        {
            UserInfo = userHomePageModelContainer;
        }

        public UserInfoForHomePageModelContainer UserInfo { get; set; }
    }
}