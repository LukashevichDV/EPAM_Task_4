using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Product : Entity.Entity
    {
        public Product()
        {
            SaleInfo = new HashSet<SaleInfo>();
        }


        public string ProductName { get; set; }
        public string ProductCost { get; set; }
        public virtual ICollection<SaleInfo> SaleInfo { get; set; }
    }
}