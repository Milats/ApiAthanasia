using System;
using System.Collections.Generic;

namespace ApiAthanasia.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartDetails = new HashSet<ShoppingCartDetail>();
        }

        public int Id { get; set; }
        public int IduserClient { get; set; }

        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }
    }
}
