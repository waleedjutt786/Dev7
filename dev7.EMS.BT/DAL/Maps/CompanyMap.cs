using dev7.EMS.DAL.Maps;
using dev7.EMS.Domain.Entities;

namespace dev7.EMS.DAL.Maps.Company
{
    class CompanyMap : BaseTypeConfiguration<CompanyDE>
    {
        public CompanyMap()
        {
            this.ToTable("Company");    //table name
            this.Ignore(x => x.Msg);            //same
            //this.HasKey(x => x.Id);         //PK
           
            this.Property(x => x.Name);   //column/attriute
            this.Property(x => x.ImagePath);
            this.Property(x => x.Logo);











            //this.Property(x => x.Email);
            //this.Ignore(x => x.SiteCode);       //same
            //this.Ignore(x => x.Code);           
            //this.Property(x => x.Email);
            //this.Property(x => x.ContactNo);
            //this.Property(x => x.Salt);
            //this.Property(x => x.PasswordForgetKey);

            //this.Property(x => x.Password);
            this.Property(x => x.IsActive);     //same
            this.Property(x => x.CreatedById);  //same
            this.Property(x => x.CreatedDate);  //same
        }
    }
}
