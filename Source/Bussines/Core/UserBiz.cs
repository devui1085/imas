using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IMAS.Model.Domain.Core;
using IMAS.Bussines.Infrastructure;
using IMAS.UnitOfWork;
using IMAS.Common.ExtensionMethod;
using Common.Exception;
using IMAS.Localization.ExtensionMethod;

namespace IMAS.Bussines.Core
{
    public class UserBiz : BizBase<User>
    {
        public UserBiz(ICoreUnitOfWork coreUnitOfWork) : base(coreUnitOfWork)
        {

        }

        public User CreateUser(User user)
        {
            var cellphone = user.Cellphone.Trim().ToLower();
            if (Any(u => u.Cellphone == cellphone))
                throw new BusinessException("MsgCellphoneIsAlreadyRegistered".Localize());

            return UnitOfWork.UserRepository.Add(user);
        }

        public IQueryable<User> GetNewUsers(int top)
        {
            return UnitOfWork.UserRepository.AsQueryable()
                .OrderByDescending(user => user.Membership.CreateDate)
                .Take(top);
        }

    }
}