using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.Dominio.Models
{
    public class Evento
    {
        public int Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime Data { get; set; }
        public Tipo Tipo { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
