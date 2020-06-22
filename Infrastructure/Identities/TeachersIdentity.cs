using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Identities
{
    public class TeachersIdentity
    {
        public int id { get; set; }

        [Required]
        public int dni { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede ser mayor de {50} caracteres.")]
        public String names { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El apellido no puede ser mayor de {50} caracteres.")]
        public String surnames { get; set; }

        [StringLength(100, ErrorMessage = "La direccion no puede ser mayor de {100} caracteres.")]
        public String address { get; set; }
        public DateTime Birthdate { get; set; }
        public String email { get; set; }
        public int phone { get; set; }
        public bool deleted { get; set; }
        public virtual IEnumerable<StudentsIdentity> Teachers { get; set; }
    }
}
