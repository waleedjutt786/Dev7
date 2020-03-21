//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Remoting.Contexts;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using dev7.EMS.Domain.Entities;
//using dev7.EMS.PT.Models;
//using dev7.EMS.Domain.Employee;
//using dev7.EMS.Domain.Customer;

//namespace dev7.EMS.DAL.DataContext
//{
//    public class EMSDataContext : ApplicationDbContext
//    {
//        public EMSDataContext() : base() { }
//        public EMSDataContext(string connectionString) : base()
//        {
//            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EMSDataContext, BT.Migrations.EMSMigrationsConfiguration.EMSConfiguration>());
//        }

//        public DbSet<CompanyDE> Company { get; set; }
//        //public DbSet<EmployeeDE> Employee { get; set; }
//        //public DbSet<CustomerDE> Customer { get; set; }
//    }
//}
