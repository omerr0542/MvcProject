using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        public Context()
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //                        .AddJsonFile("appsettings.json")
        //                        .Build();

        //    var connectionString = config.GetConnectionString("DefaultConnection");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
