using dev7.EMS.Domain.Employee;
using dev7.EMS.DAL.Maps;

namespace dev7.EMS.DAL.Maps.Employee
{
    class EmployeeMap : BaseTypeConfiguration<EmployeeDE>
    {
        public EmployeeMap()
        {
            this.ToTable("Employee");    //table name
            //this.Ignore(x => x.SiteCode);       //same
            //this.Ignore(x => x.Code);           //same
            this.Ignore(x => x.Msg);            //same
            //this.HasKey(x => x.Id);         //PK
            
            
            //this.Property(x => x.PayRate);   //column/attriute
            //this.Property(x => x.ExperianceLevel);
            //this.Property(x => x.EducationLevel);
            //this.Property(x => x.DateOfHire);
            //this.Property(x => x.Salary);
            //this.Property(x => x.DateOfLeaving);
            //this.Property(x => x.BasicInfoId);
            this.Property(x => x.CompanyId);
            this.Property(x => x.IsActive);     //same
            this.Property(x => x.CreatedById);  //same
            this.Property(x => x.CreatedDate);  //same
        }
    }
}
