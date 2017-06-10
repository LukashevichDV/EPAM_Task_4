using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CilentRepository : AbstractRepository, IModelRepository<DAL.Entity.Client, Model.Client>
    {
        Model.Client ToEntity(DAL.Entity.Client source)
        {
            return new Model.Client()
            {
                ClientName = source.ClientName
            };
        }

        DAL.Entity.Client ToObject(Model.Client source)
        {
            return new DAL.Entity.Client()
            {
                ClientName = source.ClientName
            };
        }

        public Model.Client GetEntity(DAL.Entity.Client source)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ClientName == source.ClientName);
            return entity;
        }

        public Model.Client GetEntityNameById(int id)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == id);
            return entity;
        }

        public void Add(DAL.Entity.Client item)
        {
            var entity = this.ToEntity(item);
            managersContext.Client.Add(entity);
        }

        public void Remove(DAL.Entity.Client item)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == item.ID_Client);
            if (entity != null)
            {
                managersContext.Client.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(DAL.Entity.Client item)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == item.ID_Client);
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
                return this.managersContext.Client.Select(x => this.ToObject(x));
            }
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }
    }
}