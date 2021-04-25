using System;

namespace IMAS.PresentationModel.Model
{
    public  class PicturePM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsMainPicture { get; set; }

        public int AdvertismentId { get; set; }

    }
}
