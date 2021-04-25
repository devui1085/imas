using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class AdvertismentMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<Advertisment, AdvertismentPM>()
                .Include<Machinery, MachineryPM>();

            profile.CreateMap<Machinery, MachineryPM>()
                .Include<NormalLathe, NormalLathePM>()
                .Include<CncLathe, CncLathePM>()
                .Include<NormalCarousel, NormalCarouselPM>()
                .Include<FlatStone, FlatStonePM>()
                .Include<CncMilling, CncMillingPM>()
                .Include<ManualMilling, ManualMillingPM>()
                .Include<Drill,DrillPM>();

            profile.CreateMap<NormalLathe, NormalLathePM>();
            profile.CreateMap<CncLathe, CncLathePM>();
            profile.CreateMap<NormalCarousel, NormalCarouselPM>();
            profile.CreateMap<FlatStone, FlatStonePM>();
            profile.CreateMap<CncMilling, CncMillingPM>();
            profile.CreateMap<ManualMilling, ManualMillingPM>();
            profile.CreateMap<Drill, DrillPM>();
            /**************************************************/
            profile.CreateMap<AdvertismentPM, Advertisment>()
                .Include<MachineryPM, Machinery>();

            profile.CreateMap<MachineryPM, Machinery>()
                .Include<NormalLathePM, NormalLathe>()
                .Include<CncLathePM, CncLathe>()
                .Include<NormalCarouselPM, NormalCarousel>()
                .Include<FlatStonePM, FlatStone>()
                .Include<CncMillingPM, CncMilling>()
                .Include<ManualMillingPM,ManualMilling>()
                .Include<DrillPM,Drill>();
                
            profile.CreateMap<NormalLathePM, NormalLathe>();
            profile.CreateMap<CncLathePM, CncLathe>();
            profile.CreateMap<NormalCarouselPM, NormalCarousel>();
            profile.CreateMap<FlatStonePM, FlatStone>();
            profile.CreateMap<CncMillingPM, CncMilling>();
            profile.CreateMap<ManualMillingPM, ManualMilling>();
            profile.CreateMap<DrillPM, Drill>();
        }

        public static Advertisment ToAdvertisment(this AdvertismentPM advertismentPm)
        {
            return AutoMapper.Mapper.Map<AdvertismentPM, Advertisment>(advertismentPm);
        }

        public static AdvertismentPM ToAdvertismentPM(this Advertisment advertisment)
        {
            return AutoMapper.Mapper.Map<Advertisment, AdvertismentPM>(advertisment);
        }
    }
}
