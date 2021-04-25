using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using IMAS.Common.Enum;
using IMAS.Localization;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model.Blog
{
    public class ShortBlogInfoPM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
    }
}
