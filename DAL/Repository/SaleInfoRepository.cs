using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SaleInfoRepository : AbstractRepository, IModelRepository<DAL.Entity.SaleInfo, Model.SaleInfo>
    {
        Model.SaleInfo ToEntity(DAL.Entity.SaleInfo source)
        {
            return new Model.SaleInfo()
            {
                SaleDate = source.SaleDate,
                ID_Manager = source.ID_Manager,
                ID_Client = source.ID_Client,
                ID_Product = source.ID_Product
            };
        }

        DAL.Entity.SaleInfo ToObject(Model.SaleInfo source)
        {
            return new DAL.Entity.SaleInfo()
            {
                SaleDate = source.SaleDate,
                ID_Manager = source.ID_Manager,
                ID_Client = source.ID_Client,
                ID_Product = source.ID_Product
            };
        }

        public Model.SaleInfo GetEntity(DAL.Entity.SaleInfo source)
        {
            var entity = this.managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == source.ID_Sale);
            return entity;
        }

        public Model.SaleInfo GetEntityNameById(int id)
        {
            var entity = this.managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == id);
            return entity;
        }

        public void Add(DAL.Entity.SaleInfo item)
        {
            var entity = this.ToEntity(item);
            managersContext.SaleInfo.Add(entity);
        }

        public void Remove(DAL.Entity.SaleInfo item)
        {
            var entity = this.managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == item.ID_Sale);
            if (entity != null)
            {
                managersContext.SaleInfo.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(DAL.Entity.SaleInfo item)
        {
            var entity = this.managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == item.ID_Sale);
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

        public IEnumerable<DAL.Entity.SaleInfo> Items
        {
            get
            {
                var b = new List<DAL.Entity.SaleInfo>();
                foreach (var a in this.managersContext.SaleInfo.Select(x => x))
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