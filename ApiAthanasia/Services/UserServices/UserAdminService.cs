using ApiAthanasia.Models;
using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Tools;

namespace ApiAthanasia.Services.UserServices
{
    public class UserAdminService: IUserAdminService
    {
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse responseUserClient = new UserResponse();
            using (var DB = new AthanasiaContext())
            {
                string encryptedPassword = Encrypt.GetSHA256(model.Password);
                var user = DB.UserAdmins.Where(u =>
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
