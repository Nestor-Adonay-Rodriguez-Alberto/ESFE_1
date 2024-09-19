using API_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Transferencia_Datos.Empleado_DTO;
using Microsoft.EntityFrameworkCore;

namespace API_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        // Representa La DB: 
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public EmpleadoController(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }




        // ****** ENDPOINTS QUE MANDARAN OBJETOS *******
        // ***********************

        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Obtenemos Todos Los Registros:
            List<Empleado> Registros_Empleados = await _MyDBcontext.Empleados.ToListAsync();

            // La Lista de este Objeto Retornaremos:
            Registrados_Empleado_DTO Objeto_Empleado = new Registrados_Empleado_DTO();

            // Agregamos cada registro obtenido a la lista que retornaremos:
            foreach (Empleado empleado in Registros_Empleados)
            {
                Objeto_Empleado.Lista_Empleados.Add(new Registrados_Empleado_DTO.Empleado
                {
                    IdEmpleado = empleado.IdEmpleado,
                    Nombre = empleado.Nombre,
                    Salario = empleado.Salario,
                    FechaNacimiento = empleado.FechaNacimiento,
                    Email = empleado.Email,
                    Telefono = empleado.Telefono
                });

            }

            return Ok(Objeto_Empleado);
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Obtenemos de la DB:
            Empleado? Objeto_Obtenido = await _MyDBcontext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);

            if (Objeto_Obtenido != null)
            {
                // Agregamos los Datos del de la DB:
                ObtenerPorID_Empleado_DTO Registro_Obtenido = new ObtenerPorID_Empleado_DTO
                {
                    IdEmpleado = Objeto_Obtenido.IdEmpleado,
                    Nombre = Objeto_Obtenido.Nombre,
                    Salario = Objeto_Obtenido.Salario,
                    FechaNacimiento = Objeto_Obtenido.FechaNacimiento,
                    Email = Objeto_Obtenido.Email,
                    Telefono = Objeto_Obtenido.Telefono
                };

                return Ok(Registro_Obtenido);

            }
            else
            {
                return NotFound("Registro No Existente.");
            }

        }






        // ***  ENPOINTS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ***
        // ************************

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Crear_Empleado_DTO crear_Empleado_DTO)
        {
            // Objeto a guardar en la DB:
            Empleado empleado = new Empleado
            {
                Nombre = crear_Empleado_DTO.Nombre,
                Salario = crear_Empleado_DTO.Salario,
                FechaNacimiento = crear_Empleado_DTO.FechaNacimiento,
                Email = crear_Empleado_DTO.Email,
                Telefono = crear_Empleado_DTO.Telefono
            };

            _MyDBcontext.Add(empleado);
            await _MyDBcontext.SaveChangesAsync();

            return Ok("Guardado Correctamente");
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MODIFICA
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Editar_Empleado_DTO editar_Empleado_DTO)
        {
            // Obtenemos de la DB:
            Empleado? Objeto_Obtenido = await _MyDBcontext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == editar_Empleado_DTO.IdEmpleado);

            if (Objeto_Obtenido != null)
            {
                Objeto_Obtenido.Nombre = editar_Empleado_DTO.Nombre;
                Objeto_Obtenido.Salario = editar_Empleado_DTO.Salario;
                Objeto_Obtenido.FechaNacimiento = editar_Empleado_DTO.FechaNacimiento;
                Objeto_Obtenido.Email = editar_Empleado_DTO.Email;
                Objeto_Obtenido.Telefono = editar_Empleado_DTO.Telefono;
                // Actualizamos:
                _MyDBcontext.Update(Objeto_Obtenido);
                await _MyDBcontext.SaveChangesAsync();

                return Ok("Modificado Exitosamente.");
            }
            else
            {
                return NotFound("No Se Encontro El Registro.");
            }

        }


        // OBTIENE UN REGISTRO CON EL MISMO ID Y LO ELIMINA:s
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Obtenemos de la DB:
            Empleado? Objeto_Obtenido = await _MyDBcontext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);

            if (Objeto_Obtenido != null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
                await _MyDBcontext.SaveChangesAsync();

                return Ok("Eliminado Correctamente.");
            }
            else
            {
                return NotFound("No Se Encontro El Registro.");
            }

        }


    }
}
