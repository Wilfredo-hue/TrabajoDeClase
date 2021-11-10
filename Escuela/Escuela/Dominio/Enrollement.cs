using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Dominio
{

    public enum Grade
    {
        A,B,C,D
    }
    public class Enrollement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollementID { get; set; }

        public  int CourseID { get; set; }

        public int StudentID { get; set; }

        public Grade? Grade { get; set; }

        public Course  Course { get; set; }

        public Students Students { get; set; }


    }
}
