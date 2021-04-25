using IMAS.Common.Enum;
using IMAS.Localization.ExtensionMethod;
using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Organization;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class EducationalResumeMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<EducationalResume, EducationalResumePM>();
            profile.CreateMap<EducationalResumePM, EducationalResume>();
        }

        public static EducationalResume GetEducationalResume(this EducationalResumePM educationalResumePM)
        {
            return AutoMapper.Mapper.Map<EducationalResumePM, EducationalResume>(educationalResumePM);
        }

        public static EducationalResumePM GetPresentationModel(this EducationalResume educationalResume)
        {
            return AutoMapper.Mapper.Map<EducationalResume, EducationalResumePM>(educationalResume);
        }
    }
}
