//using dev7.EMS.Domain.BasicInfo;
//using dev7.EMS.DAL.Maps;

//namespace dev7.EMS.DAL.Maps.BasicInfo
//{
//    class BasicInfoMap : BaseTypeConfiguration<BasicInfoDE>
//    {
//        public BasicInfoMap()
//        {
//            this.ToTable("BasicInfo");    //table name
//            //this.Ignore(x => x.SiteCode);       //same
//            //this.Ignore(x => x.Code);           //same
//            this.Ignore(x => x.Msg);            //same
//            this.HasKey(x => x.Id);         //PK
//            this.Property(x => x.FirstName);   //column/attriute
//            this.Property(x => x.LastName);
//            this.Property(x => x.Email);
//            this.Property(x => x.Email);
//            this.Property(x => x.PhoneNumber);
//            this.Property(x => x.DateOfBirth);
//            this.Property(x => x.MeritalStatus);
//            this.Property(x => x.Password);
//            this.Property(x => x.AddressId);
//            this.Property(x => x.IsActive);     //same
//            this.Property(x => x.CreatedById);  //same
//            this.Property(x => x.CreatedDate);  //same
//        }
//    }
//}