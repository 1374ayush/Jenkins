namespace Backend.Api.ServiceLayer
{
    public class UserService : IUserService
    {
        public static List<UserModel> UserList = new List<UserModel>()
            {
                new UserModel(){Name = "Ayush", age=23, PersonId=90 },
                new UserModel(){Name = "Aman", age=24, PersonId=92 }
            };

        public bool AddUser(UserModel user)
        {
            UserList.Add(user);
            return true;
        }

        public List<UserModel> GetUserList()
        {
            return UserList;
        }
    }
}
