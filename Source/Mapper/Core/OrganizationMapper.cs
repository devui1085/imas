using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Organization;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class OrganizationMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<Organization, OrganizationPM>();
            profile.CreateMap<OrganizationPM, Organization>();
        }

        public static Organization GetOrganization(this OrganizationPM organizationPM)
        {
            return AutoMapper.Mapper.Map<OrganizationPM, Organization>(organizationPM);
        }

        public static OrganizationPM GetPresentationModel(this Organization organization)
        {
            return AutoMapper.Mapper.Map<Organization, OrganizationPM>(organization);
        }
    }
}
