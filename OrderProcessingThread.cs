using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AirlineProgram
{
    class OrderProcessingThread
    {
        //Variable declaration
        private OrderClass order;
        private int price;

        
        public OrderClass Order
        {
            get { return order; }
            private set { order = value; }
        }


        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// Order Processing
        /// </summary>
        /// <param name="order"></param>
        /// <param name="price"></param>
        public OrderProcessingThread(OrderClass order, int price)
        {
            this.order = order;
            this.price = price;
        }

        /// <summary>
        /// Process the order
        /// </summary>
        public void processOrder()
        {

            if(order != null)
            {
                Console.WriteLine("Order {0} for {1} is being processed", Thread.CurrentThread.Name, order.ToString());
                if (validateCardNo(order.cardNo))
                {
                    Console.WriteLine("Travel Agency {0} has a valid card");

                }
                else
                {
                    Console.WriteLine("Travel Agency {0} has an invalid card");
                }

                Console.WriteLine("Order {0} for {1} was process for a total of: {2}", order.ToString(), Thread.CurrentThread.Name, order.amount * price);
            }


        }

        /// <summary>
        /// Validate the card number. This doesn't do anything really special other than check for digits. 
        /// I'd assume that we are required to fully write out the functionality and that it's more important to understand the requirement
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool validateCardNo(int str)
        {
            return new Regex("^[0-9]*$").IsMatch(str.ToString());
        }
    }
}
