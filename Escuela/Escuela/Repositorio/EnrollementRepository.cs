using Escuela.Controllers.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class EnrollementRepository : IRollements
    {
        private ApplicationDbContext bd;

        public EnrollementRepository(ApplicationDbContext bd)
        {
            this.bd = bd;
        }

        public List<Enrollement> UnionDeTablas()
        {
            var union = bd.Enrollements.Include(e => e.Students).Include(c => c.Course).ToList();

            return union;
        }
    }
}
