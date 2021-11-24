using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;

namespace ApiAthanasia.Services.UserServices
{
    public interface IUserClientService
    {
        UserClientResponse Auth(AuthClientRequest model);
    }
}
