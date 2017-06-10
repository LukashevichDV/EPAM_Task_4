using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Product
    {
        public Product()
        {
            SaleInfo = new HashSet<SaleInfo>();
        }

        public int ID_Product { get; set; }
        public string ProductName { get; set; }
        public string ProductCost { get; set; }

        public virtual ICollection<SaleInfo> SaleInfo { get; set; }
    }
}