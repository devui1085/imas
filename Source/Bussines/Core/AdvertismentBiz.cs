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

namespace IMAS.Bussines.Core
{
    public class AdvertismentBiz : BizBase<Advertisment>
    {
        public AdvertismentBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public Advertisment ValidateAndUpdate(Advertisment advertisment)
        {
            var current = ReadSingle(e => e.Id == advertisment.Id, true);
            if (current.UserId != advertisment.UserId)
            {
                throw new BusinessException("IllegalInput".Localize());
            }

            advertisment.RegisterDate = current.RegisterDate;
            advertisment.TypeIdentity = current.TypeIdentity;
            advertisment.Status = AdvertismentStatus.Pending;

            return Update(advertisment);
        }

        public Advertisment AddAdvertisment(Advertisment advertisment)
        {
            advertisment.Status = AdvertismentStatus.Pending;
            advertisment.RegisterDate = DateTime.Now;
            return Add(advertisment);
        }

        public IQueryable<Advertisment> GetLastestAdvertisments(int startIndex,int count)
        {
            return Read(e => e.Status == AdvertismentStatus.Published)
                .OrderByDescending(e => e.RegisterDate)
                .Skip(startIndex)
                .Take(count);
        }
    }
}
