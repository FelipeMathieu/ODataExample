using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System.Data.SqlClient;

namespace Context
{
    public class ODataContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ODataContext(IConfiguration configuration, DbContextOptions<ODataContext> options) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var connection = new SqlConnection()
            {
                ConnectionString = configuration["ConnectionStrings:ODataDb"]
            };
            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<People> People { get; set; }
        public DbSet<Phones> Phones { get; set; }
        public DbSet<PersonNumbers> PersonNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetPeopleEntity(modelBuilder);
            SetPhonesEntity(modelBuilder);
            SetPersonNumbersEntity(modelBuilder);
        }

        private void SetPeopleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasIndex(p => p.Name);
        }

        private void SetPhonesEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phones>().HasIndex(p => p.Number);
        }

        private void SetPersonNumbersEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonNumbers>().HasIndex(pn => pn.PersonId);
            modelBuilder.Entity<PersonNumbers>().HasIndex(pn => pn.PhoneId);
        }
    }
}
