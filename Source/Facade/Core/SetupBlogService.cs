using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using IMAS.Bussines.Core;
using IMAS.Common.Data;
using IMAS.Common.DataProvider;
using IMAS.Common.ExtensionMethod;
using IMAS.Common.Globalization;
using IMAS.Common.Enum;
using IMAS.Mapper.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.ModelContainer;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using IMAS.PresentationModel.Model.SetupBlog;
using IMAS.PresentationModel.Model.Blog;

namespace IMAS.Facade.Core
{
    public class SetupBlogService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        BlogBiz BlogBiz { get; set; }
        TagBiz TagBiz { get; set; }

        public SetupBlogService()
        {
            UnitOfWork = new CoreUnitOfWork();
            BlogBiz = new BlogBiz(UnitOfWork);
            TagBiz = new TagBiz(UnitOfWork);
        }

        public BlogGeneralSettingsPM ReadBlogGeneralSettings(int blogId)
        {
            return BlogBiz.ReadSingle(b => b.Id == blogId).GetGeneralSettingsPM();
        }

        public void UpdateBlogGeneralSettings(int blogId, BlogGeneralSettingsPM generalSettings)
        {
            var blog = BlogBiz.ReadSingle(b => b.Id == blogId);
            var updatedBlog = generalSettings.GetBlog();
            blog.Title = updatedBlog.Title;
            blog.Description = updatedBlog.Description;
            blog.Email = updatedBlog.Email;
            UnitOfWork.SaveChanges();
        }

        public int CreateBlog(UserIdentity UserIdentity, BlogGeneralSettingsPM blogRegisterationPM)
        {
            var blog = blogRegisterationPM.GetBlog();
            blog.CreatorId = UserIdentity.UserId;
            BlogBiz.CreateBlog(blog);
            UnitOfWork.SaveChanges();

            UserIdentity.HasBlog = true;
            UserIdentity.Blogs.Add(new ShortBlogInfoPM() {
                Id = blog.Id,
                Name = blog.Name,
                Title = blog.Title
            });
            return blog.Id;
        }
    }
}
