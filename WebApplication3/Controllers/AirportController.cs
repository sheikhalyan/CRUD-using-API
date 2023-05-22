using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.ViewModels;
using System.Web.Mvc;
using System.Net.Http;
using WebApplication3.Models;
using System.Net.Http.Headers;

namespace WebApplication3.Controllers
{
    public class AirportController : Controller
    {


        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<AirportViewModel> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44329/api/");
                // HTTP GET
                var responseTask = client.GetAsync("Airportt");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AirportViewModel>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else // web API sent error response
                {
                    students = Enumerable.Empty<AirportViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact the administrator.");
                }
            }

            return View(students);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(AirportViewModel student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44329/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<AirportViewModel>("Airportt", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(student);
           
        }

    }
}
