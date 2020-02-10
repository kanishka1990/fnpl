using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlynowPaylaterWebApp.Models
{
    public class ParaList
    {


        [TempData]
        public string Addresstokenfloor { get; set; }

        [TempData]
        public string checkoutAmount { get; set; }

        [TempData]
        public string Addresstokenapartment { get; set; }

        [TempData]
        public string Addresstokenstreet { get; set; }

        [TempData]
        public string Addresstokencity { get; set; }

        [TempData]
        public string Addresstokencounty { get; set; }

        [TempData]
        public string Addresstokenpostcode { get; set; }

        [TempData]
        public string Addresstokencountry { get; set; }


        [TempData]
        public string[] personname { get; set; }

        [TempData]
        public string[] persondob { get; set; }

        [TempData]
        public string itineraryHotelname { get; set; }

        [TempData]
        public string itineraryHotelcountry { get; set; }

        [TempData]
        public string itineraryHotelcheckingin { get; set; }

        [TempData]
        public string itineraryHotelcheckingout { get; set; }


        [TempData]
        public string pcountry { get; set; }

        [TempData]
        public string email { get; set; }

        [TempData]
        public string pnumber { get; set; }


        [TempData]
        public string rentalsname { get; set; }

        [TempData]
        public string rentalscountry { get; set; }


        [TempData]
        public string rentalsperiodStart { get; set; }

        [TempData]
        public string rentalsperiodEnd { get; set; }

        [TempData]
        public string arrayflight { get; set; }


        [TempData]
        public string LegNo { get; set; }

        [TempData]
        public string clientUrl { get; set; }

        [TempData]
        public string TID { get; set; }
    }

    public class flightObj
    {

        public string flightNumber { get; set; }
        public From from { get; set; }
      
        public To to { get; set; }

        public string LegNo { get; set; }
        public Passenger[] Passenger { get; set; }
    }


    public class Rootobject
    {
        public string flightNumber { get; set; }
        public Passenger[] passengers { get; set; }
        public From from { get; set; }
        public To to { get; set; }

    }

    public class From
    {
        public Date date { get; set; }
        public string country { get; set; }
        public string airport { get; set; }
    }

    public class Date
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }

    public class To
    {
        public Date date { get; set; }
        public string country { get; set; }
        public string airport { get; set; }
    }



    public class Passenger
    {
        public string name { get; set; }
        public Dob dob { get; set; }
    }

    public class Dob
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }



}
