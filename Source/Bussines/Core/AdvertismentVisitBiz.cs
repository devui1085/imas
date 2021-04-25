using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Exception;
using IMAS.Bussines.Infrastructure;
using IMAS.Common.Enum;
using IMAS.Mapper.Core;
using IMAS.Model.Domain.Core;
using IMAS.PresentationModel.Model;
using IMAS.PresentationModel.Model.Advertisment;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using IMAS.Localization.ExtensionMethod;
using IMAS.Common.Data;

namespace IMAS.Bussines.Core
{
    public class AdvertismentVisitBiz : BizBase<AdvertismentVisit>
    {
        public AdvertismentVisitBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public void IncrementVisitsCount(int advertismentId, int incrementValue = 1)
        {
            var today = DateTime.Now.Date;
            var visit = ReadSingleOrDefault(e => e.AdvertismentId == advertismentId && e.Date == today);
            if (visit == null)
                UnitOfWork.AdvertismentVisitRepository.Add(new AdvertismentVisit()
                {
                    AdvertismentId = advertismentId,
                    Date = today,
                    Count = incrementValue,
                });
            else
                visit.Count += incrementValue;
        }

        public int GetUserAdvertismentsTodayTotalVisits(int userId)
        {
            var today = DateTime.Now.Date;
            return UnitOfWork.AdvertismentVisitRepository
                .Read(visit => visit.Advertisment.UserId == userId && visit.Date == today)
                .Sum(visit => (int?)visit.Count) ?? 0;
        }

        public List<ChartData> GetAdvertismentVisitChartData(int advertismentId, int days = 7)
        {
            var startDate = DateTime.Now.Date.AddDays(-days);
            return Read(e =>
                 e.AdvertismentId == advertismentId &&
                 e.Date >= startDate)
            .GroupBy(visit => visit.Date)
            .Select(group => new ChartData()
            {
                Date = group.Key,
                Value = group.Sum(visit => visit.Count)
            })
            .ToList();
        }

        public int GetTodaySiteTotalVisitsCount()
        {
            var today = DateTime.Now.Date;
            return Read(v => v.Date == today).Sum(v => (int?)v.Count) ?? 0;
        }
    }
}
