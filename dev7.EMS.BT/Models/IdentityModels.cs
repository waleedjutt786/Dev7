using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using dev7.EMS.BT.Domain;
using dev7.EMS.Domain.Entities;
using dev7.EMS.Domain.Employee;
using dev7.EMS.Domain.Customer;
//using dev7.EMS.Domain.Vendor;
//using dev7.EMS.Domain.VendorType;
using dev7.EMS.Domain.Vehicle;
using dev7.EMS.Domain.VehicleFuel;
using dev7.EMS.Domain.Vendor;
using dev7.EMS.Domain.VendorType;
using dev7.EMS.Domain.EventType;
using dev7.EMS.Domain.Schedule;
using dev7.EMS.Domain.Event;

namespace dev7.EMS.PT.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public virtual CompanyDE Company { get; set; }
        public virtual EmployeeDE Employee { get; set; }
        public virtual CustomerDE Customer { get; set; }
        public virtual VendorDE Vendor { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class EMSDbContext : IdentityDbContext<ApplicationUser, CustomRole,
    int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public EMSDbContext() : base("csEMS")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EMSDbContext, dev7.EMS.BT.Migrations.Configuration>());
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<CustomRole>().ToTable("Role");
            modelBuilder.Entity<CustomUserRole>().ToTable("UserRole");
            modelBuilder.Entity<CustomUserClaim>().ToTable("Claim");
            modelBuilder.Entity<CustomUserLogin>().ToTable("Login");

        }
        public virtual DbSet<CompanyDE> Company { get; set; }
        public virtual DbSet<EmployeeDE> Employee { get; set; }
        public virtual DbSet<CustomerDE> Customer { get; set; }
        public virtual DbSet<VendorDE> Vendor { get; set; }
        public virtual DbSet<VendorTypeDE> VendorType { get; set; }
        public virtual DbSet<VehicleDE> Vehicle { get; set; }
        public virtual DbSet<VehicleFuelDE> VehicleFuel { get; set; }
        public virtual DbSet<EventTypeDE> EventType { get; set; }
        public virtual DbSet<EventDE> Event { get; set; }
        public virtual DbSet<ScheduleDE> Schedule { get; set; }
        public static EMSDbContext Create()
        {
            return new EMSDbContext();
        }

    }
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(EMSDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(EMSDbContext context)
            : base(context)
        {
        }
    }
}
