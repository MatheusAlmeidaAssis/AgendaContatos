using AgendaContatos.Dominio.DbContexts;
using AgendaContatos.Dominio.Interfaces;
using AgendaContatos.Dominio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AgendaContatos.Dominio.Applications
{
    public class EnderecoApplication : IApplication<Endereco>
    {
        private readonly AgendaContatosDbContext _dbContext;

        public EnderecoApplication()
        {
            _dbContext = new AgendaContatosDbContext();
        }

        public void Excluir(int id)
        {
            var endereco = _dbContext.Enderecos.First(x => x.Id == id);
            _dbContext.Set<Endereco>().Remove(endereco);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Endereco> Listar(int id = 0)
        {
            var enderecos = _dbContext.Enderecos.Include(x => x.Tipo);
            if (id > 0)
            {
                var endereco = enderecos.First(x => x.Id == id);
                var enderecosFilter = new List<Endereco> { endereco };
                return enderecosFilter;
            }
            return enderecos;
        }

        public void Salvar(Endereco entity)
        {
            if (entity.Id > 0)
            {
                var endereco = Listar(entity.Id).FirstOrDefault();
                if (endereco.Logradouro != entity.Logradouro)
                    endereco.Logradouro = entity.Logradouro;
                if (endereco.Numero != entity.Numero)
                    endereco.Numero = entity.Numero;
                if (endereco.Complemento != entity.Complemento)
                    endereco.Complemento = entity.Complemento;
                if (endereco.Bairro != entity.Bairro)
                    endereco.Bairro = entity.Bairro;
                if (endereco.Cidade != entity.Cidade)
                    endereco.Cidade = entity.Cidade;
                if (endereco.UF != entity.UF)
                    endereco.UF = entity.UF;
                if (endereco.Tipo != entity.Tipo)
                    endereco.Tipo = entity.Tipo;
            }
            else
            {
                var tipo = new TipoApplication();
                entity.Tipo = tipo.Listar(entity.Tipo.Id).FirstOrDefault();
                _dbContext.Enderecos.Add(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
