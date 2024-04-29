using Backend.Api.GlobalExceptionHandling;

namespace Backend.Api.ServiceLayer
{
    public class UserService : IUserService
    {
        public static List<UserModel> UserList = new List<UserModel>()
            {
                new UserModel(){Name = "Ayush", age=23, PersonId=90 },
                new UserModel(){Name = "Aman", age=24, PersonId=92 }
            };

        public async Task<Boolean> AddUser(UserModel user)
        {
           UserList.Add(user);
            return true;
        }

        public async Task<List<UserModel>> GetUserList()
        {
            var res = new ErrorResponsee()
            {
                Success = true,
                Message = "custom error"
            };
           // throw new ApplicationException(res.Message);
            return UserList;
        }
    }
}
