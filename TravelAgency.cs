using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AirlineProgram
{
    class TravelAgency
    {


        private static bool airlinesActive = true;
        private static Random rand = new Random();
        private int price;
        private string id;
        public int ordersMade = 0;

        /// <summary>
        /// Prints and sleeps the thread after the price cut event is initiated
        /// </summary>
        public void OnSale()
        {
            Console.Write("Price Cut event!");
            Thread.Sleep(500);
        }

        /// <summary>
        /// Creates the order and then pauses it to help see what is happening
        /// </summary>
        public void TravelAgencyApp()
        {
            while (airlinesActive)
            {
                
                createTravelOrder(id);
                Thread.Sleep(500);
                  
            }
        }

        //subscrice to the event
        public void subscribe(Airline airline)
        {
            Console.WriteLine("Subscribing to price cut event");
            airline.priceCut += createOrder;
        }

        //Used to create the order
        private void createTravelOrder(string id)
        {
            OrderClass order = new OrderClass();
            order.amount = rand.Next(1, 30);
            order.cardNo = rand.Next(1000000, 10000000);
            order.senderID = Thread.CurrentThread.Name;
            order.receiverID = id;
            order.date = DateTime.Now;

            Program.mb.setCell(Encoder.Encode(order));
            Program.orders++;

        }

        public void createOrder(PriceCutArgs args)
        {
            id = args.Id;
            price = args.Price;
        }

        public static bool AirlinesActive
        {
            get { return TravelAgency.airlinesActive; }
            set { TravelAgency.airlinesActive = value; }
        }

    }
}
