using System;
using System.Collections.Generic;
namespace WebSkul.Models
{
    public class Subject : SchoolBaseObject
    {
        public string CourseId { get; set; }
        public Course Course { get; set; }

        public List<Evaluation> EvaluationsList { get; set; }
    }
}