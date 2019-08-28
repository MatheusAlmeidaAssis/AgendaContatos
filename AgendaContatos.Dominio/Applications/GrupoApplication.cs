using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class GrupoApplication : IApplication<Grupo>
    {
        private readonly AgendaContatosDbContext _dbContext;

        public GrupoApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }

        public void Excluir(int id)
        {
            var grupo = _dbContext.Grupos.First(x => x.Id == id);
            _dbContext.Set<Grupo>().Remove(grupo);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Grupo> Listar(int id = 0)
        {
            var grupos = _dbContext.Grupos;
            if (id > 0)
            {
                var grupo = grupos.First(x => x.Id == id);
                var gruposFilter = new List<Grupo> { grupo };
                return gruposFilter;
            }
            return grupos;
        }

        public void Salvar(Grupo entity)
        {
            if (entity.Id > 0)
            {
                var grupo = Listar(entity.Id).FirstOrDefault();
                if (grupo.Nome != entity.Nome)
                    grupo.Nome = entity.Nome;
            }
            else
                _dbContext.Grupos.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
