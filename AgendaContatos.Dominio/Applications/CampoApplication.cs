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
        private readonly AgendaContatosDbContext _dbContext = AgendaContatosDbContext.GetDbContext;
        public void Excluir(int id)
        {
            var campo = _dbContext.Campos.First(x => x.Id == id);
            _dbContext.Set<Campo>().Remove(campo);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Campo> Listar(int id = 0)
        {
            if(id > 0)
            {
                var campo = _dbContext.Campos.Include(x => x.Tabela).First(x => x.Id == id);
                var campos = new List<Campo> { campo };
                return campos;
            }
            return _dbContext.Campos.Include(x => x.Tabela);
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
                entity.Tabela = tabela.Listar().FirstOrDefault();
                _dbContext.Campos.Add(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
