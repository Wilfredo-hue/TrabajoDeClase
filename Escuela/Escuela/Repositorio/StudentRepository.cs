using Escuela.Controllers.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class StudentRepository : IStudents
    {
        private ApplicationDbContext app;


        public StudentRepository(ApplicationDbContext app)
        {
            this.app = app;
        }
        public List<Students> ListOfStudents()
        {
            return app.Students.ToList(); 
        }
    }
}
