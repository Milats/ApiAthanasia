using ApiAthanasia.Models;
using ApiAthanasia.Models.Exceptions;

namespace ApiAthanasia.Services.ProductServices
{
    public class ProductService: IProductService
    {
        public void ReduceQuantityBySale(int product, int qty)
        {

            using (AthanasiaContext DB = new AthanasiaContext())
            {
                using (var transaction = DB.Database.BeginTransaction())
                {
                    try
                    {
                        Product editProduct = DB.Products.Find(product);
                        editProduct.Quantity -= qty;
                       DB.Entry(editProduct).State = Microsoft.EntityFrameworkCore
                            .EntityState.Modified;
                        DB.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }      
        }
        public bool CheckAvailableProductStock(int product, int qty)
        {
            bool res = false;
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    Product checkProduct = DB.Products.Find(product);
                    if (checkProduct.Quantity >= qty)
                    {
                        res = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return res;
        }
    }
}
