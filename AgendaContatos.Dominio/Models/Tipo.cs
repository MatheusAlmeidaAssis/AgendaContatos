using System.Collections.Generic;

namespace AgendaContatos.Dominio.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Campo Campo { get; set; }
        public virtual IEnumerable<Telefone> Telefones { get; set; }
        public virtual IEnumerable<Evento> Eventos { get; set; }
        public virtual IEnumerable<Endereco> EnderecosLogradouro { get; set; }
        public virtual IEnumerable<Endereco> Enderecos { get; set; }
        public virtual IEnumerable<Email> Emails { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
