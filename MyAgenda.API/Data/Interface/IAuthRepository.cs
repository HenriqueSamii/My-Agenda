using System.Threading.Tasks;
using MyAgenda.API.Models.Class;

namespace MyAgenda.API.Data.Interface
{
    public interface IAuthRepository
    {
         Task<Usuario> Register(Usuario user, string password);
         Task<Usuario> Login (string name, string password);
         Task<bool> UserExists (string name);
    }
}