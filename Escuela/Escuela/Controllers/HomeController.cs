using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourse icourse;
        private IRollements irollements;
        private IStudents istudents;
        public HomeController(ILogger<HomeController> logger, ICourse icourse, IRollements irollements, IStudents istudents)
        {
            this.icourse = icourse;
            this.irollements = irollements;
            this.istudents = istudents; 
            _logger = logger;
        } 

        public IActionResult Index()
        {

            var listado = irollements.UnionDeTablas();
            _ = listado;

            return View(listado);      
            
        }
        public IActionResult GetAllForJoinJsonLinq()
        {
            var listado = irollements.UnionDeTablas();

            var CombinacionDeArreglos = (from union in listado
                                         select new
                                         {
                                             union.Course.Tittle,
                                             union.Students.LastName,
                                             union.Students.FirstMidName,
                                             union.Grade
                                         }).ToList();

            return Json(new{ CombinacionDeArreglos });
        }
        public IActionResult ComboBox()
        {

            var informationOftheCombo = icourse.ListarCursos();
            var informationOftheComboForStudents = istudents.ListOfStudents();

            List<SelectListItem> ListCourse = new List<SelectListItem>();
            List<SelectListItem> ListStudents = new List<SelectListItem>();

            foreach (var iterarinformation in informationOftheCombo)
            {
                ListCourse.Add(new SelectListItem 
                    { 
                    Text = iterarinformation.Tittle, 
                    Value = Convert.ToString(iterarinformation.CourseId) 
                    }

                    );

                ViewBag.estadolistcourse = ListCourse; 
            }


            foreach (var iterarinformation in informationOftheComboForStudents)
            {
                ListStudents.Add(new SelectListItem
                {
                    Text = iterarinformation.FirstMidName,
                    Value = Convert.ToString(iterarinformation.StudentId)
                }

                    );

                ViewBag.estadoliststudents = ListStudents;
            }
            return View();
        }
        public IActionResult getinformationCombobox(Enrollement e)
        {
            _ = e;
            return View("ComboBox");
        }

        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
