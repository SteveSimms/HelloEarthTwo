using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace HelloEarthTwo
{
    class Program
    {
        static void Main(string[] args)
        {

            var heroFile = new HeroService();
            heroFile.CaptureUserInput();


            //Enhance the application to prompt the user for their name and display it along with the date and time.
            var CurrentDate = DateTime.Now;
            //Console.WriteLine($"{Environment.NewLine} Salam, {name} on {CurrentDate:d} at {CurrentDate:t}!");

        }



    }


}

