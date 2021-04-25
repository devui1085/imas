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
using IMAS.PresentationModel.Model.JobResume;

namespace IMAS.Facade.Core
{
    public class UserResumeService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        OrganizationBiz OrganizationBiz { get; set; }
        UniversityFieldBiz UniversityFieldBiz { get; set; }
        EducationalResumeBiz EducationalResumeBiz { get; set; }
        JobResumeBiz JobResumeBiz { get; set; }
        JobBiz JobBiz { get; set; }

        public UserResumeService()
        {
            UnitOfWork = new CoreUnitOfWork();
            OrganizationBiz = new OrganizationBiz(UnitOfWork);
            UniversityFieldBiz = new UniversityFieldBiz(UnitOfWork);
            EducationalResumeBiz = new EducationalResumeBiz(UnitOfWork);
            JobResumeBiz = new JobResumeBiz(UnitOfWork);
            JobBiz = new JobBiz(UnitOfWork);
        }

        #region Educational Resume
        public DataSourceResult ReadUserEducationalResumes(int userId, DataSourceRequest request)
        {
            return EducationalResumeBiz.Read(r => r.UserId == userId)
                .OrderByDescending(resume => resume.EducationGrade)
                .MapTo<EducationalResumePM>()
                .ToDataSourceResult(request);
        }

        public void AddEducationalResume(UserIdentity userIdentity, EducationalResumePM educationalResumePM)
        {
            var resume = educationalResumePM.GetEducationalResume();
            if ((resume.StartYear.HasValue && resume.EndYear.HasValue && resume.StartYear > resume.EndYear) ||
                (!resume.StartYear.HasValue || resume.EndYear.HasValue))
                resume.StartYear = resume.EndYear = null;
            resume.UserId = userIdentity.UserId;
            resume.Organization = OrganizationBiz.AddOrganizationIfNotExist(educationalResumePM.OrganizationName, OrganizationType.University);
            resume.UniversityField = UniversityFieldBiz.AddIfNotExist(educationalResumePM.UniversityFieldName);
            EducationalResumeBiz.Add(resume);
            UnitOfWork.SaveChanges();
        }

        public void DeleteEducationalResume(UserIdentity user, int id)
        {
            var resume = EducationalResumeBiz.Find(id);
            if (resume.UserId != user.UserId)
                throw new BusinessException();
            EducationalResumeBiz.Remove(resume);
            UnitOfWork.SaveChanges();
        }
        #endregion

        #region Job Resume
        public DataSourceResult ReadUserJobResumes(int userId, DataSourceRequest request)
        {
            return JobResumeBiz.Read(r => r.UserId == userId)
                .OrderByDescending(resume => resume.StartYear)
                .MapTo<JobResumePM>()
                .ToDataSourceResult(request);
        }

        public void AddJobResume(UserIdentity userIdentity, JobResumePM jobResumePM)
        {
            var resume = jobResumePM.GetJobResume();
            if ((resume.StartYear.HasValue && resume.EndYear.HasValue && resume.StartYear > resume.EndYear) ||
                (!resume.StartYear.HasValue || resume.EndYear.HasValue))
                resume.StartYear = resume.EndYear = null;
            resume.UserId = userIdentity.UserId;
            resume.Organization = OrganizationBiz.AddOrganizationIfNotExist(jobResumePM.OrganizationName, OrganizationType.Company);
            resume.Job = JobBiz.AddJobIfNotExist(jobResumePM.JobName);
            JobResumeBiz.Add(resume);
            UnitOfWork.SaveChanges();
        }

        public void DeleteJobResume(UserIdentity user, int id)
        {
            var resume = JobResumeBiz.Find(id);
            if (resume.UserId != user.UserId)
                throw new BusinessException();
            JobResumeBiz.Remove(resume);
            UnitOfWork.SaveChanges();
        }
        #endregion

    }
}
