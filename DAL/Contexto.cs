using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        //public DbSet<Categorias> Categorias { get; set; }
        public DbSet<TiposEgresos> TiposEgresos { get; set; }
        public DbSet<Presupuestos> Presupuestos { get; set; }
        public Contexto() : base("ConStr")
        {

        }
    }
}
