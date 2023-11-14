
using api.Model;

namespace api.Controllers
{
    public class MateriaRepository
    {
        private readonly AppDbContext appDbContext;

        public MateriaRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Materia> getMaterias()
        {
            return appDbContext.Materias.ToList<Materia>();;
        }
    }
}