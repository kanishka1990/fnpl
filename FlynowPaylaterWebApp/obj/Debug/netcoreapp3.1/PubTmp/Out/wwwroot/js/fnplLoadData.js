


var origi = document.getElementsByName('fnplOrigin')[0].getAttribute('content');
var Clientorigin = document.getElementsByName('ClientOrigin')[0].getAttribute('content');

var globdata = "";
var gdobday = "";
var name = "";
var gdobdate = "10";
var gdobmonth = "03";
var gdobyear = "1990";


var globdataflight = [];

// Success callback registration
var successfulCallback = function (dispersalToken) {
    //   alert('Your token to send to API is: ' + dispersalToken);

    document.getElementsByName("fnpltoken")[0].setAttribute("content", dispersalToken);



    $.ajax({
        url: Clientorigin + '/getfnplCard',
        type: 'POST',
        contentType: 'application/json',
        data: "{'fncard':'" + dispersalToken + "'}",
        dataType: 'json',
        success: function (response) {
            console.log(response);
            //     return response;
        }
    });


};






// Init callback registration
var fnplCallback = function (FNPL) {


    var flights = document.getElementsByName('flights')[0].getAttribute('content');

    var Addresstokenfloor = document.getElementsByName('Addresstokenfloor')[0].getAttribute('content');
    var Addresstokenapartment = document.getElementsByName('Addresstokenapartment')[0].getAttribute('content');
    var Addresstokenstreet = document.getElementsByName('Addresstokenstreet')[0].getAttribute('content');
    var Addresstokencity = document.getElementsByName('Addresstokencity')[0].getAttribute('content');
    var Addresstokencounty = document.getElementsByName('Addresstokencounty')[0].getAttribute('content');
    var Addresstokenpostcode = document.getElementsByName('Addresstokenpostcode')[0].getAttribute('content');

    var Addresstokencountry = document.getElementsByName('Addresstokencountry')[0].getAttribute('content');

    var itineraryHotelname = document.getElementsByName('itineraryHotelname')[0].getAttribute('content');
    var itineraryHotelcountry = document.getElementsByName('itineraryHotelcountry')[0].getAttribute('content');
    var itineraryHotelcheckingin = document.getElementsByName('itineraryHotelcheckingin')[0].getAttribute('content');
    var itineraryHotelcheckingout = document.getElementsByName('itineraryHotelcheckingout')[0].getAttribute('content');

    var checkoutAmount = document.getElementsByName('checkoutAmount')[0].getAttribute('content');

    var pcountry = document.getElementsByName("pcountry")[0].getAttribute("content");
    var email = document.getElementsByName("email")[0].getAttribute("content");
    var pnumber = document.getElementsByName("pnumber")[0].getAttribute("content");

    FNPL.build('fnplPnl');



    FNPL.applicant.phone.country.set(pcountry);


    FNPL.applicant.phone.number.set(pnumber);


    FNPL.applicant.email.set(email);

    FNPL.applicant.address.floor.set(Addresstokenfloor);
    FNPL.applicant.address.apartment.set(Addresstokenapartment);
    FNPL.applicant.address.street.set(Addresstokenstreet);
    FNPL.applicant.address.city.set(Addresstokencity);
    FNPL.applicant.address.county.set(Addresstokencounty);
    FNPL.applicant.address.postcode.set(Addresstokenpostcode);
    FNPL.applicant.address.country.set(Addresstokencountry);
    var datas = JSON.parse(flights);

    FNPL.applicant.fullName.set(datas[0].Passenger[0].name);

    var dobday = parseInt(datas[0].Passenger[0].dob.day);
    var dobmonth = parseInt(datas[0].Passenger[0].dob.month);
    var dobyear = parseInt(datas[0].Passenger[0].dob.year);

    FNPL.applicant.dateOfBirth.set(dobday, dobmonth, dobyear);

    FNPL.itinerary.person.name.set(datas[0].Passenger[0].name);
    FNPL.itinerary.person.dob.set(dobday, dobmonth, dobyear);

    for (var j = 0; j < datas.length; j++) {

      //  var dataspax = JSON.parse(datas[j].Passenger);

     

        if (datas[j].LegNo == '1') {
            FNPL.itinerary.addFlight({
                flightNumber: datas[j].flightNumber,

                //passengers: [

                //    {
                //        name: datas[j].Passenger.name,
                //        dob: { day: datas[j].Passenger.dob.day, month: datas[j].Passenger.dob.month, year: datas[j].Passenger.dob.year }
                //    },

                //],

                passengers: datas[j].Passenger,
                from: datas[j].from // {
                // date: { day: 03, month: 02, year: 2020 },
                // country: 'GB', airport: 'LHR',
                // }
                ,
                to: datas[j].to //{
                // date: { day: 04, month: 02, year: 2020 },
                // country: 'GB', airport: 'KUL',
                // }
            });
        }

        else if (datas[j].LegNo == '2') {
            // Set the followup or return flights on the ticket
            FNPL.itinerary.addFlight({
                flightNumber: datas[j].flightNumber,
              //  passengers: [{ name: datas[j].Passenger.name, dob: { day: datas[j].Passenger.dob.day, month: datas[j].Passenger.dob.month, year: datas[j].Passenger.dob.year } }],
                passengers: datas[j].Passenger,
                from: datas[j].from//{
                //date:,
                //country: 'MY', airport: 'KUL',
                //  }
                ,
                to: datas[j].to //{

                //date: { day: 17, month: 03, year: 2020 },
                //country: 'GB', airport: 'LHR',
                //}
            });
        }
    }


    //FNPL.itinerary.addHotel({
    //    name: itineraryHotelname,
    //    rooms: 2,
    //    country: itineraryHotelcountry,
    //    checking: { in: { day: 04, month: 02, year: 2020 }, out: { day: 10, month: 02, year: 2020 } },
    //    persons: [{ name: 'John Stuart Tomas Doe', dob: { day: 16, month: 03, year: 1990 } }, { name: 'Anna Doe', dob: { day: 02, month: 05, year: 1985 } }]
    //});
    //FNPL.itinerary.addRental({
    //    name: 'BMW e70, year 2007, x-drive 3.0d',
    //    country: 'GB',
    //    period: {
    //        start: { day: 04, month: 02, year: 2020 },
    //        end: { day: 10, month: 02, year: 2020 }
    //    },
    //    persons: [{
    //        name: 'John Stuart Tomas Doe',
    //        dob: { day: 16, month: 03, year: 1990 }
    //    },
    //    {
    //        name: 'Anna Doe', dob: { day: 02, month: 05, year: 1985 }
    //    }]
    //});
    FNPL.checkout.amount.set(parseFloat(checkoutAmount));

    // The method below registers the reference of callback but not execution
    // so keep only the name of function as the argument.
    FNPL.setCallback.complete(successfulCallback);

    FNPL.save();

};


