using DAL.Model;
using System;

namespace DAL.Repository
{
    public class AbstractRepository : IDisposable
    {
        protected ManagersContext managersContext;
        public AbstractRepository()
        {
            managersContext = new ManagersContext();
        }
        public void Dispose()
        {
            managersContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}