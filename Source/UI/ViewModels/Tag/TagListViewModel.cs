using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.ModelContainer;

namespace IMAS.UI.ViewModels.Tag
{
    public class TagListViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<TagPM> Tags { get; set; }
        public int TotallRows { get; set; }
    }
}