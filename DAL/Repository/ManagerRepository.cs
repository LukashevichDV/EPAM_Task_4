using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ManagerRepository : AbstractRepository, IModelRepository<DAL.Entity.Manager, Model.Manager>
    {
        Model.Manager ToEntity(DAL.Entity.Manager source)
        {
            return new Model.Manager()
            {
                ManagerName = source.ManagerName
            };
        }

        DAL.Entity.Manager ToObject(Model.Manager source)
        {
            return new DAL.Entity.Manager()
            {
                ManagerName = source.ManagerName
            };
        }

        public Model.Manager GetEntity(DAL.Entity.Manager source)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ManagerName == source.ManagerName);
            return entity;
        }

        public Model.Manager GetEntityNameById(int id)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ID_Manager == id);
            return entity;
        }

        public void Add(DAL.Entity.Manager item)
        {
            var entity = this.ToEntity(item);
            managersContext.Manager.Add(entity);
        }

        public void Remove(DAL.Entity.Manager item)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ID_Manager == item.ID_Manager);
            if (entity != null)
            {
                managersContext.Manager.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(DAL.Entity.Manager item)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ManagerName == item.ManagerName);
            if (entity != null)
            {
                entity.ManagerName = item.ManagerName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<DAL.Entity.Manager> Items
        {
            get
            {
                var b = new List<DAL.Entity.Manager>();
                foreach (var a in this.managersContext.Manager.Select(x => x))
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