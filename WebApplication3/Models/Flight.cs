//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flight
    {
        public int FlightID { get; set; }
        public string Arrival_city { get; set; }
        public string Departure_city { get; set; }
        public string Arrival_date { get; set; }
        public string Departure_date { get; set; }
        public Nullable<int> AirportID { get; set; }
    
        public virtual Airport Airport { get; set; }
    }
}