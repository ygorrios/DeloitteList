using Deloitte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Business.Interface
{
    public interface IUserBusiness
    {
        UserViewModel ValidateUser(UserViewModel request);
        UserViewModel GetUserById(int Id);
    }
}
