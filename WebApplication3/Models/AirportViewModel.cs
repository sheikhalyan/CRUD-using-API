using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.ViewModels
{
    public class AirportViewModel
    {
        [Key]
        public int Airportid { get; set; }

        public string AIrport_Name { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string NumberofRunways { get; set; }
      
    }
}