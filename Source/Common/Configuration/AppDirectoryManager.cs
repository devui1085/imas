using System.Configuration;
using System.IO;
using IMAS.Common.Enum;

namespace IMAS.Common.Configuration
{
    public static class AppDirectoryManager
    {
        public static string GetUserProfileImageDirectory(int userId)
        {
            return $"{AppConfigurationManager.AppDirectory}\\Users\\{userId}\\ProfileImage";
        }

        public static void CreateUserProfileImageDirectory(int userId)
        {
            var path = $"{AppConfigurationManager.AppDirectory}\\Users\\{userId}\\ProfileImage";
            Directory.CreateDirectory(path);
        }

    }
}
