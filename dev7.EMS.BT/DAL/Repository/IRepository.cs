using dev7.EMS.BT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.DAL.Repository
{
    
    /// <summary>
    ///   interface defining all the required method for the DAL Repository
    /// </summary>    
    public interface IRepository<T> where T : BaseDomain
    {
        BaseDomain Insert(T entity);
        //void Delete(object id);
        void Delete(T entity);
        void Update(T entity);
        void UpdateExisting(T entity);
        
        //T GetById(object id);
        T GetById(params object[] primaryKyes);
        T Fetch(Expression<Func<T, bool>> predicate);
        IList<T> GetAll();
        IList<T> GetAll(Expression<Func<T, bool>> predicate);
        IList<T> GetAllPaged(int pageNumber, int pageSize, out int totalCount);
        IQueryable<T> Query { get; }

        void CommitAllChanges();
    }
}
