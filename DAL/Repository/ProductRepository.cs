using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository : AbstractRepository, IModelRepository<DAL.Entity.Product, Model.Product>
    {
        Model.Product ToEntity(DAL.Entity.Product source)
        {
            return new Model.Product()
            {
                ProductName = source.ProductName,
                ProductCost = source.ProductCost
            };
        }

        DAL.Entity.Product ToObject(Model.Product source)
        {
            return new DAL.Entity.Product()
            {
                ProductName = source.ProductName,
                ProductCost = source.ProductCost
            };
        }

        public Model.Product GetEntity(DAL.Entity.Product source)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ProductName == source.ProductName && x.ProductCost == source.ProductCost);
            return entity;
        }

        public Model.Product GetEntityNameById(int id)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == id);
            return entity;
        }

        public void Add(DAL.Entity.Product item)
        {
            var entity = this.ToEntity(item);
            managersContext.Product.Add(entity);
        }

        public void Remove(DAL.Entity.Product item)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == item.ID_Product);
            if (entity != null)
            {
                managersContext.Product.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(DAL.Entity.Product item)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == item.ID_Product);
            if (entity != null)
            {
                entity.ProductName = item.ProductName;
                entity.ProductCost = item.ProductCost;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<DAL.Entity.Product> Items
        {
            get
            {
                return this.managersContext.Product.Select(x => this.ToObject(x));
            }
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }
    }
}