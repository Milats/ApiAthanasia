using ApiAthanasia.Models;
using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Tools;

namespace ApiAthanasia.Services.UserServices
{
    public class UserClientService : IUserClientService
    {
        public UserClientResponse Auth(AuthClientRequest model)
        {
            UserClientResponse responseUserClient = new UserClientResponse();
            using (var DB = new AthanasiaContext())
            {
                string encryptedPassword = Encrypt.GetSHA256(model.Password);
                var user = DB.UserClients.Where(u=>
                u.Email == model.Email && u.Password == encryptedPassword)
                    .FirstOrDefault();
                if (user == null)
                {
                    return null;
                }
                responseUserClient.Email = user.Email;
                //responseUserClient.Token = GetToken(user);
            }
            return responseUserClient;
        }
    }
}
