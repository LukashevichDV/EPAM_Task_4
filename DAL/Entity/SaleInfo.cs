using System;

namespace DAL.Entity
{
    public class SaleInfo : Entity
    {
        public string SaleDate { get; set; }
        public Nullable<int> ID_Manager { get; set; }
        public Nullable<int> ID_Client { get; set; }
        public Nullable<int> ID_Product { get; set; }
        public int ID_Sale { get; internal set; }
    }
}