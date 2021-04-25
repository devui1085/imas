using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using IMAS.Common.Enum;
using IMAS.Localization;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model.Blog
{
    public class BlogLinkPM
    {
        public int Id { get; set; }

        [RequiredField]
        [LocalizedName]
        [StringLengthRange(1, 50)]
        public string Name { get; set; }

        [RequiredField]
        [LocalizedName]
        [StringLengthRange(1, 200)]
        //[Url(ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(Resources))]
        public string Url { get; set; }
    }
}
