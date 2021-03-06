using HelloEarthTwo.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelloEarthTwo.Services
{
    public class DbCrudService : HeroService
    {

        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);



        //TODO: WIRE up CRUD interactivity with ADMIN roles for Batman, T'Challa, Xaivier, & IRONMAN 
        //------------------------------------------------------------------------------------------
        // CRUD ops below interacting with DB
        //------------------------------------------------------------------------------------------
        // CREATE
        //Insert Data to database using the SaveChanges method
        //Create a new instance of DbContext
        public void InsertSuperHero(Hero superHero)
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
                logger.Info(message: $"The inserted super Hero is: {superHero.CodeName} and the Type is: {superHero} using an instance of this database context: {db}");
                db.SaveChanges();

            }

        }

        // Currently not working need to update the db with new models and wire anti hero and villain into the app logic 
        public void InsertAntiHero(AntiHero antiHero)
        {
            //Insert Data to database using the SaveChanges method
            //Create a new instance of DbContext
            using (var db = new EFContext())
            {
                //Using our superHero instance of the Model/Domain class Heroes 

                antiHero.CodeName = "Magneto";
                antiHero.Powers = "Manipulation of electromagnetic fields";
                antiHero.SecretId = "Erik Lehnsherr";
                antiHero.TeamAffiliation = "Brotherhood Of Evil Mutants, X-Men";
                antiHero.TimeStamp = antiHero.TimeStamp;
                antiHero.IsClone = "No";
                antiHero.IsAntiHero = true;
                db.Add(antiHero);
                logger.Info(message: $"The inserted Anti Hero is: {antiHero.CodeName} and the Type is: {antiHero} using an instance of this database context: {db}");
                db.SaveChanges();

            }

        }

        //READ Uses The SELECT method
        public void ReadSuperHero(Hero superHero)
        {
            using (var db = new EFContext())
            {
                List<Hero> heroes = db.Heroes.ToList();
                foreach (Hero h in heroes)
                {
                    Console.WriteLine($"{h.Id} {h.CodeName}");
                    logger.Info(message: $"The inserted super Hero is: {superHero.CodeName} and the Type is: {superHero} using an instance of this database context: {db}"); // Produces exccessive logging
                }

            }
        }



        public void UpdateSuperHero(Hero superHero)
        {
            using (var db = new EFContext())
            {
                Hero hero = new Hero();
                hero = db.Heroes.Find(34);
                hero.CodeName = "Zatana";
                hero.HomeWorld = "Earth";
                hero.IsClone = "No";
                hero.Powers = "Mastery of Magic";
                hero.TeamAffiliation = "JLA";
                hero.TimeStamp = hero.TimeStamp;
                db.SaveChanges();
                logger.Info(message: $"The inserted super Hero is: {superHero.CodeName} and the Type is: {superHero} using an instance of this database context: {db}");
            }
        }

        //DELETE is done using The REMOVE method of the DbSet
        //TODO: Write some logic that deletes when a certain condition is met 
        public void DeleteSuperHero(Hero superHero)
        {
            using (var db = new EFContext())
            {
                superHero = db.Heroes.Find(24); // Must have a matching id or an exception will be thrown must pass some value to find
                db.Heroes.Remove(superHero);
                db.SaveChanges();
                logger.Info(message: $"The inserted super Hero is: {superHero.CodeName} and the Type is: {superHero} using an instance of this database context: {db}");

            }
        }



        //Delete duplicate Heroes 
        public void DeleteDuplicateHero(Hero superHero)
        {
            using (var db = new EFContext())
            {
                var dupeHero = db.Heroes
                    .AsEnumerable()  // had to add AsEnumerable to make it LINQ to SQL translatable big hassle OMG lol its a work around to the GroupBy bug
                        .GroupBy(sH => new
                        {
                            sH.CodeName,
                            sH.SecretId,
                            sH.HomeWorld
                        })
                    .SelectMany(grp => grp.Skip(1)).ToList();
                db.Heroes.RemoveRange(dupeHero);
                db.SaveChanges();
                logger.Info(message: $"The inserted super Hero is: {superHero.CodeName} and the Type is: {superHero} using an instance of this database context: {db}");
            }

        }

        //------------------------------------------------------------------------------------------
        // END OF CRUD OPS interacting with   DB
        //------------------------------------------------------------------------------------------
    }



}
