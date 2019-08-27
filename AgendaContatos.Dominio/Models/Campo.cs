using System.Collections.Generic;

namespace AgendaContatos.Dominio.Models
{
    public class Campo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Tabela Tabela { get; set; }
        public virtual IEnumerable<Tipo> Tipos { get; set; }
    }
}
