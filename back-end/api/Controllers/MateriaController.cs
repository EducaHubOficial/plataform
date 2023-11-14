using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly MateriaRepository materiaRepository;

        public MateriaController(AppDbContext appDbContext)
        {
            materiaRepository = new MateriaRepository(appDbContext);
        }

        [HttpGet]
        public ActionResult<List<Materia>> GetAll(){
            try
            {
                var materiaList = materiaRepository.getMaterias();
                if (materiaList != null) {
                    return Ok(materiaList);
                } else {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Não foi possível listar os usuários. " + ex.Message });
            }
        }
    }
}