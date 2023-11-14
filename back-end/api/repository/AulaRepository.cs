using api.Model;

namespace api.Controllers
{
    public class AulaRepository
    {
        private readonly AppDbContext appDbContext;

        public AulaRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Aula> GetAulas()
        {
            return appDbContext.Aulas.ToList<Aula>();;
        }

        public Aula? GetAula(int id) {
            return appDbContext.Aulas.FirstOrDefault(aula => aula.Id == id);
        }

        public void Created(Aula aula) {
            appDbContext.Aulas.Add(aula);
            appDbContext.SaveChanges();
        }
    }
}