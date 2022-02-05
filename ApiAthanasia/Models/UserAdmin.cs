using System;
using System.Collections.Generic;

namespace ApiAthanasia.Models
{
    public partial class UserAdmin
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Cedula { get; set; } = null!;
    }
}
