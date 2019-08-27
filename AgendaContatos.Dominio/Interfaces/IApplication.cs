using System.Collections.Generic;

namespace AgendaContatos.Dominio.Interfaces
{
    public interface IApplication<T> where T : class
    {        
        void Salvar(T entity);
        IEnumerable<T> Listar(int id = 0);
        void Excluir(int id);
    }
}
