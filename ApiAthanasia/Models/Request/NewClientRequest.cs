using System.ComponentModel.DataAnnotations;

namespace ApiAthanasia.Models.Request
{
    public class NewClientRequest
    {
        [Required]
        public string name { get; set; }
        [NewClientEmailExistsAttribute(ErrorMessage =
            "Email alreasy exists")]
        public string email { get; set; }
        public string password { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Cedula with incorret number of digits")]
        [NewClientCedulaExistsAtrribute(ErrorMessage =
            "Cedula already exists")]
        public string cedula { get; set; }
    }

    #region Validations
    public class NewClientCedulaExistsAtrribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                using (var db = new Models.AthanasiaContext())
                {
                    var client = db.UserClients.Where(a => a.Cedula == value).FirstOrDefault();
                    if (client == null)
                    {
                        return true;
                    }  
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
    public class NewClientEmailExistsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                using (var db = new Models.AthanasiaContext())
                {
                    var client = db.UserClients.Where(a => a.Email == value).FirstOrDefault();
                    if (client == null)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
    #endregion
}