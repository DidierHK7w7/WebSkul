using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
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
            var school = new School();
            school.Id = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.CreationYear = 2005;
            school.Address = "Groove Street";
            school.Country = "Los Santos";
            school.City = "San Andreas";
            school.SchoolType = SchoolType.Middleschool;

            modelBuilder.Entity<School>().HasData(school);  //Le pasamos un objeto

            modelBuilder.Entity<Subject>().HasData(     //Le pasamos varios objetos separados por comas
                    new Subject { Name = "Math", Id = Guid.NewGuid().ToString() },
                    new Subject { Name = "English", Id = Guid.NewGuid().ToString() },
                    new Subject { Name = "Videogames", Id = Guid.NewGuid().ToString() },
                    new Subject { Name = "Music", Id = Guid.NewGuid().ToString() },
                    new Subject { Name = "Web apps development", Id = Guid.NewGuid().ToString() }
                );
            modelBuilder.Entity<Student>().HasData(RandomStudentsGenerator().ToArray());    //Hasdata requiere array, RandomStudentsGenerator() devuelve una lista porl o que se castea
        }

        private List<Student> RandomStudentsGenerator()
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
                                  Name = $"{n1} {n2} {a1}",
                                  Id = Guid.NewGuid().ToString()
                              };

            return studentList.OrderBy((stn) => stn.Id).ToList();     //El delegado Obrder By ordena por el ide unico y Take trunca la lista de n alumnos a un numero especifico
        }
    }
}