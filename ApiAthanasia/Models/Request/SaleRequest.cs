using ApiAthanasia.Services.ProductServices;
using System.ComponentModel.DataAnnotations;

namespace ApiAthanasia.Models.Request
{
    /*Here, I define how(format) the FrontEnd must send to the BackEnd
     the data to receive a Sale Data Type*/
    public class SaleRequest
    {
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage =
            "IDClient invalid")]
        [ClientExits(ErrorMessage =
            "IDClient doesn't exists")]
        public int IDUserClient { get; set; }   
        [Required]
        [MinLength(1, ErrorMessage =
            "Sale without products")]
        public List<SaleDetail> saleDetails { get; set; }
    }

    public class SaleDetail
    {
        [Required]
        public int IDProduct { get; set; }
        [Required]
        public int Quantity { get; set; }
    }

    /*In this region I can create restrictions for request that
     the FrontEnd makes me from the Sale Type.*/
    #region Validations
    public class ClientExitsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int idClient = (int)value;
            using (var db = new Models.AthanasiaContext())
            {
                if (db.UserClients.Find(idClient) == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
    #endregion
}
