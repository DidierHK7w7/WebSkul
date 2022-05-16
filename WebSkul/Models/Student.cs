using System;
using System.Collections.Generic;
namespace WebSkul.Models
{
    public class Student : SchoolBaseObject         //Herencia
    {
        public List<Evaluation> EvaluationsList { get; set; } = new List<Evaluation>(){};
    }
}