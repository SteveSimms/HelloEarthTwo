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
      
   
            //Capture user input and write to a Json file
            string heroName;
            string powers;
            string secretId;
            string homeWorld;
            Console.WriteLine($"Whats your code name? ");
            heroName = Console.ReadLine();
            Console.WriteLine($"Whats your powers? ");
            powers = Console.ReadLine();
            Console.WriteLine($"Whats your secret identity? ");
            secretId = Console.ReadLine();
            Console.WriteLine($"Whats your home world? ");
            homeWorld = Console.ReadLine();



            Console.WriteLine($"{heroName}, {powers} , {secretId}, home world {homeWorld}");

            Console.WriteLine($"{Environment.NewLine} Press any key to exit...");
            Console.ReadKey(true);

            string[] userInput = { heroName, powers, secretId, homeWorld };
            // Abstract below code into a class and class method             // Create an object for array contents
            var hero = new
            {
                codeName = heroName,
                powers = powers,
                secretId = secretId,
                homeWorld = homeWorld

            };

            string output = JsonConvert.SerializeObject(hero); // converting hero Object to json  
            Console.WriteLine(output);
            // write json to .json file
            File.WriteAllText(@"C:\Users\simms\learn\projects\HelloEarthTwo\HelloEarthTwo\hero.json", output); // Writing our hero information to hero.json file

            //Enhance the application to prompt the user for their name and display it along with the date and time.
            var CurrentDate = DateTime.Now;
            //Console.WriteLine($"{Environment.NewLine} Salam, {name} on {CurrentDate:d} at {CurrentDate:t}!");


        }


    }
}
//There are lots of things to play around with in the console app such as logging things, getting input from user, or calling methods in other classes. Even connecting to the db

//11:16
//Next step is to do all of that in an API but it's the same parts, just more complicated
//11:17
//the new version of web api in .net 5 actually is a console app just like that
//Also make a github and check it in
//11:35
//Those are all good fundamentals to practice
// Think about using Humanizer to format the dates 