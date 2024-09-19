﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_RESTful.Models
{
    public class Empleado
    {
        // ATRIBUTOS:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpleado { get; set; }


        [Required]
        public string Nombre { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public double Salario { get; set; }


        [Required]
        public DateTime FechaNacimiento { get; set; }

         
        [Required]
        public string Email { get; set; }


        [Required]
        public string Telefono { get; set; }

    }
}
