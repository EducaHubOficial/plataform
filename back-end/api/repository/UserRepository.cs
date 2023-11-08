using api.Model;

namespace api.Repository
{
    
    public class UserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }

        public IList<Usuario> getUsers() { 
            var lista = new List<Usuario>();
            lista = dbContext.Usuarios.ToList<Usuario>();
            return lista;
        }

    }
}