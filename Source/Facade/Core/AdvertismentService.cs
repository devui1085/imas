using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Bussines.Core;
using IMAS.Common.Converter;
using IMAS.Common.Data;
using IMAS.Common.Enum;
using IMAS.Mapper.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using IMAS.Common.ExtensionMethod;
using IMAS.Common.Globalization;
using IMAS.Common.DataProvider;
using IMAS.Model.Domain.Core;

namespace IMAS.Facade.Core
{
   public class AdvertismentService
    {
        AdvertismentBiz AdvertismentBiz { get; }
        PictureBiz PictureBiz { get; }
        AdvertismentVisitBiz AdvertismentVisitBiz { get; }
        CoreUnitOfWork UnitOfWork { get; }
        public AdvertismentService()
        {
            UnitOfWork = new CoreUnitOfWork();
            AdvertismentBiz = new AdvertismentBiz(UnitOfWork);
            PictureBiz = new PictureBiz(UnitOfWork);
            AdvertismentVisitBiz = new AdvertismentVisitBiz(UnitOfWork);
        }

        public AdvertismentPM GetAdvertisment(UserIdentity userIdentity, int advertismentId)
        {
            return AdvertismentBiz.Read(a => a.Id == advertismentId
                                             && a.UserId == userIdentity.UserId).SingleOrDefault().ToAdvertismentPM();
        }

        public AdvertismentPM GetAdvertisment(int advertismentId)
        {
            return AdvertismentBiz.Read(a => a.Id == advertismentId).SingleOrDefault().ToAdvertismentPM();
        }
        public int GetAdvertismentTotalVisits(int advertismentId)
        {
            try
            {
                return AdvertismentVisitBiz.Read(e => e.AdvertismentId == advertismentId).Sum(e => e.Count);
            }
            catch(InvalidOperationException ex)
            {
                return 0;
            }
        }
        public DataSourceResult GetAllAdvertisments(DataSourceRequest request,AdvertismentFilter filter)
        {
            var result = AdvertismentBiz.Read(e => (e.Status & filter.Status) == e.Status).OrderByDescending(e => e.RegisterDate).MapTo<AdvertismentPM>().ToDataSourceResult(request);
            return result;   
        }

        private readonly object updateVisitCountLock = new object();
        public void IncreaseAdvertismentVisitCount(int advertismentId)
        {
            lock (updateVisitCountLock)
            {
                AdvertismentVisitBiz.IncrementVisitsCount(advertismentId);
                UnitOfWork.SaveChanges();
            }
        }

        public IEnumerable<KeyValuePair<string, int>> GetAdvertismentVisitChartData(int advertismentId)
        {
            var chartData = AdvertismentVisitBiz.GetAdvertismentVisitChartData(advertismentId);
            ChartDataHelper.FillBlankDays<ChartData>(chartData);
            return chartData.Select(data => new KeyValuePair<string, int>(data.Date.ToPersianDate("MMDD"), data.Value));
        }

        public int GetUserAdvertismentsTodayTotalVisits(int userId)
        {
            return AdvertismentVisitBiz.GetUserAdvertismentsTodayTotalVisits(userId);
        }

        public IEnumerable<AdvertismentPM> GetLatestAdvertisments(int startIndex,int count)
        {
            var advertisments = AdvertismentBiz.GetLastestAdvertisments(startIndex,count).Include(e => e.Pictures);

            return from a in advertisments
                    select new AdvertismentPM
                    {
                        FistImageName = (a.Pictures.FirstOrDefault()).Name,
                        Comment = a.Comment,
                        Price = a.Price,
                        RegisterDate = a.RegisterDate,
                        Title = a.Title,
                        Id = a.Id
                    };
        }

        public IEnumerable<AdvertismentPM> GetAdvertisments(int pageIndex, int pageSize)
        {
            return AdvertismentBiz.Read(e => e.Status == AdvertismentStatus.Published)
                .OrderByDescending(e => e.RegisterDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .MapTo<AdvertismentPM>()
                .ToList();
        }

        public int GetTotalPublishedAdvertismentsCount()
        {
            return AdvertismentBiz.Read(e => e.Status == AdvertismentStatus.Published).Count();
        }
        public void AddAdvertisment(AdvertismentPM advertismentPm)
        {
            var advertisment = AdvertismentBiz.AddAdvertisment(advertismentPm.ToAdvertisment());
            UnitOfWork.SaveChanges();
            advertismentPm.Id = advertisment.Id;
        }

        public void UpdateAdvertisment(AdvertismentPM advertismentPm)
        {
            var advertisment = advertismentPm.ToAdvertisment();
            AdvertismentBiz.ValidateAndUpdate(advertisment);
            UnitOfWork.SaveChanges();
        }

        public void SavePictures(List<PicturePM> pictures)
        {
            foreach (var picture in pictures.ToPictureList())
            {
                PictureBiz.Add(picture);
            }
            UnitOfWork.SaveChanges();
        }

        public List<string> GetPictures(int advertismentId)
        {
            return PictureBiz.Read(e => e.AdvertismentId == advertismentId).Select(e =>e.Name).ToList<string>();
        }

        public void RemovePicture(int advertismentId, string name)
        {
            var picture = PictureBiz.ReadSingle(e => e.AdvertismentId == advertismentId && e.Name == name);
            PictureBiz.Remove(picture);
            UnitOfWork.SaveChanges();

        }

        public void RemoveAllPicture(int advertismentId)
        {
            var pictures = PictureBiz.Read(e => e.AdvertismentId == advertismentId);
            foreach (var picture in pictures)
            {
                PictureBiz.Remove(picture);

            }
            UnitOfWork.SaveChanges();
        }
        public DataSourceResult GetActiveAdvertisments(UserIdentity user, DataSourceRequest request)
        {
            return AdvertismentBiz.Read(e => e.UserId == user.UserId).OrderByDescending(e => e.RegisterDate).MapTo<AdvertismentPM>().ToDataSourceResult(request);
        }
        public IEnumerable<AdvertismentPM> SearchAdvertisments(SearchFilterPM filter)
        {
            if ((string.IsNullOrWhiteSpace(filter.Title) || filter.Title.Length <= 2)
                && (filter.ManufacturingCountry == Country.None)
                && (filter.HealthStatus == HealthStatus.None)
                && (filter.AdvertismentType == AdvertismentType.None)
                && (!filter.ConstructionYearFrom.HasValue)
                && (!filter.ConstructionYearTo.HasValue))
            {
                return null;
            }

            var advertisments = AdvertismentBiz.Read(e => e.Status == AdvertismentStatus.Published).OfType<Machinery>();

            if (!string.IsNullOrWhiteSpace(filter.Title) && filter.Title.Length > 2)
            {
                var keywords = filter.Title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(i => i.Trim())
                                     .Where(i => i.Length > 2).ToList();

                advertisments = from a in advertisments
                                from k in keywords
                                where a.Title.Contains(k) || a.Comment.Contains(k)
                                select a;
            }

            if (filter.ManufacturingCountry != Country.None)
            {
                advertisments = advertisments.Where(e => e.ManufacturingCountry == filter.ManufacturingCountry);
            }

            if(filter.HealthStatus != HealthStatus.None)
            {
                advertisments = advertisments.Where(e => e.HealthStatus == filter.HealthStatus);
            }

            if(filter.ConstructionYearFrom.HasValue)
            {
                advertisments = advertisments.Where(e => e.ConstructionYear >= filter.ConstructionYearFrom.Value);
            }

            if (filter.ConstructionYearTo.HasValue)
            {
                advertisments = advertisments.Where(e => e.ConstructionYear <= filter.ConstructionYearTo.Value);
            }

            if(filter.AdvertismentType !=  AdvertismentType.None)
            {
                advertisments = advertisments.Where(e => e.TypeIdentity == filter.AdvertismentType.ToString());
            }

            advertisments = advertisments.OrderByDescending(e => e.RegisterDate);

            var result = from a in advertisments
            select new AdvertismentPM
            {
                FistImageName = (a.Pictures.FirstOrDefault()).Name,
                Comment = a.Comment,
                Price = a.Price,
                RegisterDate = a.RegisterDate,
                Title = a.Title,
                Id = a.Id
            };
            return result.ToList();
        }

        public void  RemoveAdvertisments(IEnumerable<int> ids)
        {
            var advertismentsToRemove = AdvertismentBiz.Read(a => ids.Contains(a.Id)).Include(e => e.Pictures).ToList();
            HashSet<string> pictureNamesToRemove = new HashSet<string>();
            foreach (var advertisment in advertismentsToRemove)
            {
                foreach (var picture in advertisment.Pictures.ToList())
                {
                 //   PictureBiz.Remove(picture);
                    pictureNamesToRemove.Add(picture.Name);
                }
                AdvertismentBiz.Remove(advertisment);
            }
            UnitOfWork.SaveChanges();

            foreach (var name in pictureNamesToRemove)
            {
                PictureManager.RemovePicture(name);
            }
        }

        public void ChangeAdvertismentsStatus(IEnumerable<int> ids, AdvertismentStatus newStatus)
        {
            AdvertismentBiz.Read(e => ids.Contains(e.Id))
                           .ToList()
                           .ForEach(e => e.Status = newStatus);
            UnitOfWork.SaveChanges();
        }
    }
}
