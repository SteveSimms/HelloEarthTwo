using System;
using log4net;
using System.Reflection;

namespace HelloEarthTwo
{
    public class HeroService
    {
        //  a separate instance of logger for HeroService class
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //Method captures userInput and stores it into an Object 
        public object CaptureUserInput()
        {
            logger.Info($"Here we are inside of {GetType().Name}. Let's make some heroes...");
            //Instantiationg new Heroes class on ReadLine() method
            Console.WriteLine($"Whats your code name? ");
            var superHero = new Heroes();
            superHero.CodeName = Console.ReadLine();

            //  TODO: add some log messages to tell what happened every time user enters a value
            //  for example you can log out what they entered for superHero.CodeName with a nice message

            Console.WriteLine($"Whats your powers? ");
            superHero.Powers = Console.ReadLine();

            Console.WriteLine($"Whats your secret identity? ");
            superHero.SecretId = Console.ReadLine();


            Console.WriteLine($"Whats your home world? ");
            superHero.HomeWorld = Console.ReadLine(); //May have to write a if multiverse condition

            Console.WriteLine("What is your team affiliation?");
            superHero.TeamAffiliation = Console.ReadLine();

            Console.WriteLine("Are You to the best of your knowledge a clone?");
            superHero.IsClone = Console.ReadLine();

            Console.WriteLine($"Name: {superHero.CodeName}, Powers: {superHero.Powers} ,Secret Identity {superHero.SecretId}, home world: {superHero.HomeWorld} clone status:{superHero.IsClone}");

            Console.WriteLine("Would you like to add more heroes?");
            Console.WriteLine("Enter Yes or Y to add another Hero");
            var userChoice = Console.ReadLine();







            //Creating an instance of our Heroes class so that I can use the HeroData List<object> to store our HeroesData
            Heroes heroData = new Heroes(); // Couldnt figure out a way to remove this  instance 
            heroData.HeroData.Add(superHero); //adding heroesOfEarthTwo to the HeroData List <object> via the .Add() method
            heroData.HeroData.Add(superHero);




            // TODO: FIgure out how to write a TEST SO I dont have to Keep inputing The required Fields 

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
                //TODO: Edit sorting condition to allow diffrent spellings of earth-2 ie: earth-2, earth two EARTH TWO EARTH 2 etc etc 
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
                printUserInfoReadOut();
            }

            //TODO: ASK if the user would  like A read out of his info 
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

            //TODO: Create method that allows user to edit typos
            void editTypo()
            {
                //TODO: Method should allow user to edit mistakes in all input fields bay pressing ctrl Z to go back or something similar 
                // May have to save the state of the app and loop backwards over the saved state like rewinding a tape


            }
            editTypo();

            object[] userInput = { superHero, superHero };
            Console.WriteLine(userInput);
            //Console.WriteLine($"The value of heroData is {heroData}");

            return superHero;
        }


    }



}
