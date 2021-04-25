using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using System;
using System.Data.Entity;
using System.Linq;

namespace IMAS.Bussines.Core
{
    public class EducationalResumeBiz : BizBase<EducationalResume>
    {
        public EducationalResumeBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public IQueryable<EducationalResume> ReadUserEducationalResumes(int userId)
        {
            return Read(x => x.UserId == userId)
                .OrderByDescending(x => x.EducationGrade);
        }
    }
}