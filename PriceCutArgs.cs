using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProgram
{
    class PriceCutArgs : EventArgs
    {

        //Class to help maintiain the arguments with the price cuts


        private int price;
        private string id;

        public PriceCutArgs(string id, int price)
        {
            this.Id = id;
            this.Price = price;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Price
        {
            get { return price; }
            private set { price = value; }
        }
    }
}
