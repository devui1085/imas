using System;
using IMAS.Common.Enum;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.JobResume;
using IMAS.PresentationModel.Model.Organization;

namespace IMAS.UI.Areas.User.ViewModels.Resume
{
    public class ResumeViewModel
    {
        public ProfileStatisticsAndSocialLinksPM ProfileStatisticsAndSocialLinks { get; set; }
        public EducationalResumePM EducationalResume { get; set; }
        public JobResumePM JobResume { get; set; }

    }
}