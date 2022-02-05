using System;
using System.Collections.Generic;

namespace ApiAthanasia.Models
{
    public partial class ShoppingCartDetail
    {
        public int Id { get; set; }
        public int? IdshoppingCart { get; set; }
        public int? Idproduct { get; set; }

        public virtual ShoppingCart? IdshoppingCartNavigation { get; set; }
    }
}
