using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using System;
using System.Data.Entity;
using System.Linq;
using IMAS.Common.Enum;

namespace IMAS.Bussines.Core
{
    public class FeaturedContentBiz : BizBase<Follow>
    {
        public FeaturedContentBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public IQueryable<Content> ReadFeaturedArticles()
        {
            return UnitOfWork.FeaturedContentRepository
                .AsQueryable()
                .Select(featuredContent => featuredContent.Content)
                .Where(content => content.State == ContentState.Published);
        }
    }
}