using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TestApp_DBContext : DbContext
    {
        public TestApp_DBContext() :base("name=TestAppContext") { }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<DatosPersonales> DatosPersonales { get; set; }
        public DbSet<DatosContacto> DatosContactos { get; set; }

    }
}
