using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using dev7.EMS.DAL.UoW;
using dev7.EMS.Domain;
using dev7.EMS.BT.Domain;
//using dev7.EMS.DAL.DataContext;

namespace dev7.EMS.DAL.Repository
{
    /// <summary>
    ///   DAL Repository class implementing the Repository pattern.
    /// </summary>  
    public class EFRepository <T> : IRepository<T> where T : BaseDomain
    {
        private readonly IDbSet<T> _domainEntities;
        public IUnitOfWork _unitOfWork; // { get; set; }
        
        public EFRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._domainEntities = _unitOfWork.Context.Set<T>();
        }

        public virtual BaseDomain Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return this._domainEntities.Add(entity);
        }

        //public void Delete(object id)
        //{
        //    if (id == null)
        //        throw new ArgumentNullException("entity");

        //    _domainEntities.Remove(GetById(id));
        //}

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._domainEntities.Attach(entity);
            this._domainEntities.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _domainEntities.Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateExisting(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            //_domainEntities.Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual T GetById(params object[] primaryKyes)
        //public virtual T GetById(object id)
        {
            //return this._domainEntities.Find(id);
            return this._domainEntities.Find(primaryKyes);
        }

        public virtual T Fetch(Expression<Func<T, bool>> predicate)
        {
            return this._domainEntities.FirstOrDefault(predicate);
        }
        public virtual IList<T> GetAll()
        {
            return this._domainEntities.ToList();
        }
        public virtual IList<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return this._domainEntities.Where(predicate).ToList();
        }
        public virtual IList<T> GetAllPaged(int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = this._domainEntities.Count();
            return this._domainEntities.Skip(pageSize * pageIndex).Take(pageSize).ToList();
        }

        public virtual IQueryable<T> Query
        {
            get { return this._domainEntities; }
        }

        public virtual void CommitAllChanges()
        {
            this._unitOfWork.Commit();
        }

      
    }
}
