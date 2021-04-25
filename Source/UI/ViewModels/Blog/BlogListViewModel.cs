using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Blog;
using IMAS.PresentationModel.ModelContainer;

namespace IMAS.UI.ViewModels.Tag
{
    public class BlogListViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<BlogInfoForGenerateLinkPM> Blogs { get; set; }
        public int TotallRows { get; set; }
    }
}