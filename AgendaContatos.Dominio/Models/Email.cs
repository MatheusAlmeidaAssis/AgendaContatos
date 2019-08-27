using System.Collections.Generic;
using System.ComponentModel;

namespace AgendaContatos.Dominio.Models
{
    public class Email
    {
        public int Id { get; set; }
        [DisplayName("E - Mail")]
        public string Endereco { get; set; }
        public Tipo Tipo { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
