using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Repositorio.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public Tipo Tipo { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
