using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;

namespace IMAS.Bussines.Core
{
    public class BlogLinkBiz : BizBase<BlogLink>
    {
        public BlogLinkBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }
    }
}