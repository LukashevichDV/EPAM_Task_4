using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Client : Entity.Entity
    {
        public Client()
        {
            SaleInfo = new HashSet<SaleInfo>();
        }


        public string ClientName { get; set; }
        public int ID_Client { get;  set; }
        public virtual ICollection<SaleInfo> SaleInfo { get; set; }
    }
}