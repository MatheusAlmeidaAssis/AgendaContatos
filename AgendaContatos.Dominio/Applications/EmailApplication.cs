using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class EmailApplication : IApplication<Email>
    {
        private readonly AgendaContatosDbContext _dbContext;

        public EmailApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }

        public void Excluir(int id)
        {
            var email = _dbContext.Emails.First(x => x.Id == id);
            _dbContext.Set<Email>().Remove(email);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Email> Listar(int id = 0)
        {
            var emails = _dbContext.Emails.Include(x => x.Tipo);
            if (id > 0)
            {
                var email = emails.First(x => x.Id == id);
                var emailsFilter = new List<Email> { email };
                return emailsFilter;
            }
            return emails;
        }

        public void Salvar(Email entity)
        {
            if (entity.Id > 0)
            {
                var email = Listar(entity.Id).FirstOrDefault();
                if (email.Endereco != entity.Endereco)
                    email.Endereco = entity.Endereco;
                if (email.Tipo != entity.Tipo)
                    email.Tipo = entity.Tipo;
            }
            else
            {
                var tipo = new TipoApplication();
                entity.Tipo = tipo.Listar(entity.Tipo.Id).FirstOrDefault();
                _dbContext.Emails.Add(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
