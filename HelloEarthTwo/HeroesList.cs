using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
//using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HelloEarthTwo
{

    public class HeroesList : Heroes
    {


        //TODO: Refactor Method to read json file and append to the file if no dupes exist unless the dupe is a clone 
        //Method Converts captured hero to Json  and writes to hero.json file
        public void ConvertHeroInput(object superHero)
        {
            string output = JsonConvert.SerializeObject(superHero); // converting hero Object to json  
            //Console.WriteLine(output);
            var earth2FilePath = @"C:\Users\simms\learn\projects\HelloEarthTwo\HelloEarthTwo\earthTwoHeroes.json";

            File.WriteAllText(earth2FilePath, output);// Writing our hero information to hero.json file
                
        }
        public void ConvertMultiverseHeroInput(object superHero)
        {

            string multiverseOutput = JsonConvert.SerializeObject(superHero);
            //Console.WriteLine(multiverseOutput);
            var multiverseFilePath = @"C:\Users\simms\learn\projects\HelloEarthTwo\HelloEarthTwo\multiverseHeroes.json";
            // write json to .json file
            File.WriteAllText(multiverseFilePath, multiverseOutput); // Writing our hero information to hero.json file              
           

        }

    }

}
