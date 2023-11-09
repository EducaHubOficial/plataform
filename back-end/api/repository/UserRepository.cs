using api.Model;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace api.Repository
{
    
    public class UserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }

        public List<Usuario> getUsers() { 
            var lista = new List<Usuario>();
            lista = dbContext.Usuarios.ToList<Usuario>();
            return lista;
        }

        public void create(Usuario usuario) {
            dbContext.Usuarios.Add(usuario);
            dbContext.SaveChanges();
        }

        public Usuario? getUser(int id) {
            return dbContext.Usuarios.FirstOrDefault(user => user.Id == id);
        }

        public Usuario? getUser(string email, string password) {
            var userResponse = dbContext.Usuarios.FirstOrDefault(user => user.Email == email);
            if (userResponse != null) {
                string hash = password + userResponse.Salt;
                if (userResponse.Hash == hash) return userResponse;
            }
            return null;
        }

    }
}