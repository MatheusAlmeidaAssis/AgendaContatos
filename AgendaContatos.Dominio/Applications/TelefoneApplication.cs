using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class TelefoneApplication : IApplication<Telefone>
    {
        private readonly AgendaContatosDbContext _dbContext;

        public TelefoneApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }

        public void Excluir(int id)
        {
            var telefone = _dbContext.Telefones.First(x => x.Id == id);
            _dbContext.Set<Telefone>().Remove(telefone);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Telefone> Listar(int id = 0)
        {
            var telefones = _dbContext.Telefones.Include(x => x.Tipo);
            if (id > 0)
            {
                var telefone = telefones.First(x => x.Id == id);
                var telefonesFilter = new List<Telefone> { telefone };
                return telefonesFilter;
            }
            return telefones;
        }

        public void Salvar(Telefone entity)
        {
            if (entity.Id > 0)
            {
                var telefone = Listar(entity.Id).FirstOrDefault();
                if (telefone.Numero != entity.Numero)
                    telefone.Numero = entity.Numero;
                if (telefone.Tipo != entity.Tipo)
                    telefone.Tipo = entity.Tipo;
            }
            else
            {
                var tipo = new TipoApplication();
                entity.Tipo = tipo.Listar(entity.Tipo.Id).FirstOrDefault();
                _dbContext.Telefones.Add(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
