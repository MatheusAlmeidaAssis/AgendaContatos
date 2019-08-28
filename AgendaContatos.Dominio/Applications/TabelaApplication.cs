using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class TabelaApplication : IApplication<Tabela>
    {
        private readonly AgendaContatosDbContext _dbContext;
        public TabelaApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }
        public void Excluir(int id)
        {
            var tabela = _dbContext.Tabelas.First(x => x.Id == id);
            _dbContext.Set<Tabela>().Remove(tabela);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Tabela> Listar(int id = 0)
        {
            var tabelas = _dbContext.Tabelas;
            if (id > 0)
            {
                var tabela = tabelas.First(x => x.Id == id);
                var tabelasFilter = new List<Tabela> { tabela };
                return tabelasFilter;
            }
            return tabelas;
        }

        public void Salvar(Tabela entity)
        {
            if (entity.Id > 0)
            {
                var tabela = Listar(entity.Id).FirstOrDefault();
                if (tabela.Nome != entity.Nome)
                    tabela.Nome = entity.Nome;               
            }
            else
            {                
                _dbContext.Tabelas.Add(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
