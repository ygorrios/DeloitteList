using Deloitte.Business.Interface;
using Deloitte.Model;
using Deloitte.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Business.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel ValidateUser(UserViewModel request)
        {
            return _userRepository.ValidateUser(request);
        }
        public UserViewModel GetUserById(int Id)
        {
            return _userRepository.GetUserById(Id);
        }
    }
}
