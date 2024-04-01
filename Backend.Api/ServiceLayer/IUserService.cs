
namespace Backend.Api.ServiceLayer
{
    public interface IUserService
    {
        bool AddUser(UserModel user);
        List<UserModel> GetUserList();
    }
}