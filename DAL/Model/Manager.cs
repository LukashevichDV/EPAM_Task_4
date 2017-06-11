using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Manager : Entity.Entity
    {
        public Manager()
        {
            SaleInfo = new HashSet<SaleInfo>();
        }

        public int ID_Manager { get; set; }
        public string ManagerName { get; set; }
        public virtual ICollection<SaleInfo> SaleInfo { get; set; }
    }
}