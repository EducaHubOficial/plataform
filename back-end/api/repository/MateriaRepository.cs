
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

        public List<Materia> GetMaterias()
        {
            return appDbContext.Materias.ToList<Materia>();;
        }

        public Materia? GetMateria(int id) {
            return appDbContext.Materias.FirstOrDefault(materia => materia.Id == id);
        }

        public void Created(Materia materia) {
            appDbContext.Materias.Add(materia);
            appDbContext.SaveChanges();
        }
    }
}