using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using System;
using System.Data.Entity;
using System.Linq;

namespace IMAS.Bussines.Core
{
    public class UniversityFieldBiz : BizBase<UniversityField>
    {
        public UniversityFieldBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public UniversityField AddIfNotExist(string universityFieldName)
        {
            universityFieldName = universityFieldName.Trim();
            var universityField = ReadSingleOrDefault(u => u.Name == universityFieldName);
            if (universityField != null) return universityField;
            return Add(new UniversityField() {
                Name = universityFieldName,
            });
        }

        public IQueryable<UniversityField> SuggestUniversityField(string phrase)
        {
            return UnitOfWork.UniversityFieldRepository
                .Read(x => x.Name.Contains(phrase))
                .Take(5);
        }
    }
}