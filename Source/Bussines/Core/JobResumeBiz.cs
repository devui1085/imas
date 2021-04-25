using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using System;
using System.Data.Entity;
using System.Linq;

namespace IMAS.Bussines.Core
{
    public class JobResumeBiz : BizBase<JobResume>
    {
        public JobResumeBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }
    }
}