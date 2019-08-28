using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class EventoApplication : IApplication<Evento>
    {
        private readonly AgendaContatosDbContext _dbContext;

        public EventoApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }

        public void Excluir(int id)
        {
            var evento = _dbContext.Eventos.First(x => x.Id == id);
            _dbContext.Set<Evento>().Remove(evento);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Evento> Listar(int id = 0)
        {
            var eventos = _dbContext.Eventos.Include(x => x.Tipo);
            if (id > 0)
            {
                var evento = eventos.First(x => x.Id == id);
                var eventosFilter = new List<Evento> { evento };
                return eventosFilter;
            }
            return eventos;
        }

        public void Salvar(Evento entity)
        {
            if (entity.Id > 0)
            {
                var evento = Listar(entity.Id).FirstOrDefault();
                if (evento.Data != entity.Data)
                    evento.Data = entity.Data;
                if (evento.Tipo != entity.Tipo)
                    evento.Tipo = entity.Tipo;
            }
            else
            {
                var tipo = new TipoApplication();
                entity.Tipo = tipo.Listar(entity.Tipo.Id).FirstOrDefault();
                _dbContext.Eventos.Add(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
