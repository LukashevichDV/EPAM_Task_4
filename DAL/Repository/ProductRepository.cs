using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ProductRepository : AbstractRepository, IModelRepository<Entity.Product, Model.Product>
    {
        Model.Product ToEntity(Entity.Product source)
        {
            return new Model.Product()
            {
                ProductName = source.ProductName,
                ProductCost = source.ProductCost
            };
        }

        Entity.Product ToObject(Model.Product source)
        {
            return new Entity.Product()
            {
                ProductName = source.ProductName,
                ProductCost = source.ProductCost
            };
        }

        public Model.Product GetEntity(Entity.Product source)
        {
            var entity = managersContext.Product.FirstOrDefault(x => x.ProductName == source.ProductName && x.ProductCost == source.ProductCost);
            return entity;
        }

        public Model.Product GetEntityNameById(int id)
        {
            var entity = managersContext.Product.FirstOrDefault(x => x.ID_Product == id);
            return entity;
        }

        public void Add(Entity.Product item)
        {
            var entity = ToEntity(item);
            managersContext.Product.Add(entity);
        }

        public void Remove(Entity.Product item)
        {
            var entity = managersContext.Product.FirstOrDefault(x => x.ID_Product == item.ID_Product);
            if (entity != null)
            {
                managersContext.Product.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(Entity.Product item)
        {
            var entity = managersContext.Product.FirstOrDefault(x => x.ID_Product == item.ID_Product);
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

        public IEnumerable<Entity.Product> Items
        {
            get
            {
                return managersContext.Product.Select(x => ToObject(x));
            }
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }
    }
}