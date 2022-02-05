using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;

namespace ApiAthanasia.Services
{
    public interface IProductService
    {
        public Response UpdateProduct(ProductRequest request, int id)
        {
            return this.UpdateProduct(request, id);
        }
        public Response DeleteProduct(int product)
        {
            return this.DeleteProduct(product);
        }
        public Response AddProduct(ProductRequest request)
        {
            return this.AddProduct(request);
        }
    }
}
