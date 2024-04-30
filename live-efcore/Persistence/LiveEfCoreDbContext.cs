using live_efcore.Entities;
using Microsoft.EntityFrameworkCore;

namespace live_efcore.Persistence
{
    public class LiveEfCoreDbContext: DbContext
    {
        public LiveEfCoreDbContext(DbContextOptions<LiveEfCoreDbContext> options):base(options) { }

        public DbSet<School> Schools{ get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<School>()
                    .ToTable("School");

            modelBuilder
                   .Entity<School>()
                   .HasKey( s => s.Id );
            
            modelBuilder
                .Entity<ContactInformation>()
                .HasKey(s =>s.Id);


            //modelBuilder
            //    .Entity<School>()
            //    .Property(s => s.Id)
            //    .HasDefaultValueSql("NEWID()");


            modelBuilder
                .Entity<School>()
                .HasData(new School(1, "Escola Daora"), new School(2, "Escola Supimpa"));

            modelBuilder
                      .Entity<School>()
                      .HasMany(school =>school.Students)
                      .WithOne(s => s.School)
                      .HasForeignKey(s => s.SchoolId)
                      .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                       .Entity<School>()
                       .HasOne(s => s.ContactInformation)
                       .WithOne()
                       .HasForeignKey<ContactInformation>(s => s.SchoolId)
                       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
