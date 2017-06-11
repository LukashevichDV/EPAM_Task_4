using DAL.Repository;

namespace WindowService
{
    public class DbHandler
    {
        private IModelRepository<DAL.Entity.Manager, DAL.Model.Manager> _managerRepository;
        private IModelRepository<DAL.Entity.Client, DAL.Model.Client> _clientRepository;
        private IModelRepository<DAL.Entity.Product, DAL.Model.Product> _productRepository;
        private IModelRepository<DAL.Entity.SaleInfo, DAL.Model.SaleInfo> _saleInfoRepository;

        public DbHandler()
        {
            _managerRepository = new ManagerRepository();
            _clientRepository = new CilentRepository();
            _productRepository = new ProductRepository();
            _saleInfoRepository = new SaleInfoRepository();
        }

        public void AddToDatabase(Journal journal)
        {
            lock (this)
            {
                var newManager = new DAL.Entity.Manager { ManagerName = journal.ManagerName };
                var manager = _managerRepository.GetEntity(newManager);
                if (manager == null)
                {
                    _managerRepository.Add(newManager);
                    _managerRepository.SaveChanges();
                    manager = _managerRepository.GetEntity(newManager);
                }

                var newClient = new DAL.Entity.Client { ClientName = journal.ClientName };
                _clientRepository.Add(newClient);
                _clientRepository.SaveChanges();
                var client = _clientRepository.GetEntity(newClient);

                var newProduct = new DAL.Entity.Product { ProductName = journal.ProductName, ProductCost = journal.ProductCost };
                _productRepository.Add(newProduct);
                _productRepository.SaveChanges();
                var product = _productRepository.GetEntity(newProduct);

                var saleInfo = new DAL.Entity.SaleInfo
                {
                    SaleDate = journal.SaleDate,
                    ID_Manager = manager.ID_Manager,
                    ID_Client = client.ID_Client,
                    ID_Product = product.ID_Product
                };
                _saleInfoRepository.Add(saleInfo);
                _saleInfoRepository.SaveChanges();
            }
        }
    }
}