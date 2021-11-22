using ApiAthanasia.Models;

namespace ApiAthanasia.Services.ProductServices
{
    public class ProductService: IProductService
    {
        public void ReduceQuantityBySale(int product, int qty)
        {
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    Product editProduct = DB.Products.Find(product);
                    editProduct.Quantity -= qty;
                    DB.Entry(editProduct).State = Microsoft.EntityFrameworkCore
                        .EntityState.Modified;
                    DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
