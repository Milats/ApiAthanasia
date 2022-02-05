using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;

namespace ApiAthanasia.Services.UserServices
{
    public interface IUserAdminService
    {
        UserResponse Auth(AuthRequest model);
    }
}
