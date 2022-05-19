using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSkul.Models
{
    public class Course : SchoolBaseObject
    {
        public WorkingType Working { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }

        [Display(Prompt = "Dirección correspondencia")]   //promp es casi como un placeholder
        [Required(ErrorMessage = "Se requiere incluir una dirección")]
        [MinLength(10, ErrorMessage = "La longitud mínima de la dirección es 5")]
        public string Address { get; set; }

        public string SchoolId { get; set; }
        public School School { get; set; }

        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [MinLength(10, ErrorMessage = "La longitud mínima de la dirección es 5")]
        //[StringLength(5)]
        public override string Name { get; set; }   //Campo sobreescrito, es requerido pero solo para este modelo
    }
}