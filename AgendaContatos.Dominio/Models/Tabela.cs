using System.Collections.Generic;

namespace AgendaContatos.Dominio.Models
{
    public class Tabela
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Campo> Campos { get; set; }
    }
}
