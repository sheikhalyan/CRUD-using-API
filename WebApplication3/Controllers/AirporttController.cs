using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebApplication3.ViewModels;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AirporttController : ApiController
    {
        
        public IHttpActionResult GetAllStudents()
        {
            IList<AirportViewModel> students = null;

            using (var ctx = new AirportmanagementEntities1())
            {
                students = ctx.Airports
                    .Select(s => new AirportViewModel()
                    {
                        Airportid = s.AirportID,
                        AIrport_Name = s.Airport_name,
                        city = s.City,
                        country = s.Country,
                        NumberofRunways = s.Numberofrunways
                    })
                    .ToList();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult GetStudentById(int id)
        {
            AirportViewModel student = null;

            using (var ctx = new AirportmanagementEntities1())
            {
                student = ctx.Airports.Include("Airports")
                    .Where(s => s.AirportID == id)
                    .Select(s => new AirportViewModel()
                    {
                        Airportid = s.AirportID,
                        AIrport_Name = s.Airport_name,
                        city = s.City,
                        country = s.Country,
                        NumberofRunways = s.Numberofrunways,
                    }).FirstOrDefault<AirportViewModel>();
            }

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
        


        public IHttpActionResult PostNewStudent(AirportViewModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new AirportmanagementEntities1())
            {
                ctx.Airports.Add(new Airport()
                {
                    AirportID = student.Airportid,
                    Airport_name = student.AIrport_Name,
                    City = student.city,
                    Country = student.country,
                    Numberofrunways = student.NumberofRunways,

                });

                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}
