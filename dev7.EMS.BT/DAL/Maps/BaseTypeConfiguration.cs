using System.Data.Entity.ModelConfiguration;

namespace dev7.EMS.DAL.Maps
{
    public abstract class BaseTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected BaseTypeConfiguration()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }

        public string SchemaName { get { return "dbo"; } }
    }
}
