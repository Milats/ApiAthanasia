using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;

namespace ApiAthanasia.Services
{
    public interface ISaleService
    {
        public Response Add(SaleRequest model) {
            return this.Add(model);
        }
    }
}
