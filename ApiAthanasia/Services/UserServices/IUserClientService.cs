using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;

namespace ApiAthanasia.Services.UserServices
{
    public interface IUserClientService
    {
        UserResponse Auth(AuthRequest model);
    }
}
