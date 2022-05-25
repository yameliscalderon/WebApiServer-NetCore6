using WebApiUsers.Models;

namespace WebApiUsers.Interface
{
    public interface IUsers
    {

        public List<Users> GetUsersDetails();

        public Users GetUserDetails(int id);

        public void AddUser(Users usuario);

        public void UpdateUser(Users usuario);

        public Users DeleteUser(int id);

        public bool CheckUser(int id);
    }
}
