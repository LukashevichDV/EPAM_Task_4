using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ManagerRepository : AbstractRepository, IModelRepository<Entity.Manager, Model.Manager>
    {
        Model.Manager ToEntity(Entity.Manager source)
        {
            return new Model.Manager()
            {
                ManagerName = source.ManagerName
            };
        }

        Entity.Manager ToObject(Model.Manager source)
        {
            return new Entity.Manager()
            {
                ManagerName = source.ManagerName
            };
        }

        public Model.Manager GetEntity(Entity.Manager source)
        {
            var entity = managersContext.Manager.FirstOrDefault(x => x.ManagerName == source.ManagerName);
            return entity;
        }

        public Model.Manager GetEntityNameById(int id)
        {
            var entity = managersContext.Manager.FirstOrDefault(x => x.ID_Manager == id);
            return entity;
        }

        public void Add(Entity.Manager item)
        {
            var entity = ToEntity(item);
            managersContext.Manager.Add(entity);
        }

        public void Remove(Entity.Manager item)
        {
            var entity = managersContext.Manager.FirstOrDefault(x => x.ID_Manager == item.ID_Manager);
            if (entity != null)
            {
                managersContext.Manager.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(Entity.Manager item)
        {
            var entity = managersContext.Manager.FirstOrDefault(x => x.ManagerName == item.ManagerName);
            if (entity != null)
            {
                entity.ManagerName = item.ManagerName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<Entity.Manager> Items
        {
            get
            {
                var b = new List<Entity.Manager>();
                foreach (var a in managersContext.Manager.Select(x => x))
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