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
    }
}
