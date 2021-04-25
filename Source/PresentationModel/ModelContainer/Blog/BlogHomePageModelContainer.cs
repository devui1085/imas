using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Archive;
using IMAS.PresentationModel.Model.Blog;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.Model.SetupBlog;

namespace IMAS.PresentationModel.ModelContainer.Blog
{
    public class BlogHomePageModelContainer
    {
        public BlogInfoPM BlogInfo { get; set; }
        public IEnumerable<ContentInfoWithTextPM> LatestPosts { get; set; }
        public IEnumerable<BlogLinkPM> Links { get; set; }
        public IEnumerable<ContentArchiveItemPM> ArchiveItems { get; set; }
    }
}
