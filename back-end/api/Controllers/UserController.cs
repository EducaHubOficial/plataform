using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserRepository userRepository;

        public UserController(AppDbContext appDbContext) {
            this.userRepository = new UserRepository(appDbContext);
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            try
            {
                var lista = userRepository.getUsers();
                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario){
             try
            {
                userRepository.create(usuario);
                var location = new Uri(Request.GetEncodedUrl() + "/" + usuario.Email);

                return Created(location, usuario);
            }catch (Exception ex)
            {
                return BadRequest(new { message = $"Não foi possível cadastrar o usuário. " + ex.Message });
            }
        }

        [HttpGet ("{id}")]
        public ActionResult<Usuario> GetUser(int id) {
            try
            {
                var userResponse = userRepository.getUser(id);
                if (userResponse == null) return NotFound(new { message = $"Usuário não existe."});
                return userResponse;
            }
            catch (Exception ex)
            {
                
                return NotFound(new { message = $"Não foi possível localizar o usuário. " + ex.Message });
            }
        }
    }
}
