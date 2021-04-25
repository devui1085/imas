using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using IMAS.Bussines.Core;
using IMAS.Common.Configuration;
using IMAS.Common.Data;
using IMAS.Common.DataProvider;
using IMAS.Common.Enum;
using IMAS.Common.ExtensionMethod;
using IMAS.Common.Globalization;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Content;
using IMAS.PresentationModel.ModelContainer;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using IMAS.PresentationModel.Model.Advertisment;

namespace IMAS.Facade.Core
{
    public class AppStatisticsService
    {
        CoreUnitOfWork UnitOfWork { get; }
        ArticleBiz ArticleBiz { get; }
        BlogBiz BlogBiz { get; }
        CommentBiz CommentBiz { get; }
        VisitBiz VisitBiz { get; }
        UserBiz UserBiz { get; }
        MessageBiz MessageBiz { get; }
        FeaturedContentBiz FeaturedContentBiz { get; }
        AdvertismentBiz AdvertismentBiz { get; }
        AdvertismentVisitBiz AdvertismentVisitBiz { get; }
        MembershipBiz MembershipBiz { get; }

        public AppStatisticsService()
        {
            UnitOfWork = new CoreUnitOfWork();
            ArticleBiz = new ArticleBiz(UnitOfWork);
            BlogBiz = new BlogBiz(UnitOfWork);
            VisitBiz = new VisitBiz(UnitOfWork);
            UserBiz = new UserBiz(UnitOfWork);
            CommentBiz = new CommentBiz(UnitOfWork);
            MessageBiz = new MessageBiz(UnitOfWork);
            FeaturedContentBiz = new FeaturedContentBiz(UnitOfWork);
            AdvertismentBiz = new AdvertismentBiz(UnitOfWork);
            AdvertismentVisitBiz = new AdvertismentVisitBiz(UnitOfWork);
            MembershipBiz = new MembershipBiz(UnitOfWork);
        }

        public VisitorHomePageModelContainer ReadStatisticsForHomePage()
        {
            var topVisits = VisitBiz.Read().GroupBy(r => r.ContentId)
                .Select(group => new { ContentId = group.Key, TotalVisit = group.Sum(r => r.Count) })
                .OrderByDescending(r => r.TotalVisit)
                .Take(AppConfigurationManager.TopArticlesNumber);

            var topArticlesVisits = from a in ArticleBiz.ReadPublishedArticles()
                                    join av in topVisits
                                        on a.Id equals av.ContentId
                                    select new { a, av.TotalVisit };

            var topArticles = topArticlesVisits.OrderByDescending(t => t.TotalVisit).Select(t => t.a);

            return new VisitorHomePageModelContainer()
            {
                TopArticles =
                    topArticles.MapTo<ContentInfo6PM>()
                        .ToList(),
                LatestArticles =
                    ArticleBiz.ReadLatestArticles(AppConfigurationManager.LatestArticlesNumber)
                        .MapTo<ContentInfo6PM>()
                        .ToList(),
                FeaturedArticles = FeaturedContentBiz.ReadFeaturedArticles().MapTo<ContentInfo6PM>().ToList(),
            };
        }

        public AdminDashboardModelContainer GetAdminDashboardStatistics()
        {
            var today = DateTime.Now.Date;
            return new AdminDashboardModelContainer()
            {
                TodayVisitsCount =
                    AdvertismentVisitBiz.GetTodaySiteTotalVisitsCount(),
                TotalAdvertismentCount =
                    AdvertismentBiz.Read().Count(),
                TotalActiveAdvertismentCount =
                    AdvertismentBiz.Read(e => e.Status == AdvertismentStatus.Published).Count(),
                TotalUsersCount = UserBiz.Read(u => u.Membership.IsApproved).Count(),
                NewUsers = UserBiz.GetNewUsers(top: 3).MapTo<AdminDashboardNewUserPm>().ToList(),
                NewAdvertisments = AdvertismentBiz.GetLastestAdvertisments(0,3).MapTo<AdvertismentPM>().ToList()
            };
        }

        public IEnumerable<ChartData> GetUsersRegistrationStatisticByDate()
        {
            return UserBiz.Read(u => true, true).GroupBy(u => DbFunctions.TruncateTime(u.Membership.CreateDate))
                .Select(group => new ChartData { Date = group.Key.Value, Value = group.Count() })
                .OrderBy(u => u.Date);
        }

        public IEnumerable<ChartData> GetAdvertismentStatisticChartData()
        {
            return AdvertismentBiz.Read(e => e.Status == AdvertismentStatus.Published, true).GroupBy(c => DbFunctions.TruncateTime(c.RegisterDate))
                .Select(group => new ChartData { Date = group.Key.Value, Value = group.Count() })
                .OrderBy(a => a.Date);
        }

        public IEnumerable<ChartData> GetUserAdvertismentsStatisticChartData(UserIdentity user)
        {
            return AdvertismentVisitBiz.Read(v => v.Advertisment.UserId == user.UserId, true).GroupBy(v => DbFunctions.TruncateTime(v.Date))
                    .Select(group => new ChartData { Date = group.Key.Value, Value = group.Sum(visit => visit.Count) })
                    .OrderBy(v => v.Date);
        }
        public IEnumerable<ChartData> GetBlogPostPublishStatisticByDate()
        {
            return ArticleBiz.Read(c => c.State == ContentState.Published && c.Type == ContentType.BlogPost, true).GroupBy(c => DbFunctions.TruncateTime(c.CreateDate))
                .Select(group => new ChartData { Date = group.Key.Value, Value = group.Count() })
                .OrderBy(p => p.Date);
        }

        public IEnumerable<ChartData> GetSiteTotalVisistsByDate()
        {
            return AdvertismentVisitBiz.Read(v => true, true).GroupBy(v => DbFunctions.TruncateTime(v.Date))
                .Select(group => new ChartData { Date = group.Key.Value, Value = group.Sum(visit => visit.Count) })
                .OrderBy(v => v.Date);
        }

        public IEnumerable<ChartData> GetAuthorTotalVisitsChartData(UserIdentity user)
        {
            return VisitBiz.Read(v => v.Content.AuthorId == user.UserId, true).GroupBy(v => DbFunctions.TruncateTime(v.Date))
                .Select(group => new ChartData { Date = group.Key.Value, Value = group.Sum(visit => visit.Count) })
                .OrderBy(v => v.Date);

        }

        public IEnumerable<ChartData> GetAuthorTotalArticlesVisitsChartData(UserIdentity user)
        {
            return VisitBiz.Read(v => v.Content.AuthorId == user.UserId && v.Content.Type == ContentType.Article, true).GroupBy(v => DbFunctions.TruncateTime(v.Date))
                      .Select(group => new ChartData { Date = group.Key.Value, Value = group.Sum(visit => visit.Count) })
                      .OrderBy(v => v.Date);
        }

        public IEnumerable<ChartData> GetAuthorTotalBlogPostsChartData(UserIdentity user)
        {
            return VisitBiz.Read(v => v.Content.AuthorId == user.UserId && v.Content.Type == ContentType.BlogPost, true).GroupBy(v => DbFunctions.TruncateTime(v.Date))
              .Select(group => new ChartData { Date = group.Key.Value, Value = group.Sum(visit => visit.Count) })
              .OrderBy(v => v.Date);
        }

        public DashboardModelContainer GetUserDashboardData(int userId)
        {
            return new DashboardModelContainer()
            {
                TotalAdvertismentCount = AdvertismentBiz.Read(e => e.UserId == userId).Count(),
                ActiveAdvertismentCount = AdvertismentBiz.Read(e => e.UserId == userId && e.Status == AdvertismentStatus.Published).Count(),
                TodayTotallVisits = AdvertismentVisitBiz.GetUserAdvertismentsTodayTotalVisits(userId),
                UserIsApproved = MembershipBiz.IsUserApproved(userId)
            };
        }

        public IEnumerable<KeyValuePair<string, int>> GetContentVisitChartDataForUserDashboard(int userId, ContentType contentType)
        {
            var chartData = VisitBiz.GetContentVisitChartDataForUserDashboard(userId, contentType);
            ChartDataHelper.FillBlankDays<ChartData>(chartData);
            return chartData.Select(data => new KeyValuePair<string, int>(data.Date.ToPersianDate("MMDD"), data.Value));
        }

        public IQueryable<Advertisment> ReadLatestAdvertisment(int count)
        {
            return AdvertismentBiz.Read()
                .OrderByDescending(e => e.RegisterDate)
                .Take(count);
        }
    }
}
