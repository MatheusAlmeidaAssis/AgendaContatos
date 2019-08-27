using System.Collections.Generic;
using System.ComponentModel;

namespace AgendaContatos.Dominio.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        [DisplayName("Número")]
        public string Numero { get; set; }
        public Tipo Tipo { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
