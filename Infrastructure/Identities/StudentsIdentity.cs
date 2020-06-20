using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure
{
    public class StudentsIdentity
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("TeacherIdentityId")]
        public virtual TeachersIdentity TeacherIdentity { get; set; }
    }
}
