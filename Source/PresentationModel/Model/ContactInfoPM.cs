using System.Collections.Generic;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.Model.JobResume;
using IMAS.PresentationModel.Model.Organization;

namespace IMAS.PresentationModel.Model
{
    public class ContactInfoPM
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string WebSiteUrl { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string MobileNumber { get; set; }
        public string Tel { get; set; }
    }
}
