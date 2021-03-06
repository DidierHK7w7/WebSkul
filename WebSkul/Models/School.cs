using System;
using System.Collections.Generic;
namespace WebSkul.Models
{
    public class School : SchoolBaseObject
    {
        public int CreationYear{get; set;}
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public SchoolType SchoolType { get; set; }

        public List<Course> Courses { get; set; }   //Lista generica


        public School(string name, int year) =>(Name, CreationYear) = (name, year);     //Metodo constructor con lambda, ()=() asignacion de tuplas

        public School(string name, int year, SchoolType type, string country="", string city = ""):base()     //Segundo constructor
        {
            (Name, CreationYear) = (name, year);
            Country = country;
            City = city;
        }
        public School()
        {

        }
        
        public override string ToString() => $"Name: \"{Name}\", Tipe: {SchoolType}\nCountry: {Country}, City: {City}";     //{System.Environment.NewLine} equivale a \n
    }
}