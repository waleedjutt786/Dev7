//using dev7.EMS.Domain.Address;
//using dev7.EMS.DAL.Maps;

//namespace dev7.EMS.DAL.Maps.Address
//{
//    public   class AddressMap:BaseTypeConfiguration<AddressDE>
//    {
//        public AddressMap()
//        {
//            this.ToTable("Address");    //table name
//            //this.Ignore(x => x.SiteCode);       //same
//            //this.Ignore(x => x.Code);           //same
//            this.Ignore(x => x.Msg);            //same
//            this.HasKey(x => x.Id);         //PK
//            this.Property(x => x.Id);   //column/attriute
//            this.Property(x => x.Address);
//            this.Property(x => x.ZipCode);
//            this.Property(x => x.Country);
//            this.Property(x => x.City);
//            this.Property(x => x.IsActive);     //same
//            this.Property(x => x.CreatedById);  //same
//            this.Property(x => x.CreatedDate);  //same
//        }
//    }
//}
