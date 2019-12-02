using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroceryStores.Models
{
    public class GroceryStoresContext : DbContext
    {
        public GroceryStoresContext (DbContextOptions<GroceryStoresContext> options)
            : base(options)
        {
        }

        public DbSet<GroceryStores.Models.GroceryStoreSurvey> GroceryStoreSurvey { get; set; }
    }
}
