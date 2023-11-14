using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly AulaRepository aulaRepository;

        public AulaController(AppDbContext appDbContext)
        {
            aulaRepository = new AulaRepository(appDbContext);
        }

        [HttpGet]
        public ActionResult<List<Aula>> GetAll(){
            try
            {
                var materiaList = aulaRepository.GetAulas();
                if (materiaList != null) {
                    return Ok(materiaList);
                } else {
                    return NotFound(new { message = $"Não há matéria cadastrada."});
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Não foi possível listar os usuários. " + ex.Message });
            }
        }
        [HttpGet ("{id}")]
        public ActionResult<Materia> GetMateria(int id) {
            try
            {
                var materiaResponse = aulaRepository.GetAula(id);
                if (materiaResponse == null) return NotFound(new { message = $"Materia não encontrada."});
                return Ok(materiaResponse);
            }
            catch (Exception ex)
            {
                
                return NotFound(new { message = $"Não foi possível localizar a materia. " + ex.Message });
            }
        }
        [HttpPost]
        public ActionResult<Aula> Post([FromBody] Aula aula){
             try
            {
                aulaRepository.Created(aula);
                var location = new Uri(Request.GetEncodedUrl() + "/" + aula.Id);

                return Created(location, aula);
            }catch (Exception ex)
            {
                return BadRequest(new { message = $"Não foi possível cadastrar o usuário. " + ex.Message });
            }
        }
    }
}