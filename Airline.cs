using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AirlineProgram
{

    class Airline
    {

        //Variable declaration
        private static Random rand = new Random();
        private int currPrice;
        private int prevprice;
        private const int MAX = 10;
        private int cutCount = 0;
        private ArrayList threads = new ArrayList();

        public delegate void priceCutEvent(PriceCutArgs args);
        public event priceCutEvent priceCut;

        
        /// <summary>
        /// Price cut event stuff
        /// </summary>
        private void PriceCutEvent()
        {
            if(priceCut != null)
            {
                Console.WriteLine("Price cut event!");
                cutCount++;
                priceCut(new PriceCutArgs(Thread.CurrentThread.Name, currPrice));
            }
        }

        ///// <summary>
        ///// Grabs the prices of the day
        ///// </summary>
        ///// <returns>array</returns>
        public static int getPrices()
        {
            int[] pricesOfDay = { 4, 7, 2, 6, 4, 5, 3 };
            return pricesOfDay[rand.Next(0, pricesOfDay.Length)];
        }

        /// <summary>
        /// Changes seat prices
        /// </summary>
        public void changeSeatPrices()
        {
            while(cutCount < MAX)
            {
                getRandomPrice();

                if(currPrice < prevprice)
                {
                    PriceCutEvent();
                    Program.totalEvents++;
                }

                //prevprice = currPrice;
                processOrder(getOrder());

            }

            foreach(Thread thread in threads)
            {
                while (thread.IsAlive) ;
            }
        }

        /// <summary>
        /// Just places an order in the multicellbuffer
        /// </summary>
        /// <returns></returns>
        private OrderClass getOrder()
        {
            return Decoder.Decode(Program.mb.getCell());
        }

        /// <summary>
        /// Proccesses the order
        /// </summary>
        /// <param name="order"></param>
        private void processOrder(OrderClass order)
        {
            if(order.receiverID == Thread.CurrentThread.Name || order.receiverID == null)
            {
                Console.WriteLine("Order for {0} was recieved", Thread.CurrentThread.Name);
                OrderProcessingThread processer = new OrderProcessingThread(order, currPrice);
                Thread processingThread = new Thread(new ThreadStart(processer.processOrder));
                threads.Add(processingThread);
                processingThread.Name = "Process: " + Thread.CurrentThread.Name;
                processingThread.Start();
                Program.accepts++;
            }
            else
            {
                Program.rejects++;
            }
        }

        /// <summary>
        /// grabs random price.
        /// </summary>
        /// <returns></returns>
        public void getRandomPrice()
        {
            int randPrice = 0;
            Random rand2 = new Random();

            prevprice = currPrice;
            currPrice = getPrices() + rand2.Next(-randPrice + 100, 5000);
            
        }
    }
}
