using BargheNovin.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services.Interface
{
    public interface IUserService
    {
        User GetUserByUsername(string username);

        bool Any(Expression<Func<User, bool>> predicate);

        int Add<E>(E entity);
    }
}
