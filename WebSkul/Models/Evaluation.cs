namespace WebSkul.Models
{
    public class Evaluation : SchoolBaseObject
    {
        public Student Student { get; set; }
        public string StudentId { get; set; }

        public Subject Subject { get; set; }
        public string SubjectId { get; set; }

        public float Grade { get; set; }

        public override string ToString() => $"{Grade},{Student.Name},{Subject.Name}";
    }
}