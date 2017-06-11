using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CilentRepository : AbstractRepository, IModelRepository<Entity.Client, Model.Client>
    {
        Model.Client ToEntity(Entity.Client source)
        {
            return new Model.Client()
            {
                ClientName = source.ClientName
            };
        }

        Entity.Client ToObject(Model.Client source)
        {
            return new Entity.Client()
            {
                ClientName = source.ClientName
            };
        }

        public Model.Client GetEntity(Entity.Client source)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ClientName == source.ClientName);
            return entity;
        }

        public Model.Client GetEntityNameById(int id)
        {
            var entity = managersContext.Client.FirstOrDefault(x => x.ID_Client == id);
            return entity;
        }

        public void Add(Entity.Client item)
        {
            var entity = ToEntity(item);
            managersContext.Client.Add(entity);
        }

        public void Remove(Entity.Client item)
        {
            var entity = managersContext.Client.FirstOrDefault(x => x.ID_Client == item.ID_Client);
            if (entity != null)
            {
                managersContext.Client.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(Entity.Client item)
        {
            var entity = managersContext.Client.FirstOrDefault(x => x.ID_Client == item.ID_Client);
            if (entity != null)
            {
                entity.ClientName = item.ClientName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<DAL.Entity.Client> Items
        {
            get
            {
                return managersContext.Client.Select(x => this.ToObject(x));
            }
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }
    }
}