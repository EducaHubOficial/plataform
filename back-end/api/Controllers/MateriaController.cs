using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Extensions;
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
                var materiaList = materiaRepository.GetMaterias();
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
                var materiaResponse = materiaRepository.GetMateria(id);
                if (materiaResponse == null) return NotFound(new { message = $"Materia não encontrada."});
                return Ok(materiaResponse);
            }
            catch (Exception ex)
            {
                
                return NotFound(new { message = $"Não foi possível localizar a materia. " + ex.Message });
            }
        }
        [HttpPost]
        public ActionResult<Materia> Post([FromBody] Materia materia){
             try
            {
                materiaRepository.Created(materia);
                var location = new Uri(Request.GetEncodedUrl() + "/" + materia.Titulo);

                return Created(location, materia);
            }catch (Exception ex)
            {
                return BadRequest(new { message = $"Não foi possível cadastrar o usuário. " + ex.Message });
            }
        }
    }
}