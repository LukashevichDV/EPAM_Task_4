namespace DAL.Entity
{
    public class Client : Entity
    {
        public string ClientName { get; set; }
        public int ID_Client { get; internal set; }
    }
}