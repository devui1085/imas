using System.Collections.Generic;
using IMAS.PresentationModel.Model.Archive;
using IMAS.PresentationModel.Model.Blog;
using IMAS.PresentationModel.Model.Content;
using IMAS.UI.ViewModels.Publication;

namespace IMAS.UI.ViewModels.Blog
{
    public class BlogPageViewModelBase : PublicationViewModelBase
    {
        public string BlogDescription { get; set; }
        public string BlogEmail { get; set; }
        public IEnumerable<ContentInfoWithTextPM> BlogLatestPosts { get; set; }
        public IEnumerable<BlogLinkPM> BlogLinks { get; set; }
        public IEnumerable<ContentArchiveItemPM> ArchiveItems { get; set; }

    }
}