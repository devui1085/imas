using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.ModelContainer;

namespace IMAS.UI.ViewModels.Home
{
    public class HomeViewModelTemp
    {
        public HomeViewModelTemp(VisitorHomePageModelContainer container)
        {
            TopArticles = container.TopArticles;
            FeaturedArticles = container.FeaturedArticles;
            LatestArticles = container.LatestArticles;
            TopBlogPosts = container.TopBlogPosts;
            TotalArticles = container.TotalArticles;
            TotalBlogPosts = container.TotalBlogPosts;
        }

        public IEnumerable<ContentInfo6PM> TopArticles { get; set; }
        public IEnumerable<ContentInfo6PM> FeaturedArticles { get; set; }
        public IEnumerable<ContentInfo6PM> LatestArticles{ get; set; }
        public IEnumerable<ContentInfo6PM> TopBlogPosts { get; set; }
        public int TotalArticles { get; set; }
        public int TotalBlogPosts { get; set; }
    }
}