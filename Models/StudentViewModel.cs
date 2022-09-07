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
        public long Student_id { get; set; }

        [Required(ErrorMessage = "DNI es requerido")]
        [StringLength(0, ErrorMessage = "Debe Ingresar El DNI")]
        public string dni { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string lastName { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        [StringLength(10, ErrorMessage = "Fecha de Nacimiento Requerida")]
        public DateTime dateOfBirth { get; set; }

        [Required(ErrorMessage = "Genero es requerido")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Estado es requerido")]
        [Range(0,1,ErrorMessage ="Estado es Requerido")]
        public int isActive { get; set; }
    }
}
