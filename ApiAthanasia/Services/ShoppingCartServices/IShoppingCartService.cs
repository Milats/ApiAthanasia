using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;

namespace ApiAthanasia.Services.ShoppingCartServices
{
    public interface IShoppingCartService
    {
        public Response Get()
        {
            return this.Get();
        }
        public Response Add(ShoppingCartRequest request)
        {
            return this.Add(request);
        }
        public Response GetCartByIDUserClient(int user)
        {
            return this.GetCartByIDUserClient(user);
        }
        public Response DeleteCartByUserID(int user)
        {
            return this.DeleteCartByUserID(user);
        }
    }
}
