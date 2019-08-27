using System.Collections.Generic;
using System.ComponentModel;

namespace AgendaContatos.Dominio.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Fonética do Sobrenome")]
        public string FoneticaSobrenome { get; set; }
        [DisplayName("Pronúncia do Nome do Meio")]
        public string PronunciaNomeMeio { get; set; }
        [DisplayName("Pronúncia do Nome")]
        public string PronunciaNome { get; set; }
        public byte[] Foto { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        [DisplayName("E - Mails")]
        public ICollection<Email> Emails { get; set; }
        [DisplayName("Endereços")]
        public ICollection<Endereco> Enderecos { get; set; }
        [DisplayName("Observações")]
        public string Observacao { get; set; }
        public string Apelido { get; set; }
        public string Website { get; set; }
        [DisplayName("Chamada Via Internet")]
        public string ChamadaInternet { get; set; }
        public ICollection<Evento> Eventos { get; set; }
        public ICollection<Contato> Relacionamentos { get; set; }
        public ICollection<Tipo> Tipos { get; set; }
        public ICollection<Grupo> Grupos { get; set; }        
        public virtual ICollection<Contato> ContatoRelacionamentos { get; set; }
    }
}
