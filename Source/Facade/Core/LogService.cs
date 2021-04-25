using IMAS.Bussines.Core;
using IMAS.Security.Helper;
using System.Linq;
using System.Data.Entity;
using IMAS.Common.Data;
using IMAS.Common.Enum;
using IMAS.Common.ExtensionMethod;
using IMAS.PresentationModel.Model.Content;
using IMAS.Security.Identity;
using IMAS.UnitOfWork;
using System;
using System.Collections;
using IMAS.PresentationModel.Model;
using System.Collections.Generic;
using IMAS.Mapper.Core;
using IMAS.Model.Domain.Core;

namespace IMAS.Facade.Core
{
    public class LogService
    {
        CoreUnitOfWork UnitOfWork { get; set; }
        ExceptionLogBiz ExceptionLogBiz { get; set; }

        public LogService()
        {
            UnitOfWork = new CoreUnitOfWork();
            ExceptionLogBiz = new ExceptionLogBiz(UnitOfWork);
        }

        public void LogException(Exception exception, string url)
        {
            try
            {
                ExceptionLogBiz.AddException(exception, url);
                UnitOfWork.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
