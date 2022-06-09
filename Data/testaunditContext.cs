using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testaundit.Models;

namespace testaundit.Data
{
    public class testaunditContext : DbContext
    {
        public testaunditContext (DbContextOptions<testaunditContext> options)
            : base(options)
        {
        }

        public DbSet<testaundit.Models.blog>? blog { get; set; }
    }
}
