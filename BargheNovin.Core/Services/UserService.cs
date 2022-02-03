using BargheNovin.Core.Services.Interface;
using BargheNovin.Core.Text;
using BargheNovin.DataLayer.DataBaseContext;
using BargheNovin.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Toplearn.Core.Security;

namespace BargheNovin.Core.Services
{
    public class UserService : IUserService
    {
        private readonly BargheNovinDBContext _context;

        public UserService(BargheNovinDBContext context)
        {
            _context = context;
        }

        public E Add<E>(E entity, bool save = true)
        {
            _context.Add(entity);

            if (save)
                _context.SaveChanges();

            return entity;
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

        public User RegisterUser(User user)
        {
            user.Email = TextEdit.FomatEmail(user.Email);
            if (Any(u => u.UserName == user.UserName || u.Email == user.Email))
            {
                return null;
            }

            user.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            user.CreateDate = DateTime.Now;
            user.IsDeleted = false;
            user.RemoveDate = null;

            Add(user);

            return user;
        }
    }
}
