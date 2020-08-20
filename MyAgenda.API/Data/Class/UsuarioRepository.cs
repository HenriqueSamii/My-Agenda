using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAgenda.API.Data.Interface;
using MyAgenda.API.Models.Class;

namespace MyAgenda.API.Data.Class
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext context;
        
        public UsuarioRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> ContaUsuarioLogado(int id)
        {
            var x = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Id == id); 
            return x;
        }

        public async Task<ICollection<Usuario>> TodosUsuarios()
        {
            var x = await this.context.Usuarios.ToListAsync();
            return x;
        }
    }
}