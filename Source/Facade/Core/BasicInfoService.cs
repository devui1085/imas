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
using IMAS.PresentationModel.Model.Organization;
using Common.Exception;
using IMAS.PresentationModel.Model.UniversityField;
using IMAS.PresentationModel.Model.Job;

namespace IMAS.Facade.Core
{
    public class BasicInfoService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        OrganizationBiz OrganizationBiz { get; set; }
        UniversityFieldBiz UniversityFieldBiz { get; set; }
        JobBiz JobBiz { get; set; }

        public BasicInfoService()
        {
            UnitOfWork = new CoreUnitOfWork();
            OrganizationBiz = new OrganizationBiz(UnitOfWork);
            UniversityFieldBiz = new UniversityFieldBiz(UnitOfWork);
            JobBiz = new JobBiz(UnitOfWork);
        }

        public IEnumerable<OrganizationPM> SuggestOrganization(string phrase, OrganizationType orgType)
        {
            return OrganizationBiz.SuggestOrganization(phrase, orgType)
                .MapTo<OrganizationPM>()
                .ToList();
        }

        public IEnumerable<UniversityFieldPM> SuggestUniversityFieldName(string phrase)
        {
            return UniversityFieldBiz.SuggestUniversityField(phrase)
                .MapTo<UniversityFieldPM>()
                .ToList();
        }

        public IEnumerable<JobPM> SuggestJob(string phrase)
        {
            return JobBiz.SuggestJob(phrase)
                .MapTo<JobPM>()
                .ToList();
        }
    }
}
