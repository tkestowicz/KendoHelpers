﻿using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace KendoHelpersSampleApp.Models
{
    public class DataContext
    {
        private IEnumerable<Person> people = new List<Person>();

        public DataContext()
        {
            PrepareSamplePeopleData();
        }

        private void PrepareSamplePeopleData()
        {
            const string json = @"[{""FirstName"":""William"",""LastName"":""Moreno""},{""FirstName"":""Maya"",""LastName"":""Osborn""},{""FirstName"":""Cooper"",""LastName"":""Montgomery""},{""FirstName"":""Karen"",""LastName"":""Franklin""},{""FirstName"":""Cynthia"",""LastName"":""Little""},{""FirstName"":""Abraham"",""LastName"":""Flynn""},{""FirstName"":""Shea"",""LastName"":""Bridges""},{""FirstName"":""Sara"",""LastName"":""Marks""},{""FirstName"":""Jonas"",""LastName"":""Keith""},{""FirstName"":""Lynn"",""LastName"":""Hobbs""},{""FirstName"":""Adena"",""LastName"":""Trevino""},{""FirstName"":""Rebecca"",""LastName"":""Wilcox""},{""FirstName"":""Naida"",""LastName"":""Macdonald""},{""FirstName"":""Carson"",""LastName"":""Steele""},{""FirstName"":""Brennan"",""LastName"":""Hester""},{""FirstName"":""Hilda"",""LastName"":""Blanchard""},{""FirstName"":""Anthony"",""LastName"":""Bender""},{""FirstName"":""Quinn"",""LastName"":""Faulkner""},{""FirstName"":""Nathan"",""LastName"":""Fields""},{""FirstName"":""Leo"",""LastName"":""Vasquez""},{""FirstName"":""Ruth"",""LastName"":""Mcgee""},{""FirstName"":""Colt"",""LastName"":""Noel""},{""FirstName"":""Nayda"",""LastName"":""Bates""},{""FirstName"":""Dalton"",""LastName"":""Coleman""},{""FirstName"":""Kennan"",""LastName"":""Simpson""},{""FirstName"":""Lydia"",""LastName"":""Lynch""},{""FirstName"":""Phoebe"",""LastName"":""Hays""},{""FirstName"":""Kaseem"",""LastName"":""Horn""},{""FirstName"":""Willa"",""LastName"":""Oliver""},{""FirstName"":""Fallon"",""LastName"":""Blake""},{""FirstName"":""Bert"",""LastName"":""Pennington""},{""FirstName"":""Cameron"",""LastName"":""Cervantes""},{""FirstName"":""Rafael"",""LastName"":""Vega""},{""FirstName"":""Iris"",""LastName"":""Jacobson""},{""FirstName"":""Clinton"",""LastName"":""Baird""},{""FirstName"":""Hayes"",""LastName"":""Baker""},{""FirstName"":""Madison"",""LastName"":""Mcleod""},{""FirstName"":""Neville"",""LastName"":""Fulton""},{""FirstName"":""May"",""LastName"":""Wallace""},{""FirstName"":""Kadeem"",""LastName"":""Conley""},{""FirstName"":""Raphael"",""LastName"":""Burks""},{""FirstName"":""Pascale"",""LastName"":""Livingston""},{""FirstName"":""Kathleen"",""LastName"":""Dyer""},{""FirstName"":""Yoshio"",""LastName"":""Johns""},{""FirstName"":""Walker"",""LastName"":""Flowers""},{""FirstName"":""Kirsten"",""LastName"":""Barton""},{""FirstName"":""Adrian"",""LastName"":""Patterson""},{""FirstName"":""Clayton"",""LastName"":""Rojas""},{""FirstName"":""Malik"",""LastName"":""Morrow""},{""FirstName"":""Demetrius"",""LastName"":""Shields""},{""FirstName"":""Mira"",""LastName"":""Morrow""},{""FirstName"":""Stephanie"",""LastName"":""Forbes""},{""FirstName"":""Declan"",""LastName"":""Maynard""},{""FirstName"":""Macey"",""LastName"":""Turner""},{""FirstName"":""Kamal"",""LastName"":""Bush""},{""FirstName"":""Bethany"",""LastName"":""Flores""},{""FirstName"":""Darryl"",""LastName"":""Simmons""},{""FirstName"":""Sasha"",""LastName"":""Richardson""},{""FirstName"":""Blair"",""LastName"":""Sanford""},{""FirstName"":""Darryl"",""LastName"":""Baxter""},{""FirstName"":""Blythe"",""LastName"":""Roy""},{""FirstName"":""Benjamin"",""LastName"":""Burris""},{""FirstName"":""Kalia"",""LastName"":""Fox""},{""FirstName"":""Tobias"",""LastName"":""Carey""},{""FirstName"":""Wendy"",""LastName"":""Chavez""},{""FirstName"":""Yvonne"",""LastName"":""Miles""},{""FirstName"":""Rose"",""LastName"":""Snyder""},{""FirstName"":""Ursula"",""LastName"":""Berry""},{""FirstName"":""Indira"",""LastName"":""Lowe""},{""FirstName"":""Yeo"",""LastName"":""Ware""},{""FirstName"":""Micah"",""LastName"":""Bolton""},{""FirstName"":""Danielle"",""LastName"":""Valenzuela""},{""FirstName"":""Ursula"",""LastName"":""Bishop""},{""FirstName"":""Moses"",""LastName"":""Ballard""},{""FirstName"":""Tad"",""LastName"":""Vincent""},{""FirstName"":""Azalia"",""LastName"":""York""},{""FirstName"":""Oprah"",""LastName"":""Cochran""},{""FirstName"":""Brendan"",""LastName"":""Dickerson""},{""FirstName"":""John"",""LastName"":""Baker""},{""FirstName"":""Harding"",""LastName"":""Hooper""},{""FirstName"":""Christine"",""LastName"":""Gross""},{""FirstName"":""Aristotle"",""LastName"":""Alvarado""},{""FirstName"":""Cullen"",""LastName"":""Wright""},{""FirstName"":""Ava"",""LastName"":""Myers""},{""FirstName"":""Kendall"",""LastName"":""Bender""},{""FirstName"":""Linda"",""LastName"":""Craig""},{""FirstName"":""Burton"",""LastName"":""Sheppard""},{""FirstName"":""Brian"",""LastName"":""Berger""},{""FirstName"":""Travis"",""LastName"":""Salazar""},{""FirstName"":""Berk"",""LastName"":""Rowland""},{""FirstName"":""Owen"",""LastName"":""Coffey""},{""FirstName"":""Remedios"",""LastName"":""Jackson""},{""FirstName"":""Guinevere"",""LastName"":""Valentine""},{""FirstName"":""Nigel"",""LastName"":""Snow""},{""FirstName"":""Walker"",""LastName"":""Bowers""},{""FirstName"":""Emerald"",""LastName"":""Carey""},{""FirstName"":""Jaden"",""LastName"":""Greene""},{""FirstName"":""Camille"",""LastName"":""Oconnor""},{""FirstName"":""Giacomo"",""LastName"":""Dickerson""},{""FirstName"":""Galvin"",""LastName"":""Sykes""}]";

            var serializer = new JavaScriptSerializer();

            people = serializer.Deserialize<List<Person>>(json);
        }

        public IEnumerable<Person> People { get { return people;  } } 
    }
}