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
    public class PictureBiz : BizBase<Picture>
    {
        public PictureBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }
    }
}
