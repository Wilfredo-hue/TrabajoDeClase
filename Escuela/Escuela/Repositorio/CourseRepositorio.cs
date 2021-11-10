 using Escuela.Controllers.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class CourseRepositorio : ICourse
    {
        private ApplicationDbContext app;


        public CourseRepositorio(ApplicationDbContext app)
        {
            this.app = app;
        }
        
        public void Buscar (Course c)
        {
            app.Courses.Find(c);
        }

        public void Delete (Course c)
        {
            app.Courses.Remove(c);
            //throw new NotFiniteNumberException();
        }
        public void Insertar(Course c)
        {
            app.Update(c);
            app.SaveChanges();
        }

        public ICollection<Course> ListarCorsos()
        {
            return app.Courses.ToList();
        }

        public List<Course> ListarCursos()
        {
            throw new NotImplementedException();
        }
    }
}
