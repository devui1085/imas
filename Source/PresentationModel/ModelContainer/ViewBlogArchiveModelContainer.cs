using System.Collections.Generic;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Archive;
using IMAS.PresentationModel.Model.Blog;

namespace IMAS.PresentationModel.ModelContainer
{
    public class ViewBlogArchiveModelContainer
    {
        public BlogInfoPM BlogInfo { get; set; }
        public List<BlogLinkPM> Links { get; set; }
        public IEnumerable<ContentInfo2PM> PostTitles { get; set; }
        public IEnumerable<ContentArchiveItemPM> ArchiveItems { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
    }
}
