using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class SaleInfoRepository : AbstractRepository, IModelRepository<Entity.SaleInfo, Model.SaleInfo>
    {
        Model.SaleInfo ToEntity(Entity.SaleInfo source)
        {
            return new Model.SaleInfo()
            {
                SaleDate = source.SaleDate,
                ID_Manager = source.ID_Manager,
                ID_Client = source.ID_Client,
                ID_Product = source.ID_Product
            };
        }

        Entity.SaleInfo ToObject(Model.SaleInfo source)
        {
            return new Entity.SaleInfo()
            {
                SaleDate = source.SaleDate,
                ID_Manager = source.ID_Manager,
                ID_Client = source.ID_Client,
                ID_Product = source.ID_Product
            };
        }

        public Model.SaleInfo GetEntity(Entity.SaleInfo source)
        {
            var entity = managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == source.ID_Sale);
            return entity;
        }

        public Model.SaleInfo GetEntityNameById(int id)
        {
            var entity = managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == id);
            return entity;
        }

        public void Add(Entity.SaleInfo item)
        {
            var entity = ToEntity(item);
            managersContext.SaleInfo.Add(entity);
        }

        public void Remove(Entity.SaleInfo item)
        {
            var entity = managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == item.ID_Sale);
            if (entity != null)
            {
                managersContext.SaleInfo.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(Entity.SaleInfo item)
        {
            var entity = managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == item.ID_Sale);
            if (entity != null)
            {
                entity.SaleDate = item.SaleDate;
                entity.ID_Manager = item.ID_Manager;
                entity.ID_Client = item.ID_Client;
                entity.ID_Product = item.ID_Product;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<Entity.SaleInfo> Items
        {
            get
            {
                var b = new List<Entity.SaleInfo>();
                foreach (var a in managersContext.SaleInfo.Select(x => x))
                {
                    b.Add(ToObject(a));
                }

                return b;
            }
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }
    }
}