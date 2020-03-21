using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace dev7.EMS.DAL.UoW
{

    public interface IUnitOfWork //<U> where U : IDbContext
    {
        DbContext Context { get; set; }
        void Commit();
        bool LazyLoadingEnabled { get; set; }
    }
}
