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
    public class Tabla1Controller : ControllerBase
    {
        private readonly AppDbContext _db;

        public Tabla1Controller(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/<Tabla1Controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var consulta = await _db.Tabla1.ToListAsync();
            return Ok(new { exito = true, consulta });

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var consulta = await _db.Tabla1.Where(p => p.Id.Equals(id)).ToListAsync();

            return Ok(new { exito = true, consulta });
        }

        // POST api/<Tabla1Controller>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tabla1 registro)
        {
            _db.Tabla1.Add(registro);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = registro.Id },
                new
                {
                    Ok = true,
                    Message = "Registro creado exitosamente",
                    Data = registro
                });

        }

        // PUT api/<Tabla1Controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Tabla1 registro)
        {

            var consulta = await _db.Tabla1.FirstOrDefaultAsync();

            consulta.Nombre = registro.Nombre;
            consulta.Apellido = registro.Apellido;
            consulta.Descripcion = registro.Descripcion;


            _db.Entry(consulta).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(new
            {
                Ok = true,
                Message = "Registro actualizado exitosamente",
                Data = registro
            });
        }

        // DELETE api/<Tabla1Controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var consulta = await _db.Tabla1.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _db.Tabla1.Remove(consulta);
            await _db.SaveChangesAsync();

            return Ok(new
            {
                Ok = true,
                Message = "Registro eliminado exitosamente",
                Data = consulta
            });
        }

        [HttpPatch("{id}")]// PATCH api/<Tabla1Controller>/5
        public async Task<ActionResult> PatchTabla1(int id, [FromBody] Dictionary<string, object> actual)
        {
            var registro = await _db.Tabla1.FindAsync(id);

            foreach (var item in actual)
            {
                switch (item.Key.ToLower())
                {
                    case "nombre":
                        registro.Nombre = item.Value.ToString();
                        break;
                    case "apellido":
                        registro.Apellido = item.Value.ToString();
                        break;
                    case "descripcion":
                        registro.Descripcion = item.Value.ToString();
                        break;
                }
            }

            await _db.SaveChangesAsync();

            return Ok(new
            {
                Ok = true,
                Message = "Registro actualizado exitosamente",
                Data = registro
            });
        }

        //private int convierteEnEntero(object value)
        //{
        //    if (value == null)
        //        return 0;


        //    if (value is JsonContent elementojson)
        //    {
        //        return elementojson.GetInt32();
        //    }

        //    if (value is string cadenavalor)
        //    {
        //        return int.Parse(cadenavalor);
        //    }

        //    return Convert.ToInt32(value);
        //}
    }
}

