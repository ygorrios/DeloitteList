using Deloitte.Model;

namespace Deloitte.Repository.Interface
{
    public interface IUserRepository
    {
        UserViewModel ValidateUser(UserViewModel request);
        UserViewModel GetUserById(int Id);
    }
}
