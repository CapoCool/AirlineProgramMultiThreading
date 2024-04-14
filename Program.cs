using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AirlineProgram
{

    class Program
    {

        public static int accepts = 0;
        public static int rejects = 0;
        public static int orders = 0;
        public static int totalEvents = 0;
        public static int numOfAir = 2;
        public static int numOfTrav = 5;
        private static Thread[] airlineThreads = new Thread[numOfAir];
        private static Thread[] travelThreads = new Thread[numOfTrav];
        private static Airline[] airlines = new Airline[numOfAir];

        public static MultiCellBuffer mb = new MultiCellBuffer();

        static void Main(string[] args)
        {
            for(int i = 0; i < numOfAir; i++)
            {
                Airline newAirline = new Airline();
                airlines[i] = newAirline;
                airlineThreads[i] = new Thread(newAirline.changeSeatPrices);
                airlineThreads[i].Name = "Airline " + i;
                airlineThreads[i].Start();
                while (!airlineThreads[i].IsAlive) ;
            }

            for(int i = 0; i < numOfTrav; i++)
            {
                TravelAgency agency = new TravelAgency();

                for(int j = 0; j < numOfAir; j++)
                {
                    agency.subscribe(airlines[j]);
                }

                travelThreads[i] = new Thread(agency.TravelAgencyApp);
                travelThreads[i].Name = "Agency " + i;
                travelThreads[i].Start();
                while (!travelThreads[i].IsAlive) ;
            }

            for(int i = 0; i < numOfAir; i++)
            {
                while (airlineThreads[i].IsAlive) ;
            }

            for(int i = 0; i < numOfTrav; i++)
            {
                TravelAgency.AirlinesActive = false;
            }

            Console.WriteLine("Accepts {0}", accepts);
            Console.WriteLine("Rejects {0}", rejects);
            Console.WriteLine("Total Orders {0}", orders);
            Console.WriteLine("Events {0}", totalEvents);
            Console.ReadKey();


        }
    }
}
