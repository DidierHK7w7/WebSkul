using System;
namespace WebSkul.Models
{
    public abstract class SchoolBaseObject
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Name},{UniqueId}";
    }
}