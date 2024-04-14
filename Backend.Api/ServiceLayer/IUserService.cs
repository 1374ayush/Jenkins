
namespace Backend.Api.ServiceLayer
{
    public interface IUserService
    {
        Task<bool> AddUser(UserModel user);
        Task<List<UserModel>> GetUserList();
    }
}