using System.Collections.Generic;

namespace AgendaContatos.Dominio.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
