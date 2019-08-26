using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Repositorio.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Endereco { get; set; }
        public Tipo Tipo { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
