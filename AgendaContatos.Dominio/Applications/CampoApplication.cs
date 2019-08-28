using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class CampoApplication : IApplication<Campo>
    {
        private readonly AgendaContatosDbContext _dbContext;
        public CampoApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }

        public void Excluir(int id)
        {
            var campo = _dbContext.Campos.First(x => x.Id == id);
            _dbContext.Set<Campo>().Remove(campo);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Campo> Listar(int id = 0)
        {
            var campos = _dbContext.Campos.Include(x => x.Tabela);
            if (id > 0)
            {
                var campo = campos.First(x => x.Id == id);
                var camposFilter = new List<Campo> { campo };
                return camposFilter;
            }
            return campos;
        }

        public void Salvar(Campo entity)
        {
            if(entity.Id > 0)
            {
                var campo = Listar(entity.Id).FirstOrDefault();
                if (campo.Nome != entity.Nome)
                    campo.Nome = entity.Nome;
                if (campo.Tabela != entity.Tabela)
                    campo.Tabela = entity.Tabela;
            }
            else
            {
                var tabela = new TabelaApplication();
                entity.Tabela = tabela.Listar(entity.Tabela.Id).FirstOrDefault();
                _dbContext.Campos.Add(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
