using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlynowPaylaterWebApp.Models;
using RestSharp;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Text.Json;

namespace FlynowPaylaterWebApp.Controllers
{

    [EnableCors("AllowMyOrigin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static IConfiguration configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration iconfiguration)
        {
            configuration = iconfiguration;
            _logger = logger;
        }

        string personname = string.Empty;

        List<flightObj> segObj = new List<flightObj>();
        public ParaList FNPLPaxData { get; set; }

        public static Dictionary<string, object> dix;
        public static Dictionary<flightObj, flightObj> flightdic;
        public IActionResult Index()
        {

            //  string dispersalToken = "c164307ce0caff1392f90ee3aa07ea897b6bd7c2be719c1840ab098eff922c6b588827883e799a6b080fc3d2a43714c9e10f615a1c54f6d035d40157";

            //  object input = new
            //  {
            //      key = "N3XQ06JS4R-CJ7IK6GWQJ"

            //  };

            //  var client = new RestClient("https://widget.flynowpaylater.com/cdn/integration.min.js?callback=fnplcallbkfunc&key=N3XQ06JS4R-CJ7IK6GWQJ");
            //  var request = new RestRequest(Method.GET);
            //  request.AddHeader("authorization", "Barrier c164307ce0caff1392f90ee3aa07ea897b6bd7c2be719c1840ab098eff922c6b588827883e799a6b080fc3d2a43714c9e10f615a1c54f6d035d40157");
            //  IRestResponse response = client.Execute(request);

            ////  ViewBag.JavaScriptFunction = string.Format("fnplFuncBuild();");

            //  return RedirectToAction("GetFNPLDetails", TempData["fnpldata"]);
            return View();
        }

        public IActionResult Test()
        {

            return View();
        }

        public IActionResult PostFNPLData()
        {

            return View();
        }
        public object PostData()
        {
            //  ViewBag. = TempData["fnpldata"];


            var x = dix;


            //ViewBag.Addresstokenapartment = FNPLPax.Addresstokenapartment;

            //ViewBag.Addresstokencity = FNPLPax.Addresstokencity;
            //ViewBag.Addresstokencountry = FNPLPax.Addresstokencountry;
            //ViewBag.Addresstokenfloor = FNPLPax.Addresstokenfloor;
            //ViewBag.Addresstokenpostcode = FNPLPax.Addresstokenpostcode;
            //ViewBag.Addresstokenstreet = FNPLPax.Addresstokenstreet;
            //ViewBag.Addresstokencounty = FNPLPax.Addresstokencounty;

            //personname = FNPLPax.personname;
            //ViewBag.personname = FNPLPax.personname;
            //ViewBag.persondob = FNPLPax.persondob;

            //ViewBag.itineraryHotelname = FNPLPax.itineraryHotelname;
            //ViewBag.itineraryHotelcheckingin = FNPLPax.itineraryHotelcheckingin;
            //ViewBag.itineraryHotelcheckingout = FNPLPax.itineraryHotelcheckingout;
            //ViewBag.itineraryHotelcountry = FNPLPax.itineraryHotelcountry;


            //ViewBag.rentalsname = FNPLPax.rentalsname;
            //ViewBag.rentalscountry = FNPLPax.rentalscountry;
            //ViewBag.rentalsperiodStart = FNPLPax.rentalsperiodStart;
            //ViewBag.rentalsperiodEnd = FNPLPax.rentalsperiodEnd;


            //ViewBag.pcountry = FNPLPax.pcountry;
            //ViewBag.pnumber = FNPLPax.pnumber;
            //ViewBag.personname = FNPLPax.personname;
            //ViewBag.persondob = FNPLPax.persondob;
            //ViewBag.email = FNPLPax.email;


            ////  }

            //var x = Test();


            return x;
        }
        public object PostDataFlight()
        {
            //  ViewBag. = TempData["fnpldata"];


            var x = flightdic.Values;




            return JsonConvert.SerializeObject(flightdic.Values);
        }
        [HttpPost]
        public string GetFNPLDetails([FromBody]ParaList personob)
        {
            string ret = string.Empty;
            try
            {

                //  personname = personob.personname[0];


                ParaList local = new ParaList();



                dix = ObjectToDictionary(personob);
                flightObj fl = new flightObj();

                //fl.Passenger = new Passenger();

                fl.Passenger = new Passenger[personob.personname.Length];

                for (int px = 0; px < personob.personname.Length; px++)
                {
                    fl.Passenger[px] = new Passenger();
                    fl.Passenger[px].name = personob.personname[px].ToString();

                    fl.Passenger[px].dob = new Dob();
                    fl.Passenger[px].dob.day = Convert.ToInt32(personob.persondob[px].Split('-')[2]);
                    fl.Passenger[px].dob.month = Convert.ToInt32(personob.persondob[px].Split('-')[1]);
                    fl.Passenger[px].dob.year = Convert.ToInt32(personob.persondob[px].Split('-')[0]);
                }

                dynamic flightlist = JsonConvert.DeserializeObject(personob.arrayflight);

                foreach (var flightseg in flightlist)
                {
                    DateTime fromd = Convert.ToDateTime(flightseg["fromDate"].ToString("yyyy-MM-dd"));
                    DateTime tod = Convert.ToDateTime(flightseg["toDate"].ToString("yyyy-MM-dd"));
                    segObj.Add(new flightObj
                    {
                        flightNumber = flightseg["flightNumber"],
                        from = new From { airport = flightseg["fromAirport"], country = flightseg["fromCountry"], date = new Date { day = Convert.ToInt32(fromd.Day), month = Convert.ToInt32(fromd.Month), year = Convert.ToInt32(fromd.Year) } },
                        to = new To { airport = flightseg["toAirport"], country = flightseg["toCountry"], date = new Date { day = Convert.ToInt32(tod.Day), month = Convert.ToInt32(tod.Month), year = Convert.ToInt32(tod.Year) } },

                        //  Passenger = new Passenger[] { name = personob.personname }
                        Passenger = fl.Passenger,
                        //{
                        //    name = personob.personname,
                        //    dob = new Dob { day = Convert.ToInt32(personob.persondob.Split('-')[2]), month = Convert.ToInt32(personob.persondob.Split('-')[1]), year = Convert.ToInt32(personob.persondob.Split('-')[0]) }



                        //},
                        LegNo = flightseg["LegNo"].ToString(),




                    }); ;


                }

                //flightdic = ObjectToDictionaryFlight(segObj);

                flightdic = segObj.ToDictionary(x => x, x => x);

                string origin = configuration.GetValue<string>("MyAppSettings:appOrigin");
                string Clientorigin = configuration.GetValue<string>("MyAppSettings:clientOrigin");

                string apiToken = configuration.GetValue<string>("MyAppSettings:apiToken");
                string token = configuration.GetValue<string>("MyAppSettings:dispersalToken");

                // ret =  "<script src = \"https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js\"></script>";
                //           "<script>" +

                //               "$( document ).ready(function()" +
                //              " {  var originUrl ='"+ origin +"/Home/PostFNPLData'; " +

                //                  " window.open(originUrl,'_blank');" +
                //"});" +
                //           "</script>";



                ret = "<script src ='https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js'></script>" +
                "<meta name = 'Addresstokenfloor' content = '" + personob.Addresstokenfloor + "' /><meta name = 'Addresstokenapartment' content = '" + personob.Addresstokenapartment + "' />" +

                            "<meta name = 'fnpltoken' content = '' />" +

                     "<meta name = 'fnplOrigin' content = '" + origin + "' />" +
                      "<meta name = 'ClientOrigin' content = '" + personob.clientUrl + "' />" +
                         "<meta name = 'TID' content = '" + personob.TID + "' />" +

             "<meta name = 'Addresstokenstreet' content = '" + personob.Addresstokenstreet + " ' />" +

               "<meta name = 'Addresstokencity' content = '" + personob.Addresstokencity + "' />" +

                   "<meta name = 'Addresstokencounty' content = '" + personob.Addresstokencounty + "' />" +

                      "<meta name = 'Addresstokenpostcode' content = '" + personob.Addresstokenpostcode + "' />" +

                         "<meta name = 'Addresstokencountry' content = '" + personob.Addresstokencountry + "' />" +

                           " <meta name = 'itineraryHotelname' content = '" + personob.itineraryHotelname + "' />" +

                               "<meta name = 'itineraryHotelcountry' content = '" + personob.itineraryHotelcountry + "' />" +

                                 " <meta name = 'itineraryHotelcheckingin' content = '" + personob.itineraryHotelcheckingin + "' />" +

                                     "<meta name = 'itineraryHotelcheckingout' content = '" + personob.itineraryHotelcheckingout + "' />" +

                                        "<meta name = 'checkoutAmount' content = '" + personob.checkoutAmount + "' />" +

                                           "<meta name = 'pcountry' content = '" + personob.pcountry + "' />" +

                                             " <meta name = 'email' content = '" + personob.email + "' />" +

                                                 "<meta name = 'pnumber' content = '" + personob.pnumber.Replace('+', '0') + "' />" +

                                                   "<meta name = 'flights' content = '" + JsonConvert.SerializeObject(flightdic.Values) + "' />" +






"|" +

"<body>" +


         "<script src ='" + origin + "/js/fnplLoadData.js'></script>" +

   " <div id = 'fnplPnl'>  </div>" +

     "<script defer src ='https://widget.flynowpaylater.com/cdn/integration.min.js?callback=fnplCallback&key=" + apiToken + "'>" + "</script>" +

      "</body>";

                ret += "";
            }
            catch (Exception ex)
            {
                ret = ex.InnerException.ToString() + "|Fail";
            }
            //Response.Redirect("/Home/Index",true);



            return ret;
        }

        public static Dictionary<string, object> ObjectToDictionary(object obj)
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                string propName = prop.Name;
                var val = obj.GetType().GetProperty(propName).GetValue(obj, null);
                if (val != null)
                {
                    ret.Add(propName, val.ToString());
                }
                else
                {
                    ret.Add(propName, null);
                }
            }

            return ret;
        }



        [EnableCors("AllowMyOrigin")]
        [HttpPost]
        public string GetDispersalToken(string dispersalToken)
        {

            string token = configuration.GetValue<string>("MyAppSettings:dispersalToken");

            var client = new RestClient("https://cll.flynowpaylater.com/1.2/dispersal/" + token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Barrier " + dispersalToken);
            IRestResponse response = client.Execute(request);
            //string req=  JsonConvert.SerializeObject(request);
            //  string res = JsonConvert.SerializeObject(response);
            //FnplCard.Card fnplcardRes = new FnplCard.Card();
            //fnplcardRes = JsonConvert.DeserializeObject<FnplCard.Card>(response.Content.ToString());

            //string add1 = string.Empty;
            //string add2 = string.Empty;
            //string city = string.Empty;
            //string postalid = string.Empty;
            //string country = string.Empty;
            //string cardname = string.Empty;
            //string cardtype = string.Empty;
            //string txtcardno = string.Empty;
            //string txtcvv = string.Empty;
            //string expiry = string.Empty;
            //string bookingref = string.Empty;

            //string totamount = string.Empty;
            //string FName = string.Empty;
            //string LName = string.Empty;
            //string contactno = string.Empty;
            //string pas_email = string.Empty;
            //string usstate = string.Empty;

            //string strcrname = fnplcardRes.card.name.Trim().Replace(' ', ',');
            //string firstnm = strcrname.Split(',')[1].ToString();
            //string lastnm = strcrname.Split(',')[2].ToString();

            //   dynamic paxinfo = JsonConvert.DeserializeObject(dix);

            //  add1 = fnplcardRes.card.billingAddress.line1;  add2= fnplcardRes.card.billingAddress.line2;  city = fnplcardRes.card.billingAddress.city;  postalid = fnplcardRes.card.billingAddress.postcode;  country = fnplcardRes.card.billingAddress.county;  cardname = fnplcardRes.card.name;  cardtype = fnplcardRes.card.scheme;  txtcardno = fnplcardRes.card.pan;  txtcvv = fnplcardRes.card.cvv;  expiry = fnplcardRes.card.expiry.month.ToString();  bookingref = fnplcardRes.card.expiry.year.ToString();  totamount = fnplcardRes.summary.amountIssued.ToString();  FName = firstnm;  LName = lastnm;  contactno = paxinfo["pnumber"].ToString();   pas_email = paxinfo["email"].ToString();  usstate = "";



            //   PaymentController.dataparser(add1, add2, city, postalid, country, cardname, cardtype, txtcardno, txtcvv, expiry, bookingref, totamount, FName, LName, contactno, pas_email, usstate);


            //   return RedirectToAction("/PaymentController/proceedtopayment");

            return response.Content.ToString();
        }



        [HttpPost]
        public string getFnplIframe(string fnpliframe)
        {




            return "";
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
