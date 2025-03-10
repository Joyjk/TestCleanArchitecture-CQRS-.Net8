using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Model;

namespace Test.Infracture.DBContext
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { set; get; }
        public DbSet<Product> Products { set; get; }
    }
}
