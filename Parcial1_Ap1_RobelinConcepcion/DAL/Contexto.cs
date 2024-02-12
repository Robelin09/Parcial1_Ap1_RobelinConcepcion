using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_RobelinConcepcion.Models;

namespace Parcial1_Ap1_RobelinConcepcion.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Metas> Metas { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
