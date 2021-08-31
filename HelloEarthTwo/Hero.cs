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
            //Instantiationg new Heroes class on ReadLine() method 
            Console.WriteLine($"Whats your code name? ");
            var codeName = new Heroes();
            codeName.CodeName = Console.ReadLine();

            Console.WriteLine($"Whats your powers? ");
            var powers = new Heroes();
            powers.Powers = Console.ReadLine();

            Console.WriteLine($"Whats your secret identity? ");

            var secretId = new Heroes();
            secretId.SecretId = Console.ReadLine();


            Console.WriteLine($"Whats your home world? ");
            var homeWorld = new Heroes();

            homeWorld.HomeWorld = Console.ReadLine(); //May have to write a if multiverse condition

            Console.WriteLine("Are You to the best of your knowledge a clone?");
            var isClone = new Heroes();

            isClone.IsClone = Console.ReadLine();

            Console.WriteLine($"{codeName}, {powers} , {secretId}, home world {homeWorld} clone status:{isClone}");

            Console.WriteLine("Would you like to add more heroes?");
            Console.WriteLine("Enter Yes or Y to add another Hero");
            var userChoice = Console.ReadLine();


            //List<Heroes> powers = new List<Heroes>();


            var heroesOfEarthTwo = new  //Think about Refactoring to a List<object>
            {
                codeName = codeName.CodeName,
                powers = powers.Powers,
                secretId = secretId.SecretId,
                homeWorld = homeWorld.HomeWorld,
                isClone = isClone.IsClone


            };


            var multiverseHeroes = new //Think about abstracting the hero objects into its own class
            {
                codeName = codeName.CodeName,
                powers = powers.Powers,
                secretId = secretId.SecretId,
                homeWorld = homeWorld.HomeWorld,
                isClone = isClone.IsClone
            };


            // Condition checks to see if hero is a clone 
            if (homeWorld.HomeWorld == "Earth-2")
            {

                ConvertHeroInput(heroesOfEarthTwo);// Provide an instance name 
            }
            else if (heroesOfEarthTwo.isClone == "true")
            {
                ConvertHeroInput(heroesOfEarthTwo);

            }
            else if (multiverseHeroes.isClone == "true")
            {
                ConvertMultiverseHeroInput(multiverseHeroes);

            }
            else
            {
                ConvertMultiverseHeroInput(multiverseHeroes);
            }



            //Condition allows the user to add additional heroes Options move conditional to the Main method?
            if (userChoice == "Yes")
            {
                return CaptureUserInput();

            }
            else if (userChoice == "yes")
            {
                return CaptureUserInput();

            }
            else if (userChoice == "y")
            {
                return CaptureUserInput();

            }
            else if (userChoice == "Affirmative")
            {

                return CaptureUserInput();
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine} Press any key to exit...");
                Console.ReadKey(true);

            }




            //object[] userInput = { heroesOfEarthTwo, multiverseHeroes };
            //Console.WriteLine(userInput);

            return heroesOfEarthTwo;
        }
        //TODO: Refactor Method to read json file and append to the file if no dupes exist unless the dupe is a clone 
        //Method Converts captured hero to Json  and writes to hero.json file
        public void ConvertHeroInput(object heroesOfEarthTwo)
        {

            string output = JsonConvert.SerializeObject(heroesOfEarthTwo); // converting hero Object to json  
            Console.WriteLine(output);
            var earth2FilePath = @"C:\Users\simms\learn\projects\HelloEarthTwo\HelloEarthTwo\earthTwoHeroes.json";

            // write json to .json file
            File.WriteAllText(earth2FilePath, output); // Writing our hero information to hero.json file

        }

        public void ConvertMultiverseHeroInput(object multiverseHeroes)
        {

            string multiverseOutput = JsonConvert.SerializeObject(multiverseHeroes);
            Console.WriteLine(multiverseOutput);
            var multiverseFilePath = @"C:\Users\simms\learn\projects\HelloEarthTwo\HelloEarthTwo\multiverseHeroes.json";
            // write json to .json file
            File.WriteAllText(multiverseFilePath, multiverseOutput); // Writing our hero information to hero.json file

        }

    }



}
