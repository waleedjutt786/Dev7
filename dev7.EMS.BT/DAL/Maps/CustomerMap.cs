using dev7.EMS.Domain.Customer;
using dev7.EMS.DAL.Maps;

namespace dev7.EMS.DAL.Maps.Customer
{
    class CustomerMap : BaseTypeConfiguration<CustomerDE>
    {
        public CustomerMap()
        {
            this.ToTable("Customer");    //table name
            //this.Ignore(x => x.SiteCode);       //same
            //this.Ignore(x => x.Code);           //same
            this.Ignore(x => x.Msg);            //same
            this.HasKey(x => x.Id);         //PK
            //this.Property(x => x.DateOfRegistration);   //column/attriute
            //this.Property(x => x.BasicInfoId);
            this.Property(x => x.CompanyId);
            this.Property(x => x.IsActive);     //same
            this.Property(x => x.CreatedById);  //same
            this.Property(x => x.CreatedDate);  //same
        }
    }
}
