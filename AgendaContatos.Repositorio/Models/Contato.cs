using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Repositorio.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string FoneticaSobrenome { get; set; }        
        public string PronunciaNomeMeio { get; set; }
        public string PronunciaNome { get; set; }
        public  byte[] Foto { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        public string Observacao { get; set; }
        public Grupo Grupo { get; set; }
    }
}
