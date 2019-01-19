using System.Data.Entity.Infrastructure;

namespace Topx.Data
{
    using System.Data.Entity;

    public partial class ModelTopX : DbContext
    {
        public ModelTopX()
            : base(@"data source = (LocalDb)\MSSQLLocalDB; initial catalog = Topx.Data.ModelTopX; integrated security = True; MultipleActiveResultSets=True;")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ModelTopX>());
        }
        public ModelTopX(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ModelTopX>());
        }

        public virtual DbSet<Bestand> Bestanden { get; set; }
        public virtual DbSet<Dossier> Dossiers { get; set; }
        public virtual DbSet<FieldMapping> FieldMappings { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Globals> Globals { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dossier>()
                .HasMany(e => e.Bestanden)
                .WithOptional(e => e.Dossiers)
                .HasForeignKey(e => e.Dossier_IdentificatieKenmerk);

            modelBuilder.Entity<Dossier>()
                .HasMany(e => e.Records)
                .WithOptional(e => e.Dossiers)
                .HasForeignKey(e => e.DossierId);
        }
    }
}
