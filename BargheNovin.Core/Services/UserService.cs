using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.DataBaseContext;
using BargheNovin.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services
{
    public class UserService : IUserService
    {
        private readonly BargheNovinDBContext _context;

        public UserService(BargheNovinDBContext context)
        {
            _context = context;
        }

        public int Add<E>(E entity)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Any(predicate);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.
                SingleOrDefault(u => u.UserName == username);
        }
    }
}
