using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using IMAS.Common.Drawing;
using IMAS.Common.Configuration;
using IMAS.DataAccess;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.Mapper.Core;
using IMAS.PresentationModel.Model.Job;
using IMAS.PresentationModel.Model.Advertisment;



namespace IMAS.Test
{
    [TestClass]
    public class Tool
    {
        [TestMethod]
        public void CreateThumbnails()
        {
            IMASModel c = new IMASModel();
            var dir = AppConfigurationManager.GetUserMediaDirectory();

            c.Media.ToList().ForEach(m => {
                var path = $"z:\\public_html\\usermedia\\{m.FileName}";

            });
        }


        [TestMethod]
        public void MapPicture()
        {
            TestMapping();
        }

        private void TestMapping()
        {
            //JobPM j = new JobPM();

            //PicturePM pm = new PicturePM();

            //var p = j.GetJob();
            PicturePM ad = new PicturePM() { Name ="thisn ame"};
            var p = ad.ToPicture();
        }
    }
}
