using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.PresentationModel.ModelContainer
{
    public class HomePageModelContainer
    {
        public IEnumerable<AdvertismentPM> LatestAdvertisments { get; set; }
    }
}
