using IMAS.Common.Converter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace IMAS.UI.Classes
{
    public static class PictureManager
    {
        private static string basePath;
        private static string mainPath;
        private static string pic100x100Path;
        private static string pic400x250Path;
        static PictureManager()
        {
            basePath = HttpContext.Current.Server.MapPath("/AdImages");//ConfigurationManager.AppSettings["ImageUploadPath"];
            mainPath = Path.Combine(basePath,"Main");
            pic100x100Path = Path.Combine(basePath, "Pic100x100");
            pic400x250Path = Path.Combine(basePath, "Pic400x250");

            Directory.CreateDirectory(mainPath);
            Directory.CreateDirectory(pic400x250Path);
            Directory.CreateDirectory(pic100x100Path);
        }
        public static void SavePicture(HttpPostedFileBase picture, string name)
        {
            byte[] pictureByteArray = new byte[picture.ContentLength];
            picture.InputStream.Read(pictureByteArray, 0, picture.ContentLength);

            var image = ImageConvertor.ResizeByteArrayImage(pictureByteArray, 1024);
            var pic100x100 = ImageConvertor.ResizeByteArrayImage(pictureByteArray, 100, 100);
            var pic400x250 = ImageConvertor.ResizeByteArrayImage(pictureByteArray,400, 250);

            SavePicture(image,name, mainPath);
            SavePicture(pic100x100, name, pic100x100Path);
            SavePicture(pic400x250,name, pic400x250Path);
        }

        private static void SavePicture(byte[] picture, string name, string destination)
        {
            using (Image image = Image.FromStream(new MemoryStream(picture)))
            {
                image.Save(Path.Combine(destination, name + ".png"), ImageFormat.Png);  // Or Png
            }
        }

        public static void RemovePicture(string name)
        {
            File.Delete(Path.Combine(mainPath, name) + ".png");
            File.Delete(Path.Combine(pic100x100Path, name) + ".png");
            File.Delete(Path.Combine(pic400x250Path, name) + ".png");
        }
    }
}