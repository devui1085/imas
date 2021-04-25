using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using System;
using IMAS.Common.Enum;
using System.Collections.Generic;
using IMAS.PresentationModel.Model.Organization;
using System.Linq;

namespace IMAS.Bussines.Core
{
    public class OrganizationBiz : BizBase<Organization>
    {
        public OrganizationBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public Organization AddOrganizationIfNotExist(string universityName, OrganizationType orgType)
        {
            universityName = universityName.Trim();
            var university = ReadSingleOrDefault(u => u.Name == universityName);
            if (university != null) return university;
            return Add(new Organization() {
                Type = orgType,
                Name = universityName,
            });
        }

        public IQueryable<Organization> SuggestOrganization(string phrase, OrganizationType orgType)
        {
            return UnitOfWork.OrganizationRepository
                .Read(org => org.Type == orgType &&
                      org.Name.Contains(phrase))
                .Take(5);
        }
    }
}