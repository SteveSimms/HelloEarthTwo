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

namespace HelloEarthTwo
{
    public class HeroService
    {
        //  a separate instance of logger for HeroService class
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //Method captures userInput and stores it into an Object 
        public object CaptureUserInput()
        {
            var superHero = new Heroes();
            // Initialize a new instance of the SpeechSynthesizer.







            logger.Info($"Here we are inside of {GetType().FullName}. Let's make some heroes...");
            //Instantiationg new Heroes class on superHero instance
            Console.WriteLine($"Whats your code name? ");
            //var superHero = new Heroes();
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
            //Heroes timeStamp = DateTime.UtcNow.Humanize();
            logger.Info(message: $"The Value of superHero.TimeStamp: {superHero.TimeStamp} and the Type is: {superHero.TimeStamp.GetType().FullName}");

            Console.WriteLine($"Name: {superHero.CodeName}, Powers: {superHero.Powers} ,Secret Identity {superHero.SecretId}, home world: {superHero.HomeWorld} clone status: {superHero.IsClone} at {superHero.TimeStamp}");

            Console.WriteLine("Would you like to add more heroes?");
            Console.WriteLine("Enter Yes or Y to add another Hero");
            var userChoice = Console.ReadLine();
            printUserInfoReadOut();


            //// CREATE
            static void insertSuperHero(Heroes superHero)
            {
                //Insert Data to database using the SaveChanges method
                //Create a new instance of DbContext
                using (var db = new EFContext())
                {
                    //Using our superHero instance of the Model/Domain class Heroes 

                    superHero.CodeName = superHero.CodeName;
                    superHero.Powers = superHero.Powers;
                    superHero.SecretId = superHero.SecretId;
                    superHero.HomeWorld = superHero.HomeWorld;
                    superHero.TeamAffiliation = superHero.TeamAffiliation;
                    superHero.TimeStamp = superHero.TimeStamp;
                    db.Add(superHero);
                    db.SaveChanges();

                }

            }
            insertSuperHero(superHero);


            //READ USes The SELECT method
            static void readSuperHero(Heroes superHero)
            {
                using (var db = new EFContext())
                {
                    List<Heroes> heroes = db.Heroes.ToList();
                    foreach (Heroes h in heroes)
                    {
                        Console.WriteLine("{0} {1}", h.Id, h.CodeName);
                    }

                }
            }
            readSuperHero(superHero);
            //UPDATE uses the FIND method 
            static void updateSuperHero(Heroes superHero)
            {
                using (var db = new EFContext())
                {
                    superHero = db.Heroes.Find(3);
                    superHero.CodeName = "Zatana";
                    superHero.HomeWorld = "Earth";
                    superHero.IsClone = "No";
                    superHero.Powers = "Mastery of Magic";
                    superHero.TeamAffiliation = "JLA";
                    superHero.TimeStamp = superHero.TimeStamp;
                    db.SaveChanges();
                }
            }

            updateSuperHero(superHero);
            //DELETE

            //Creating an instance of our Heroes class so that I can use the HeroData List<object> to store our HeroesData
            Heroes heroData = new Heroes(); // Couldnt figure out a way to remove this  instance 
            heroData.HeroData.Add(superHero); //adding heroesOfEarthTwo to the HeroData List <object> via the .Add() method
            heroData.HeroData.Add(superHero);


            foreach (var hero in heroData.HeroData)
            {
                Console.WriteLine($"The value of heroData.HeroData{ hero}"); // the List is being overwritten by the next entry 
            }

            logger.Info(message: $"The Value of superHero.HeroData is:  {heroData.HeroData} and the Type is: { heroData.HeroData.GetType().FullName}");


            // TODO: Figure out how to write a TEST SO I dont have to Keep inputing The required Fields 

            //Creating a new instance of The HeroesList class so I can use the methods of that class in this file
            HeroesList callHeroesList = new HeroesList();

            void sortHeroesByWorld()
            {

                bool checkIfEarth2()
                {

                    var worldCompare = superHero.HomeWorld == "Earth-2" || superHero.HomeWorld == "earth-2"
                        || superHero.HomeWorld == "earth 2" || superHero.HomeWorld == "earth two"
                        || superHero.HomeWorld == "EARTH TWO" || superHero.HomeWorld == "EARTH 2";
                    return worldCompare;
                }

                bool checkIfMultiverse()
                {
                    var worldCompare = superHero.HomeWorld != "Earth-2" || superHero.HomeWorld != "earth-2"
                    || superHero.HomeWorld != "earth 2" || superHero.HomeWorld != "earth two"
                    || superHero.HomeWorld != "EARTH TWO" || superHero.HomeWorld != "EARTH 2";
                    return worldCompare;

                }

                if (checkIfEarth2() == true)
                {

                    callHeroesList.ConvertHeroInput(superHero);// Provide an instance name 
                }
                else if (superHero.IsClone == "true")
                {
                    callHeroesList.ConvertHeroInput(superHero);

                }
                else if (superHero.IsClone == "true")
                {
                    callHeroesList.ConvertMultiverseHeroInput(superHero);


                }
                else if (checkIfMultiverse() == true)
                {

                    callHeroesList.ConvertMultiverseHeroInput(superHero);
                }

                else
                {

                    Console.WriteLine("System Can not find your origin in the multiverse....");
                }
            }



            sortHeroesByWorld();

            // ASK if the user would  like A read out of his info 
            void printUserInfoReadOut()
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
            void editTypo()
            {
                //TODO: Method should allow user to edit mistakes in all input fields bay pressing ctrl Z to go back or something similar 
                // May have to save the state of the app and loop backwards over the saved state like rewinding a tape


            }
            editTypo();

            object[] userInput = { superHero, superHero };
            Console.WriteLine(userInput);

            Console.WriteLine($"The value of heroData is {heroData.HeroData}");
            //Console.WriteLine($"The Length of HeroData ia " { heroData.HeroData.Last<object>});


            return superHero;
        }


    }



}
