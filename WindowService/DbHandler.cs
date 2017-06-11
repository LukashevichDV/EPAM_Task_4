using DAL.Repository;

namespace WindowService
{
    public class DbHandler
    {
        private IModelRepository<DAL.Entity.Manager, DAL.Model.Manager> ManagerRepository;
        private IModelRepository<DAL.Entity.Client, DAL.Model.Client> ClientRepository;
        private IModelRepository<DAL.Entity.Product, DAL.Model.Product> ProductRepository;
        private IModelRepository<DAL.Entity.SaleInfo, DAL.Model.SaleInfo> SaleInfoRepository;

        public DbHandler()
        {
            ManagerRepository = new ManagerRepository();
            ClientRepository = new CilentRepository();
            ProductRepository = new ProductRepository();
            SaleInfoRepository = new SaleInfoRepository();
        }

        public void AddToDatabase(Journal journal)
        {
            lock (this)
            {
                var newManager = new DAL.Entity.Manager { ManagerName = journal.ManagerName };
                var manager = ManagerRepository.GetEntity(newManager);
                if (manager == null)
                {
                    ManagerRepository.Add(newManager);
                    ManagerRepository.SaveChanges();
                    manager = ManagerRepository.GetEntity(newManager);
                }

                var newClient = new DAL.Entity.Client { ClientName = journal.ClientName };
                ClientRepository.Add(newClient);
                ClientRepository.SaveChanges();
                var client = ClientRepository.GetEntity(newClient);

                var newProduct = new DAL.Entity.Product { ProductName = journal.ProductName, ProductCost = journal.ProductCost };
                ProductRepository.Add(newProduct);
                ProductRepository.SaveChanges();
                var product = ProductRepository.GetEntity(newProduct);

                var saleInfo = new DAL.Entity.SaleInfo
                {
                    SaleDate = journal.SaleDate,
                    ID_Manager = manager.ID_Manager,
                    ID_Client = client.ID_Client,
                    ID_Product = product.ID_Product
                };
                SaleInfoRepository.Add(saleInfo);
                SaleInfoRepository.SaveChanges();
            }
        }
    }
}