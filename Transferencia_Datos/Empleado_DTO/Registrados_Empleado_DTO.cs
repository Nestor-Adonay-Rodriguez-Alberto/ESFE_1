using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia_Datos.Empleado_DTO
{
    public class Registrados_Empleado_DTO
    {
        // CLASE:
        public class Empleado
        {
            // ATRIBUTOS:
            public int IdEmpleado { get; set; }

            public string Nombre { get; set; }

            public double Salaraio { get; set; }

            public DateTime FechaNacimiento { get; set; }

            public string Email { get; set; }

            public string Telefono { get; set; }
        }

        // REGISTROS EN LA DB:
        public List<Empleado> Lista_Empleados { get; set; }


        // CONSTRUCTOR:
        public Registrados_Empleado_DTO()
        {
            Lista_Empleados = new List<Empleado>();
        }
    }
}