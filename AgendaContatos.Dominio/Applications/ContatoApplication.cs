using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.IO;

namespace AgendaContatos.Dominio.Applications
{
    public class ContatoApplication : IApplication<ContatoView>
    {
        private readonly AgendaContatosDbContext _dbContext = AgendaContatosDbContext.GetDbContext;
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
                    .Include(x => x.Grupos);
            var contatosView = new List<ContatoView>();
            foreach (var item in contatos)
            {
                var contatoView = new ContatoView
                {
                    Id = item.Id,
                    Apelido = item.Apelido,
                    Cargo = item.Cargo,
                    ChamadaInternet = item.ChamadaInternet,
                    Emails = item.Emails,
                    Empresa = item.Empresa,
                    Enderecos = item.Enderecos,
                    Eventos = item.Eventos,
                    FoneticaSobrenome = item.FoneticaSobrenome,
                    Foto = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(item.Foto)),
                    Grupos = item.Grupos,
                    Nome = item.Nome,
                    Observacao = item.Observacao,
                    PronunciaNome = item.PronunciaNome,
                    PronunciaNomeMeio = item.PronunciaNomeMeio,
                    Relacionamentos = item.Relacionamentos,
                    Telefones = item.Telefones,
                    Tipos = item.Tipos,
                    Website = item.Website
                };
                contatosView.Add(contatoView);
            }
            if (id > 0)
            {
                var contatoView = contatosView.First(x => x.Id == id);
                var contatosViewId = new List<ContatoView> { contatoView };
                return contatosViewId;
            }
            return contatosView;
        }

        public void Salvar(ContatoView entity)
        {
            if(entity.Id > 0)
            {
                var contato = _dbContext.Contatos.First(x => x.Id == entity.Id);
                var contatoView = Listar(entity.Id).FirstOrDefault();
                if (contatoView.Nome != entity.Nome)
                    contato.Nome = entity.Nome;
                if (contatoView.Grupos != entity.Grupos)
                    contato.Grupos = entity.Grupos;
                if (contatoView.Observacao != entity.Observacao)
                    contato.Observacao = entity.Observacao;
                if (contatoView.PronunciaNome != entity.PronunciaNome)
                    contato.PronunciaNome = entity.PronunciaNome;
                if (contatoView.PronunciaNomeMeio != entity.PronunciaNomeMeio)
                    contato.PronunciaNomeMeio = entity.PronunciaNomeMeio;
                if (contatoView.Relacionamentos != entity.Relacionamentos)
                    contato.Relacionamentos = entity.Relacionamentos;
                if (contatoView.Telefones != entity.Telefones)
                    contato.Telefones = entity.Telefones;
                if (contatoView.Tipos != entity.Tipos)
                    contato.Tipos = entity.Tipos;
                if (contatoView.Website != entity.Website)
                    contato.Website = entity.Website;
                if (contatoView.Apelido != entity.Apelido)
                    contato.Apelido = entity.Apelido;
                if (contatoView.Cargo != entity.Cargo)
                    contato.Cargo = entity.Cargo;
                if (contatoView.ChamadaInternet != entity.ChamadaInternet)
                    contato.ChamadaInternet = entity.ChamadaInternet;
                if (contatoView.Emails != entity.Emails)
                    contato.Emails = entity.Emails;
                if (contatoView.Empresa != entity.Empresa)
                    contato.Empresa = entity.Empresa;
                if (contatoView.Enderecos != entity.Enderecos)
                    contato.Enderecos = entity.Enderecos;
                if (contatoView.Eventos != entity.Eventos)
                    contato.Eventos = entity.Eventos;
                if (contatoView.FoneticaSobrenome != entity.FoneticaSobrenome)
                    contato.FoneticaSobrenome = entity.FoneticaSobrenome;
                if(contatoView.Foto != entity.Foto)
                {
                    using (var binaryReader = new BinaryReader(entity.FotoUpload.InputStream))
                        contato.Foto = binaryReader.ReadBytes(entity.FotoUpload.ContentLength);
                }                
            }
            else
            {
                //entity.
            }
        }
    }
}
