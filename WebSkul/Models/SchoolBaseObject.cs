using System;
using System.ComponentModel.DataAnnotations;

namespace WebSkul.Models
{
    public abstract class SchoolBaseObject
    {
        public string Id { get; set; }

        public virtual string Name { get; set; }    

        public SchoolBaseObject()
        {

        }
        public override string ToString() => $"{Name},{Id}";
    }
}