using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Blog;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.ModelContainer;
using IMAS.PresentationModel.ModelContainer.Blog;

namespace IMAS.UI.ViewModels.Blog
{
    public class BlogPostViewModel : BlogPageViewModelBase
    {
        public ContentInfoWithTextPM Post { set; get; }
        public List<CommentInfoPM> Comments { set; get; }
        public List<TagPM> Tags { set; get; }
        public bool PreviewMode { get; set; }

        public BlogPostViewModel(ViewBlogPostModelContainer container, bool previewMode)
        {
            Post = container.Post;
            Comments = container.Comments ?? new List<CommentInfoPM>();
            Tags = container.Tags ?? new List<TagPM>();
            BlogLinks = container.Links ?? new List<BlogLinkPM>();
            PreviewMode = previewMode;
            PublicationId = container.BlogInfo.Id;
            CreatorFirstName = container.BlogInfo.CreatorFirstName;
            CreatorId = container.BlogInfo.CreatorId;
            BlogDescription = container.BlogInfo.Description;
            BlogEmail = container.BlogInfo.Email;
            Name = container.BlogInfo.Name;
            Title = container.BlogInfo.Title;
            ArchiveItems = container.ArchiveItems;
            BlogLatestPosts = container.LatestPosts;
        }
    }
}