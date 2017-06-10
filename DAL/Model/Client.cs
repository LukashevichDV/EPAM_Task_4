using DAL.Entity;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Client
    {
        public Client()
        {
            SaleInfo = new HashSet<SaleInfo>();
        }



        public int ID_Client { get; set; }
        public string ClientName { get; set; }

        public virtual ICollection<SaleInfo> SaleInfo { get; set; }
    }
}