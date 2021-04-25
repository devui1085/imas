using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Business;

namespace IMAS.PresentationModel.ModelContainer
{
    public class ViewArticleModelContainer
    {
        public ContentForViewByVisitorPM Article { set; get; }
        public ProfileForViewByVisitorPM AuthorProfile { set; get; }
        public List<CommentInfoPM> Comments { set; get; }
        public List<TagPM> Tags { set; get; }
        public List<ContentInfo4PM> UserRelatedArticles { get; set; }
        public List<ContentInfo4PM> RelatedArticles { get; set; }
        public List<ContentInfo4PM> TopArticles { get; set; }
        public BusinessIntroducePM AuthorBusinessIntroduce { get; set; }

    }
}
