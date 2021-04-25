using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model.JobResume;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class JobResumeMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<JobResume, JobResumePM>();
            profile.CreateMap<JobResumePM, JobResume>();
        }

        public static JobResume GetJobResume(this JobResumePM jobResumePM)
        {
            return AutoMapper.Mapper.Map<JobResumePM, JobResume>(jobResumePM);
        }

        public static JobResumePM  GetPresentationModel(this JobResume jobResume)
        {
            return AutoMapper.Mapper.Map<JobResume, JobResumePM>(jobResume);
        }
    }
}
