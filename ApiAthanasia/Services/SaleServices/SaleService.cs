using ApiAthanasia.Models;
using ApiAthanasia.Models.Request;

namespace ApiAthanasia.Services.SaleServices
{
    public class SaleService: ISaleService
    {
        public void Add(SaleRequest saleRequested)
        {
            /*This using permit the EntityFramework to know that a 
            transaction has begun and the try will rollback the DB
            if the transacion failed. This permit the atomic transaction
            Or the transaction completes 100% or it even existed"
            Also, Transaction literally blocks all the tables that
            are involved in the real transaction.*/
            using (AthanasiaContext DB = new AthanasiaContext())
            {
                decimal total = 0;
                foreach (var saleDetail in saleRequested.saleDetails)
                {
                    total += DB.Products.Find(saleDetail.IDProduct).UnitPrice * saleDetail.Quantity;
                }
                using (var transaction = DB.Database.BeginTransaction())
                {
                    try
                    {
                        var newSale = new Sale();
                        newSale.Total = total * (decimal)1.1;
                        newSale.Date = DateTime.Now;
                        newSale.IduserClient = saleRequested.IDUserClient;
                        DB.Sales.Add(newSale);
                        DB.SaveChanges();

                        foreach (var saleDetail in saleRequested.saleDetails)
                        {
                            var newSaleDetail = new Models.SaleDetail();
                            newSaleDetail.Idsale = newSale.Id;
                            newSaleDetail.Idproduct = saleDetail.IDProduct;
                            newSaleDetail.Quantity = saleDetail.Quantity;
                            DB.SaleDetails.Add(newSaleDetail);
                            DB.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
