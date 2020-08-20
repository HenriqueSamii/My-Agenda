using System.Collections.Generic;
using System.Threading.Tasks;
using MyAgenda.API.Models.Class;

namespace MyAgenda.API.Data.Interface
{
    public interface IUsuarioRepository
    {
         Task<Usuario> ContaUsuarioLogado(int id);
         Task<ICollection<Usuario>> TodosUsuarios();
    }
}