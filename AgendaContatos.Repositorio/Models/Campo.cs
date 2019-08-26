using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Repositorio.Models
{
    public class Campo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Campo> Campos { get; set; }
    }
}
