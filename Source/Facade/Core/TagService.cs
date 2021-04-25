using IMAS.Bussines.Core;
using IMAS.Security.Helper;
using System.Linq;
using System.Data.Entity;
using IMAS.Common.Data;
using IMAS.Common.Enum;
using IMAS.Common.ExtensionMethod;
using IMAS.PresentationModel.Model.Content;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using System;
using System.Collections;
using IMAS.PresentationModel.Model;
using System.Collections.Generic;
using IMAS.Mapper.Core;

namespace IMAS.Facade.Core
{
    public class TagService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        TagBiz TagBiz { get; set; }
        ArticleBiz ArticleBiz { get; set; }

        public TagService()
        {
            UnitOfWork = new CoreUnitOfWork();
            TagBiz = new TagBiz(UnitOfWork);
            ArticleBiz = new ArticleBiz(UnitOfWork);
        }

        public int ReadTotallTagsCount()
        {
            return TagBiz.Read().Count();
        }

        public int ReadTagArticlesCount(int tagId)
        {
            return ArticleBiz.ReadPublishedArticles()
                .Where(article => article.Tags.Any(tag => tag.Id == tagId))
                .Count();
        }

        public IEnumerable<TagPM> ReadTags(int pageIndex, int pageSize)
        {
            return TagBiz.Read(tag => tag.Contents.Any(content => content.State == ContentState.Published), true)
                .OrderBy(tag => tag.Text)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .MapTo<TagPM>()
                .ToList();
        }

        public TagPM ReadTag(int tagId)
        {
            return TagBiz.ReadSingle(tag => tag.Id == tagId).GetPresentationModel();
        }

        public IEnumerable<ContentInfo3PM> ReadTagContents(int tagId, int pageIndex, int pageSize)
        {
            return ArticleBiz.ReadPublishedArticles()
                .OrderByDescending(content => content.Id)
                .Where(article => article.Tags.Any(tag => tag.Id == tagId))
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .MapTo<ContentInfo3PM>()
                .ToList();
        }

    }
}
