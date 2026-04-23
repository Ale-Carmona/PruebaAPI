using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PruebaAPI.Data;
using PruebaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly AppDbContext _db;

        public UsuariosController(AppDbContext db)
        {
            _db = db;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var consulta = await _db.Usuarios.ToListAsync();
            return Ok(consulta);
        }


        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuarios registro)
        {
            _db.Usuarios.Add(registro);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = registro.Id },
                new
                {
                    Ok = true,
                    Message = "Registro creado exitosamente",
                    Data = registro
                });
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuarios registro)
        {
            var consulta = await _db.Usuarios
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();

            if (consulta == null)
            {
                return NotFound(new
                {
                    Ok = false,
                    Message = "Registro no encontrado"
                });
            }

            // Actualizar todos los campos del modelo
            consulta.Nombre = registro.Nombre;
            consulta.Edad = registro.Edad;
            consulta.Matricula = registro.Matricula;
            consulta.Tipo = registro.Tipo;

            _db.Entry(consulta).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(new
            {
                Ok = true,
                Message = "Registro actualizado exitosamente",
                Data = consulta
            });
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var consulta = await _db.Usuarios.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _db.Usuarios.Remove(consulta);
            await _db.SaveChangesAsync();

            return Ok(new
            {
                Ok = true,
                Message = "Registro eliminado exitosamente",
                Data = consulta
            });
        }
    }
}
