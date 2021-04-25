using System;
using System.Collections.Generic;
using IMAS.Common.Globalization;

namespace IMAS.PresentationModel.Model
{
    public class ContentInfo2PM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateString => CreateDate.ToPersianDate();
    }
}
