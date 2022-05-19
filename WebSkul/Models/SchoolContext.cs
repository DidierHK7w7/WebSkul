using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebSkul.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }      //DbSet es una tabl;a de la base de datos que corresponde con el tipo school
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Student> Students { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)     //options parametro generico, se indica el tipo d edato
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)   //Metodo que se ejecuta en la creacion de la base de datos
        {
            base.OnModelCreating(modelBuilder);     //Se invoca el metodo original para que haga lo que tiene que hacer y luego el metodo sobreescrito para que haga lo que queremos (creando escuela)

            /*
            No se puede rastrear una entidad de tipo porque la propiedad de clave principal 'id' es nula
            Esto se debe a cambios importantes en EF Core 3.0 que se pueden encontrar en este enlace: https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-3.0/breaking-changes#string-and-byte-array-keys-are-not-client-generated-by-default
            El comportamiento anterior a 3.0 se puede obtener especificando explícitamente que las propiedades 
            clave deben usar valores generados si no se establece ningún otro valor que no sea nulo.
            */
            var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }

            var school = new School();
            school.Id = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.CreationYear = 2005;
            school.Address = "Groove Street";
            school.Country = "Los Santos";
            school.City = "San Andreas";
            school.SchoolType = SchoolType.Middleschool;

            

            var courses = LoadCourses(school);
            var subjects = LoadSubjects(courses);
            var students = LoadStudents(courses);

            modelBuilder.Entity<School>().HasData(school);
            modelBuilder.Entity<Course>().HasData(courses.ToArray());
            modelBuilder.Entity<Subject>().HasData(subjects.ToArray());
            modelBuilder.Entity<Student>().HasData(students.ToArray());
        }


        private static List<Course> LoadCourses(School school)      //cargar cursos
        {
            var courseList = new List<Course>()
            {
                new Course(){Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "101", Working = WorkingType.Morning, Address = school.Address},
                new Course(){Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "201", Working = WorkingType.Morning, Address = school.Address},
                new Course(){Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "301", Working = WorkingType.Morning, Address = school.Address},
                new Course(){Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "401", Working = WorkingType.Afternoon, Address = school.Address},
                new Course(){Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "501", Working = WorkingType.Afternoon, Address = school.Address}
            };
            return courseList;
        }

        private static List<Subject> LoadSubjects(List<Course> courses)     //cargar asignaturas por cada curso
        {
            var subjectList = new List<Subject>();
            foreach (var course in courses)
            {
                var studentTempList = new List<Subject>()
                {
                    new Subject(){Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "Math"},
                    new Subject(){Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "English"},
                    new Subject(){Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "Videogames"},
                    new Subject(){Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "Music" },
                    new Subject(){Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "Web apps development"}
                };
                subjectList.AddRange(studentTempList);
            }
            return subjectList;
        }

        private List<Student> LoadStudents(List<Course> courses)        //cargar alumnos por cada curso
        {
            var studentList = new List<Student>();
            Random rnd = new Random();
            foreach (var course in courses)
            {
                int countRnd = rnd.Next(5, 20);
                var studentTempList = RandomStudentsGenerator(course, countRnd);
                studentList.AddRange(studentTempList);
            }
            return studentList;
        }

        private List<Student> RandomStudentsGenerator(Course course, int count)     //Generar alumnos al azar
        {
            string[] firstName = { "Carl", "Big", "Cesar", "OG", "Wu", "Mike", "Madd" };
            string[] middleName = { "Mitake", "Hikawa", "Yamabuki", "Ichigaya", "Aoba", "Hitori", "Lawrence" };
            string[] lastName = { "Johnson", "Smoke", "Vialpando", "Loc", "Zi Mu", "Toreno", "Dogg" };
            //Producto cartesiano con LinQ
            var studentList = from n1 in firstName
                              from n2 in middleName
                              from a1 in lastName
                              select new Student
                              {
                                  CourseId = course.Id,
                                  Name = $"{n1} {n2} {a1}",
                                  Id = Guid.NewGuid().ToString()
                              };

            return studentList.OrderBy((stn) => stn.Id).Take(count).ToList();     //El delegado Obrder By ordena por el ide unico y Take trunca la lista de n alumnos a un numero especifico
        }
    }
}