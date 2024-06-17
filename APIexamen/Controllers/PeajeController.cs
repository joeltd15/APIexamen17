using APIexamen.Data;
using APIexamen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIexamen.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PeajeController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public PeajeController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IEnumerable<Peaje>> GetPeajes()
            {
                return await _context.Peajes.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Peaje>> GetPeajes(int id)
            {
                var peaje = await _context.Peajes.FindAsync(id);

                if (peaje == null)
                {
                    return NotFound();
                }

                return peaje;
            }

            [HttpPost]
            public async Task<ActionResult<IEnumerable<Peaje>>> PostPeajes(Peaje Peaje)
            {

                _context.Peajes.Add(Peaje);
                await _context.SaveChangesAsync(); //guardar en la base de datos
                return Created("se creo", Peaje);//retorna el objeto insertado
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Peaje>> PutPeajes(int id, Peaje Peajes)
            {
                if (id != Peajes.Id)
                {
                    return BadRequest();//retornar peticion incorrecta
                }
                _context.Entry(Peajes).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();//realiza cambios en la bd
                    return (Peajes);//retorna el objeto que se modifico
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);//retorna mensaje de error
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePeajes(int id)
            {
                var peaje = await _context.Peajes.FindAsync(id);
                if (peaje == null)
                {
                    return NotFound();
                }
                _context.Peajes.Remove(peaje);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            private bool UserExists(int id)
            {
                return _context.Peajes.Any(e => e.Id == id);
            }
        }
    }