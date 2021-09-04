using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;
using log4net;
using System.Reflection;
using log4net.Config;

namespace HelloEarthTwo
{
    class Program
    {
        /*
            LOGGING is one of the most important apects of API development, especially high level projects 
            that are distruted across multiple servers in the cloud. This project is now using log4net 
            which is an open-source library by Apache made for logging: https://logging.apache.org/log4net/

            Here is a tutorial on how to install it:https://jakubwajs.wordpress.com/2019/11/28/logging-with-log4net-in-net-core-3-0-console-app/
            These steps are already done but it's good to understand how it was installed.
         
         */

        //  This is a private static property which means it will ONLY be available inside of the Program class.
        //  Each instance of logger is tied to the class that it's writing from so that in the log output later on
        //  you can see where the messages came from. MethodBase.GetCurrentMethod().DeclaringType is giving us
        //  a reference to the current class i.e. Program in this case
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            //  Log some things
            //  logger has different levels of severity to make them easier to sort out later on
            logger.Info("Hello logging world!");
            logger.Error("Error!");
            logger.Warn("Warn!");

            var heroFile = new HeroService();
            heroFile.CaptureUserInput();


            //Enhance the application to prompt the user for their name and display it along with the date and time.
            var CurrentDate = DateTime.Now;
            //Console.WriteLine($"{Environment.NewLine} Salam, {name} on {CurrentDate:d} at {CurrentDate:t}!");

        }



    }


}

