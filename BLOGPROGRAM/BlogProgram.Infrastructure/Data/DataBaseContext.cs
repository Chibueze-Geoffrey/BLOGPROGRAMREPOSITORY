using BlogProgram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProgram.Infrastructure.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
