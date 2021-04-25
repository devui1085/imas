using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using System;
using IMAS.Common;

namespace IMAS.Bussines.Core
{
    public class ExceptionLogBiz : BizBase<ExceptionLog>
    {
        public ExceptionLogBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {
        }

        public void AddException(Exception exception, string url)
        {
            var innerException= exception;
            while (innerException.InnerException != null)
                innerException = innerException.InnerException;
            Add(new ExceptionLog() {
                Type = exception.GetType().Name,
                Message = ExceptionHelper.GetExceptionText(exception),
                InnerMessage = ExceptionHelper.GetExceptionText(innerException),
                HttpRequestUrl = url
            });
        }
    }
}