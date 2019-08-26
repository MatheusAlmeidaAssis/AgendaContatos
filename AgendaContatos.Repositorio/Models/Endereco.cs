using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Repositorio.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public Tipo TipoLogradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public Tipo TipoEndereco { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
