using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.ModelContainer;

namespace IMAS.UI.ViewModels.Tag
{
    public class TagContentsViewModel
    {
        public TagPM Tag { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<ContentInfo3PM> Articles { get; set; }
        public int TotalRows { get; set; }
    }
}