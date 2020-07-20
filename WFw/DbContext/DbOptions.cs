using Microsoft.Extensions.Options;

namespace WFw.DbContext
{
    public class DbOptions : IOptions<DbOptions>
    {
        public DbOptions Value => this;

        public string ConnectionString { get; set; }
        public string DatabaseType { get; set; }
        //public bool AuditEntityEnabled { get; set; }
        //public bool AutoMigrationEnabled { get; set; }
    }
}
