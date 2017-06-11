namespace DAL.Entity
{
    public class Product : Entity
    {
        public string ProductName { get; set; }
        public string ProductCost { get; set; }
        public int ID_Product { get; internal set; }
    }
}