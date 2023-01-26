using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Data
{
    public class ApplicationDB:DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {


        }
        public DbSet<Models.Category> Categories { get; set; }

        internal Category Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
