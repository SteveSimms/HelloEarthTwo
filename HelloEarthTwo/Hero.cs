﻿using System;
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

            Console.WriteLine("What is your team affiliation?");
            var teamAffiliation = new HeroesList();

            teamAffiliation.TeamAffiliation = Console.ReadLine();

            Console.WriteLine("Are You to the best of your knowledge a clone?");
            var isClone = new Heroes();

            isClone.IsClone = Console.ReadLine();

            Console.WriteLine($"{codeName}, {powers} , {secretId}, home world {homeWorld} clone status:{isClone}");

            Console.WriteLine("Would you like to add more heroes?");
            Console.WriteLine("Enter Yes or Y to add another Hero");
            var userChoice = Console.ReadLine();





            var heroesOfEarthTwo = new  //Think about Refactoring to a List<object>
            {
                codeName = codeName.CodeName,
                powers = powers.Powers,
                secretId = secretId.SecretId,
                homeWorld = homeWorld.HomeWorld,
                teamAffiliation = teamAffiliation.TeamAffiliation,
                isClone = isClone.IsClone


            };


            var multiverseHeroes = new //Think about abstracting the hero objects into its own class
            {
                codeName = codeName.CodeName,
                powers = powers.Powers,
                secretId = secretId.SecretId,
                homeWorld = homeWorld.HomeWorld,
                teamAffiliation = teamAffiliation.TeamAffiliation,
                isClone = isClone.IsClone
            };



            // TODO: FIgure out how to write a TEST SO I dont have to Keep inputing The required Fields 

            //Creating a new instance of THe HeroesList class so I can use the methods of that class in thia file
            HeroesList callHeroesList = new HeroesList();

            void sortHeroesByWorld()
            {

                if (homeWorld.HomeWorld == "Earth-2")
                {

                    callHeroesList.ConvertHeroInput(heroesOfEarthTwo);// Provide an instance name 
                }
                else if (heroesOfEarthTwo.isClone == "true")
                {
                    callHeroesList.ConvertHeroInput(heroesOfEarthTwo);

                }
                else if (multiverseHeroes.isClone == "true")
                {
                    callHeroesList.ConvertMultiverseHeroInput(multiverseHeroes);


                }
                else if (multiverseHeroes.homeWorld != "Earth-2")
                {

                    callHeroesList.ConvertMultiverseHeroInput(multiverseHeroes);
                }

                else
                {

                    Console.WriteLine("System Can not find your origin in the multiverse....");
                }
            }



            sortHeroesByWorld();
     


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




            object[] userInput = { heroesOfEarthTwo, multiverseHeroes };
            Console.WriteLine(userInput);

            return heroesOfEarthTwo;
        }


    }



}
