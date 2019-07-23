using Deloitte.Model;
using Deloitte.Repository.Context.Deloitte;
using Deloitte.Repository.Context.Deloitte.Models;
using Deloitte.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Deloitte.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserViewModel ValidateUser(UserViewModel request)
        {
            UserViewModel result = null;

            var options = new DbContextOptionsBuilder<DeloitteContext>()
               .UseInMemoryDatabase(databaseName: "User")
               .Options;

            var addUser = AddUser(request, options);

            using (var deloitteContext = new DeloitteContext(options))
            {
                result = (from u in deloitteContext.User
                            where u.Login.Trim().ToUpper() == request.Login.Trim().ToUpper() &&
                                  u.Password == request.Password
                            select new UserViewModel
                            {
                                Id = u.Id,
                                Login = u.Login,
                                Password = u.Password,
                                LastAccessTime = u.LastAccessTime
                            }).FirstOrDefault();
            }

            return result;
        }

        private int GetLastUserId()
        {
            var options = new DbContextOptionsBuilder<DeloitteContext>()
              .UseInMemoryDatabase(databaseName: "User")
              .Options;

            int id = 1;
            using (var context = new DeloitteContext(options))
            {
                var query = context.User.OrderByDescending(o => o.Id).FirstOrDefault();
                if (query != null)
                {
                    id = query.Id + 1;
                }
                return id;
            }
        }

        private bool AddUser(UserViewModel user, DbContextOptions<DeloitteContext> options)
        {
            using (var context = new DeloitteContext(options))
            {
                var request = new User
                {
                    Id = GetLastUserId(),
                    Login = user.Login,
                    Password = user.Password
                };
                context.User.Add(request);
                return context.SaveChanges() >= 0;
            }
        }

        public UserViewModel GetUserById(int Id)
        {
            UserViewModel result = null;

            var options = new DbContextOptionsBuilder<DeloitteContext>()
               .UseInMemoryDatabase(databaseName: "User")
               .Options;

            using (var deloitteContext = new DeloitteContext(options))
            {
                var user = (from u in deloitteContext.User
                            where u.Id == Id
                            select new UserViewModel
                            {
                                Id = u.Id,
                                Login = u.Login,
                                Password = u.Password,
                                LastAccessTime = u.LastAccessTime
                            }).FirstOrDefault();
            }

            return result;
        }

    }
}
