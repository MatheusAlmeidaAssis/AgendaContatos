using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class ContatoApplication : IApplication<ContatoView>
    {
        private readonly AgendaContatosDbContext _dbContext;

        public ContatoApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }

        public void Excluir(int id)
        {
            var contato = _dbContext.Contatos.First(x => x.Id == id);
            contato.Telefones = null;
            contato.Emails = null;
            contato.Enderecos = null;
            contato.Eventos = null;
            contato.Relacionamentos = null;
            contato.Tipos = null;
            contato.Grupos = null;
            _dbContext.Set<Contato>().Remove(contato);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ContatoView> Listar(int id = 0)
        {
            var contatos = _dbContext.Contatos.Include(x => x.Telefones).Include(x => x.Telefones.Select(t => t.Tipo))
                    .Include(x => x.Emails).Include(x => x.Emails.Select(t => t.Tipo))
                    .Include(x => x.Enderecos).Include(x => x.Enderecos.Select(t => t.Tipo))
                    .Include(x => x.Eventos).Include(x => x.Enderecos.Select(t => t.Tipo))
                    .Include(x => x.Relacionamentos).Include(x => x.Relacionamentos.Select(t => t.Tipos))
                    .Include(x => x.Tipos).Include(x => x.Tipos.Select(c => c.Campo))
                    .Include(x => x.Grupos); ;
            var contatosView = new List<ContatoView>();
            foreach (var item in contatos)
            {
                if (id > 0)
                {
                    if (item.Id == id)
                    {
                        var contatosViewFilter = new List<ContatoView> { item.ToContatoView() };
                        return contatosViewFilter;
                    }
                }
                contatosView.Add(item.ToContatoView());
            }
            return contatosView;
        }

        public void Salvar(ContatoView entity)
        {
            var entityContato = entity.ToContato();
            if (entityContato.Id > 0)
            {
                var contato = Listar(entity.Id).FirstOrDefault().ToContato();
                if (contato.Nome != entityContato.Nome)
                    contato.Nome = entityContato.Nome;
                if (contato.FoneticaSobrenome != entityContato.FoneticaSobrenome)
                    contato.FoneticaSobrenome = entityContato.FoneticaSobrenome;
                if (contato.PronunciaNomeMeio != entityContato.PronunciaNomeMeio)
                    contato.PronunciaNomeMeio = entityContato.PronunciaNomeMeio;
                if (contato.PronunciaNome != entityContato.PronunciaNome)
                    contato.PronunciaNome = entityContato.PronunciaNome;
                if (contato.Foto != entityContato.Foto)
                    contato.Foto = entityContato.Foto;
                if (contato.Empresa != entityContato.Empresa)
                    contato.Empresa = entityContato.Empresa;
                if (contato.Cargo != entityContato.Cargo)
                    contato.Cargo = entityContato.Cargo;
                if (contato.Telefones != entityContato.Telefones)
                    contato.Telefones = entityContato.Telefones;
                if (contato.Emails != entityContato.Emails)
                    contato.Emails = entityContato.Emails;
                if (contato.Enderecos != entityContato.Enderecos)
                    contato.Enderecos = entityContato.Enderecos;
                if (contato.Observacao != entityContato.Observacao)
                    contato.Observacao = entityContato.Observacao;
                if (contato.Apelido != entityContato.Apelido)
                    contato.Apelido = entityContato.Apelido;
                if (contato.Website != entityContato.Website)
                    contato.Website = entityContato.Website;
                if (contato.ChamadaInternet != entityContato.ChamadaInternet)
                    contato.ChamadaInternet = entityContato.ChamadaInternet;
                if (contato.Eventos != entityContato.Eventos)
                    contato.Eventos = entityContato.Eventos;
                if (contato.Relacionamentos != entityContato.Relacionamentos)
                    contato.Relacionamentos = entityContato.Relacionamentos;
                if (contato.Tipos != entityContato.Tipos)
                    contato.Tipos = entityContato.Tipos;
                if (contato.Grupos != entityContato.Grupos)
                    contato.Grupos = entityContato.Grupos;
            }
            else
            {
                entityContato.Telefones = entityContato.Telefones.Select(t => _dbContext.Telefones.FirstOrDefault(x => x.Id == t.Id)).ToList();
                entityContato.Emails = entityContato.Emails.Select(e => _dbContext.Emails.FirstOrDefault(x => x.Id == e.Id)).ToList();
                entityContato.Enderecos = entityContato.Enderecos.Select(e => _dbContext.Enderecos.FirstOrDefault(x => x.Id == e.Id)).ToList();
                entityContato.Eventos = entityContato.Eventos.Select(e => _dbContext.Eventos.FirstOrDefault(x => x.Id == e.Id)).ToList();
                entityContato.Relacionamentos = entityContato.Relacionamentos.Select(r => _dbContext.Contatos.FirstOrDefault(x => x.Id == r.Id)).ToList();
                entityContato.Tipos = entityContato.Tipos.Select(t => _dbContext.Tipos.FirstOrDefault(x => x.Id == t.Id)).ToList();
                entityContato.Grupos = entityContato.Grupos.Select(g => _dbContext.Grupos.FirstOrDefault(x => x.Id == g.Id)).ToList();
                _dbContext.Contatos.Add(entityContato);
            }                
            _dbContext.SaveChanges();
        }
    }
}
