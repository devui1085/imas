using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Archive;
using IMAS.PresentationModel.Model.Blog;
using IMAS.PresentationModel.Model.Content;

namespace IMAS.PresentationModel.ModelContainer
{
    public class ViewBlogPostModelContainer
    {
        public ContentInfoWithTextPM Post { set; get; }
        public List<CommentInfoPM> Comments { set; get; }
        public List<TagPM> Tags { set; get; }
        public BlogInfoPM BlogInfo { get; set; }
        public List<BlogLinkPM> Links { get; set; }
        public IEnumerable<ContentArchiveItemPM> ArchiveItems { get; set; }
        public IEnumerable<ContentInfoWithTextPM> LatestPosts { get; set; }

    }
}
