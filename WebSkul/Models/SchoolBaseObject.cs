using System;
namespace WebSkul.Models
{
    public abstract class SchoolBaseObject
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Name},{Id}";
    }
}