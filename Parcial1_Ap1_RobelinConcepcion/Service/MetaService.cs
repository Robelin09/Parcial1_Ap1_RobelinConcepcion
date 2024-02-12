using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_RobelinConcepcion.DAL;
using Parcial1_Ap1_RobelinConcepcion.Models;
using System.Linq.Expressions;

namespace Parcial1_Ap1_RobelinConcepcion.Service
{
    public class MetaService
    {
        private readonly Contexto _contexto;
        public MetaService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int MetaId)
        {
            return await _contexto.Metas.AnyAsync(m => m.MetaId == MetaId);
        }
        public async Task<bool> Insertar(Metas meta)
        {
            _contexto.Metas.Add(meta);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Metas meta)
        {
            var m = await _contexto.Metas.FindAsync(meta.MetaId);
            _contexto.Entry(m!).State = EntityState.Detached;
            _contexto.Entry(meta).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Metas meta)
        {
            if (!await Existe(meta.MetaId))
                return await Insertar(meta);
            else
                return await Modificar(meta);
        }
        public async Task<bool> Eliminar(Metas meta)
        {
            var m = await _contexto.Metas.FindAsync(meta.MetaId);
            _contexto.Entry(m!).State = EntityState.Detached;
            _contexto.Entry(meta).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Metas?> Buscar(int MetaId)
        {
            return await _contexto.Metas
                .Where(a => a.MetaId == MetaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Metas>> Listar(Expression<Func<Metas, bool>> criterio)
        {
            return await _contexto.Metas
                 .Where(criterio)
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
