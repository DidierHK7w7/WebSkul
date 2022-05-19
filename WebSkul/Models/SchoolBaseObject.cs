using System;
using System.ComponentModel.DataAnnotations;

namespace WebSkul.Models
{
    public abstract class SchoolBaseObject
    {
        public string Id { get; set; }

        public string Name { get; set; }    //los campos virtuales pueden ser redescritos por las clases hijo

        public override string ToString() => $"{Name},{Id}";
    }
}