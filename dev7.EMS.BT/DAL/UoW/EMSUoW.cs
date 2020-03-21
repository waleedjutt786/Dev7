using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev7.EMS.DAL.UoW;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;
using dev7.EMS.PT.Models;
//using dev7.EMS.DAL.DataContext;

namespace dev7.EMS.DAL.UoW
{
    public class EMSUoW : IUnitOfWork, IDisposable
    {
        private EMSDbContext _context;

        public EMSUoW(string conStr)
        {
            this._context = new EMSDbContext();
        }

        public DbContext Context
        {
            get { return _context; }
            set { _context = (EMSDbContext)value; }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public bool LazyLoadingEnabled
        {
            get { return this.Context.Configuration.LazyLoadingEnabled; }
            set { this.Context.Configuration.LazyLoadingEnabled = value; }
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}