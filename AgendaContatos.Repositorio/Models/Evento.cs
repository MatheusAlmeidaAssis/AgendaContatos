using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Repositorio.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Tipo Tipo { get; set; }
    }
}
