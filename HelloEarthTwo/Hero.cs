using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace HelloEarthTwo
{

    public class Hero
    {

        //Method captures userInput and stores it into an Object 
        public object CaptureUserInput()
        {
            Console.WriteLine($"Whats your code name? ");
            var heroName = Console.ReadLine();

            Console.WriteLine($"Whats your powers? ");
            var powers = Console.ReadLine();

            Console.WriteLine($"Whats your secret identity? ");
            var secretId = Console.ReadLine();

            Console.WriteLine($"Whats your home world? ");
            var homeWorld = Console.ReadLine();

            Console.WriteLine($"{heroName}, {powers} , {secretId}, home world {homeWorld}");

            //string readKeys = Console.ReadKey(true);
            //if(readKeys == true )
            //{


            //}

            Console.WriteLine($"{Environment.NewLine} Press any key to exit...");
            Console.ReadKey(true);

            string[] userInput = { heroName, powers, secretId, homeWorld };

            var hero = new
            {
                codeName = heroName,
                powers = powers,
                secretId = secretId,
                homeWorld = homeWorld

            };

            if (hero.homeWorld == "Earth-2")
            {

                ConvertHeroInput(hero);
            }
            else
            {
                ConvertMultiverseHeroInput(hero);
            }

         
            return hero;
        }

        //Method Converts captured userInput to Json  and writes to hero.json file
        public void ConvertHeroInput(object hero)
        {
            string output = JsonConvert.SerializeObject(hero); // converting hero Object to json  
            Console.WriteLine(output);

            // write json to .json file
            File.WriteAllText(@"C:\Users\simms\learn\projects\HelloEarthTwo\HelloEarthTwo\hero.json", output); // Writing our hero information to hero.json file

        }

        public void ConvertMultiverseHeroInput(object hero)
        {

            string multiverseOutput = JsonConvert.SerializeObject(hero);
            // write json to .json file
            File.WriteAllText(@"C:\Users\simms\learn\projects\HelloEarthTwo\HelloEarthTwo\multiverseHeroes.json", multiverseOutput); // Writing our hero information to hero.json file

        }

    }
}
