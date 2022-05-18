using System;
using System.Collections.Generic;
namespace WebSkul.Models
{
    public class Course : SchoolBaseObject
    {
        public WorkingType Working { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public string Address { get; set; }

        public string SchoolId { get; set; }
        public School School { get; set; }
    }
}