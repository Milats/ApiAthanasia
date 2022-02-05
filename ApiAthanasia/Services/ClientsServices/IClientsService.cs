using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;

namespace ApiAthanasia.Services.ClientsServices
{
    public interface IClientsService
    {
        public Response Get()
        {
            return this.Get();
        }
        public Response Add(NewClientRequest client)
        {
            return this.Add(client);
        }
        public Response UpdateClient(UpdateUserRequest request, int id)
        {
            return this.UpdateClient(request, id);
        }
        public Response DeleteClient(int id)
        {
            return this.DeleteClient(id);
        }
    }
}
