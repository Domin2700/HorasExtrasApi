using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorasExtrasAPI.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [MaxLength(25)]
        public string User { get; set; }
        [MinLength(8)]
        public string Pwd { get; set; }
        [MinLength(8),MaxLength(8)]
        public string IdEmpleado { get; set; }
        [MaxLength(30)]
        public string Nombre { get; set; }
        [MaxLength(30)]
        public string Apellido { get; set; }
        [MaxLength(50)]
        public string Correo { get; set; }
        public bool Enable { get; set; }
    }
}
