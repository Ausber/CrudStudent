using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models
{
    public partial class StudentViewModel
    {
        [Key]
        [Required]
        public long Student_id { get; set; }

        [Required(ErrorMessage = "DNI es requerido")]
        public long dni { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento es requerido")]
        public DateTime dateOfBirth { get; set; }

        [Required(ErrorMessage = "Genero es requerido")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Email es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Estado es requerido")]
        public int isActive { get; set; }
    }
}
