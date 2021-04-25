using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;

namespace IMAS.Bussines.Core
{
    public class TagBiz : BizBase<Tag>
    {
        public TagBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }
    }
}