using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class TipoApplication : IApplication<Tipo>
    {
        private readonly AgendaContatosDbContext _dbContext;

        public TipoApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }

        public void Excluir(int id)
        {
            var tipo = _dbContext.Tipos.First(x => x.Id == id);
            _dbContext.Set<Tipo>().Remove(tipo);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Tipo> Listar(int id = 0)
        {
            var tipos = _dbContext.Tipos.Include(x => x.Campo);
            if (id > 0)
            {
                var tipo = tipos.First(x => x.Id == id);
                var tiposFilter = new List<Tipo> { tipo };
                return tiposFilter;
            }
            return tipos;
        }

        public void Salvar(Tipo entity)
        {
            if (entity.Id > 0)
            {
                var tipo = Listar(entity.Id).FirstOrDefault();
                if (tipo.Descricao != entity.Descricao)
                    tipo.Descricao = entity.Descricao;
                if (tipo.Campo != entity.Campo)
                    tipo.Campo = entity.Campo;
            }
            else
            {
                var campo = new CampoApplication();
                entity.Campo = campo.Listar(entity.Campo.Id).FirstOrDefault();
                _dbContext.Tipos.Add(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
