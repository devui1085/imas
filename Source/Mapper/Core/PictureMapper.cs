using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Mapper.Attributes;
using IMAS.Mapper.Profile;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.Mapper.Core
{
    [ObjectMapper]
    public static class PictureMapper
    {
        public static void CreateMap(AutoMapperProfile profile)
        {
            profile.CreateMap<Picture, PicturePM>();
            profile.CreateMap<PicturePM, Picture>();
        }

        public static Picture ToPicture(this PicturePM picturePm)
        {
            return AutoMapper.Mapper.Map<PicturePM, Picture>(picturePm);
        }

        public static PicturePM ToPicturePM(this Picture picture)
        {
            return AutoMapper.Mapper.Map<Picture, PicturePM>(picture);
        }

        public static List<Picture> ToPictureList(this List<PicturePM> picturePmList)
        {
            return AutoMapper.Mapper.Map<List<PicturePM>, List<Picture>>(picturePmList);
        }

        public static List<PicturePM> ToPicturePMList(this List<Picture> pictureList)
        {
            return AutoMapper.Mapper.Map<List<Picture>, List<PicturePM>>(pictureList);
        }
    }
}
