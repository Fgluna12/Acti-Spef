using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class TeachersIdentity
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
        public virtual IEnumerable<StudentsIdentity> Students { get; set; }
    }
}