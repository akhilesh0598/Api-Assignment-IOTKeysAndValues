using IOTKeyAndValues.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTKeyAndValues.Data
{
    public class KeyValuesStoreContext:DbContext
    {
        public KeyValuesStoreContext(DbContextOptions<KeyValuesStoreContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }
        public DbSet<KeyValue> KeyValues { get; set; }
    }
}
