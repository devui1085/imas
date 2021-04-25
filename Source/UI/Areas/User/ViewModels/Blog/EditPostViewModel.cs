using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IMAS.PresentationModel.Model;

namespace IMAS.UI.Areas.User.ViewModels.Blog
{
    public class EditPostViewModel
    {
        public ContentRegistrationPM Content { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public int Length { get; set; }
    }
}