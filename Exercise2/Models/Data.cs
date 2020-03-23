using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise2.Models
{
    public class Data:DbContext
    {
        public DbSet<Friend> friends { get; set; }
    public Data(DbContextOptions<Data> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
