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
using System.Windows.Input;
using Humanizer;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using log4net;
using System.Reflection;
using HelloEarthTwo.Models;
using System.Text.RegularExpressions;
using HelloEarthTwo.Services;

namespace HelloEarthTwo
{
    public class HeroService
    {
        //  a separate instance of logger for HeroService class
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //Method captures userInput and stores it into an Object 
        public object CaptureUserInput()
        {
            var superHero = new Hero();
            var antiHero = new AntiHero();
            var villain = new Villain();

            logger.Info($"Here we are inside of {GetType().FullName}. Let's make some heroes...");
            //Instantiationg new Heroes class on superHero instance
            Console.WriteLine("Whats your Code name? ");
            superHero.CodeName = Console.ReadLine();
            logger.Info(message: $"The Value of superHero.CodeName is:  { superHero.CodeName} and the Type is: {superHero.CodeName.GetType().FullName}"); // not sure if we need the message param but am curious to see if the messages map to the message object

            //  add some log messages to tell what happened every time user enters a value
            //  for example you can log out what they entered for superHero.CodeName with a nice message
            Console.WriteLine($"Whats your powers? ");
            superHero.Powers = Console.ReadLine();
            logger.Debug(message: $"The Value of superHero.Powers is:  {superHero.Powers} and the Type is: { superHero.Powers.GetType().FullName}");



            Console.WriteLine($"Whats your secret identity? ");
            superHero.SecretId = Console.ReadLine();
            logger.Info(message: $"The Value of superHero.SecretId: {superHero.SecretId} and the Type is: {superHero.SecretId.GetType().FullName}");

            Console.WriteLine($"Whats your home world? ");
            superHero.HomeWorld = Console.ReadLine(); //May have to write a if multiverse condition
            logger.Info(message: $"The Value of superHero.HomeWorld: {superHero.HomeWorld} and the Type is: {superHero.HomeWorld.GetType().FullName}");

            Console.WriteLine("What is your team affiliation?");
            superHero.TeamAffiliation = Console.ReadLine();
            logger.Info(message: $"The Value of superHero.TeamAffiliation: {superHero.TeamAffiliation} and the Type is: {superHero.TeamAffiliation.GetType().FullName}");

            Console.WriteLine("Are You to the best of your knowledge a clone?");
            superHero.IsClone = Console.ReadLine();
            logger.Info(message: $"The Value of superHero.IsClone: {superHero.IsClone} and the Type is {superHero.IsClone.GetType().FullName}");

            superHero.TimeStamp = DateTime.Now.ToString("dddd, MMMM dd  yyyy h:mm tt");
            logger.Info(message: $"The Value of superHero.TimeStamp: {superHero.TimeStamp} and the Type is: {superHero.TimeStamp.GetType().FullName}");

            Console.WriteLine($"Name: {superHero.CodeName}, Powers: {superHero.Powers}, Secret Identity {superHero.SecretId}, Home world: {superHero.HomeWorld}, Clone status: {superHero.IsClone} at {superHero.TimeStamp}");

            Console.WriteLine("Would you like to add more heroes?");
            Console.WriteLine("Enter Yes or Y to add another Hero");
            var userChoice = Console.ReadLine();
            PrintUserInfoReadOut();

            DbCrudService _dbCRUD = new DbCrudService();

            _dbCRUD.InsertSuperHero(superHero);
            _dbCRUD.ReadSuperHero(superHero);
            _dbCRUD.UpdateSuperHero(superHero);
            _dbCRUD.DeleteSuperHero(superHero); // TODO: wire this call to control flow of app based on user permissions
            _dbCRUD.DeleteDuplicateHero(superHero);

            _dbCRUD.InsertAntiHero(antiHero); // Need to update the db to accept new model this line is currently not working 




            //Creating an instance of our Heroes class so that I can use the HeroData List<object> to store our HeroesData
            Hero heroData = new Hero(); // Couldnt figure out a way to remove this  instance 
            heroData.HeroData.Add(superHero); //adding heroesOfEarthTwo to the HeroData List <object> via the .Add() method
            heroData.HeroData.Add(superHero);


            logger.Info(message: $"The Value of superHero.HeroData is:  {heroData.HeroData} and the Type is: { heroData.HeroData.GetType().FullName}");


            // TODO: Figure out how to write a TEST SO I dont have to Keep inputing The required Fields 

            //Creating a new instance of The HeroesList class so I can use the methods of that class in this file
            HeroesList callHeroesList = new HeroesList();

            void SortHeroesByWorld()
            {

                bool CheckIfEarth2()
                {

                    var worldCompare = superHero.HomeWorld == "Earth-2" || superHero.HomeWorld == "earth-2"
                        || superHero.HomeWorld == "earth 2" || superHero.HomeWorld == "earth two"
                        || superHero.HomeWorld == "EARTH TWO" || superHero.HomeWorld == "EARTH 2";
                    return worldCompare;
                }

                bool CheckIfMultiverse()
                {
                    var worldCompare = superHero.HomeWorld != "Earth-2" || superHero.HomeWorld != "earth-2"
                    || superHero.HomeWorld != "earth 2" || superHero.HomeWorld != "earth two"
                    || superHero.HomeWorld != "EARTH TWO" || superHero.HomeWorld != "EARTH 2";
                    return worldCompare;

                }

                if (CheckIfEarth2() == true)
                {

                    callHeroesList.ConvertHeroInput(superHero);
                }
                else if (superHero.IsClone == "true")
                {
                    callHeroesList.ConvertHeroInput(superHero);

                }
                else if (superHero.IsClone == "true")
                {
                    callHeroesList.ConvertMultiverseHeroInput(superHero);


                }
                else if (CheckIfMultiverse() == true)
                {

                    callHeroesList.ConvertMultiverseHeroInput(superHero);
                }

                else
                {

                    Console.WriteLine("System Can not find your origin in the multiverse....");
                }
            }



            SortHeroesByWorld();

            // ASK if the user would  like A read out of his info 
            void PrintUserInfoReadOut()
            {
                Console.WriteLine($"{superHero.CodeName}, Would you like a read out of your information? ");
                var userDecision = Console.ReadLine();

                var formattedString = String.Format($"{ superHero.CodeName,-10}   {superHero.Powers,-10} {superHero.SecretId,7}  {superHero.HomeWorld,11} {superHero.TeamAffiliation,13} {superHero.IsClone,15}   ");

                if (userDecision == "Yes" || userDecision == "Y" || userDecision == "y")
                {
                    // Display info in tabular format 
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    Console.WriteLine("Code Name | Powers  |  Secret Identity   | Home World | Team Affiliation | Clone Status");
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    Console.WriteLine(formattedString);
                }
                else
                {
                    Console.WriteLine($"Thank you for your service  {superHero.CodeName}. Have a nice day!");
                    Console.WriteLine($"{Environment.NewLine} Press any key to exit...");
                    Console.ReadKey(true);

                }


            }

            //Condition allows the user to add additional heroes Options 
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
                Console.WriteLine($"Okay, Safe journeys....{superHero.CodeName}");
            }



            //TODO: Create method that allows user to edit typos
            void EditTypo()
            {
                //TODO: Method should allow user to edit mistakes in all input fields bay pressing ctrl Z to go back or something similar 
                // May have to save the state of the app and loop backwards over the saved state like rewinding a tape


            }
            EditTypo();

            object[] userInput = { superHero, superHero };
            Console.WriteLine(userInput);

            Console.WriteLine($"The value of heroData is {heroData.HeroData}");
            //Console.WriteLine($"The Length of HeroData ia " { heroData.HeroData.Last<object>});


            return superHero;
        }


    }



}
