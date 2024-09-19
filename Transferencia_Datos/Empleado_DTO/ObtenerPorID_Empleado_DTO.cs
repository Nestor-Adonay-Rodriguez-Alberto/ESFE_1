using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia_Datos.Empleado_DTO
{
    public class ObtenerPorID_Empleado_DTO
    {
        // ATRIBUTOS:
        public int IdEmpleado { get; set; }

        public string Nombre { get; set; }

        public double Salario { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; } 

        public string Telefono { get; set; }

    }

}


