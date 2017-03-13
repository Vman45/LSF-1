using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LSFDictionary.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Dictionary> Dictionaries { get; set; }
        
    }
}