using System;

namespace DAL.Model
{
    public partial class SaleInfo : Entity.Entity
    {
        public string SaleDate { get; set; }
        public Nullable<int> ID_Manager { get; set; }
        public Nullable<int> ID_Client { get; set; }
        public Nullable<int> ID_Product { get; set; }

        public virtual Client Client { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Product Product { get; set; }
    }
}