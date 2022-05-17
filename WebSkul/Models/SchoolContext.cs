using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace WebSkul.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }      //DbSet es una tabl;a de la base de datos que corresponde con el tipo school
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Subject> Students { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)     //options parametro generico, se indica el tipo d edato
        {

        }

    }
}