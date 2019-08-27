using System.Collections.Generic;
using System.ComponentModel;

namespace AgendaContatos.Dominio.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }        
        [DisplayName("Número")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public Tipo Tipo { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
