using ApiAthanasia.Models;
using ApiAthanasia.Models.Exceptions;
using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;

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
        public Response CheckAvailableProductStock(SaleRequest list)
        {
            Response R = new Response();
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    foreach (var saleProduct in list.saleDetails)
                    {
                        Product checkProduct = DB.Products.Find(saleProduct.IDProduct);
                        if (checkProduct.Quantity < saleProduct.Quantity)
                        {
                            throw new OutOfStock(checkProduct.Id);
                        }
                    }
                }
                R.Success = true;
            }
            catch(OutOfStock EX)
            {
                R.Message = EX.Message;
            }
            catch (Exception ex)
            {
                R.Message = ex.Message;
            }
            return R;
        }
    }
}
