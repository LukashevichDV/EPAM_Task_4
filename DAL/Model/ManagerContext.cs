using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL.Model
{
    public partial class ManagersContext : DbContext
    {
        public ManagersContext()
            : base("name=ManagersContext")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }


        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SaleInfo> SaleInfo { get; set; }
    }
}