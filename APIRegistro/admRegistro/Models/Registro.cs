using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace admRegistro.Models
{
    public enum CategoryType
    {
        Estudiante = 10,
        Administrativo = 20,
        Docente = 30,
        Limpieza = 40,
        Seguridad = 50
    }
    public class Registro
    {
        [Key]
        public int SalmonID { get; set; }


        [Required(ErrorMessage = "You must enter the filed {0}")]
        [StringLength(24, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 2)]
        [Display(Name = "Nombre Completo")]
        public string FriendofSalmon { get; set; }


        [Required(ErrorMessage = "You must enter the filed {0}")]
        public CategoryType Place { get; set; }


        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }


        [Display(Name = "Cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
}