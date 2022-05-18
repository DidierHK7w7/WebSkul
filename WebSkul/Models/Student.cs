using System;
using System.Collections.Generic;
namespace WebSkul.Models
{
    public class Student : SchoolBaseObject         //Herencia
    {
        public List<Evaluation> EvaluationsList { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
    }
}