using ApiAthanasia.Models.Request;

namespace ApiAthanasia.Services
{
    public interface ISaleService
    {
        public string Add(SaleRequest model) {
            return this.Add(model);
        }
    }
}
