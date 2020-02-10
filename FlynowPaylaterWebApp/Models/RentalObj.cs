using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlynowPaylaterWebApp.Models
{
    public class RentalObj
    {


        public class Period
        {
            public string type { get; set; }
            public string start { get; set; }
            public string end { get; set; }
        }



        public class Name
        {
            public string description { get; set; }
        }

        public class Country
        {
            public string description { get; set; }
        }

        public class Persons
        {
            PersonObj[] person { get; set; }

            
        }
    }
}



