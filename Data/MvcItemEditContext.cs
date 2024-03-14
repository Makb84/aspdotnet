using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcEcommerce.Models;

namespace MvcEcommerce.Data
{
    public class MvcItemEditContext : DbContext
    {
        public MvcItemEditContext (DbContextOptions<MvcItemEditContext> options)
            : base(options)
        {
        }

        public DbSet<MvcEcommerce.Models.Item> Item { get; set; } = default!;
    }
}
