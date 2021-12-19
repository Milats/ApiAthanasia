using ApiAthanasia.Models;
using ApiAthanasia.Models.Response;

namespace ApiAthanasia.Services.ClientsServices
{
    public class ClientsService
    {
        public static Response EmptyPasswords(List<UserClient> userList)
        {
            List<UserClient> users = new List<UserClient>();
            Response R = new Response();
            foreach (UserClient user in userList)
            {
                user.Password = "Empty";
                users.Add(user);
            }
            R.Data = users;
            return R;
        }
    }
}