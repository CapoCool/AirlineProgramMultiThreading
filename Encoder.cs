using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProgram
{
    //CSV seemed to be the easiest way to do this
    class Encoder
    {
        public static string Encode(OrderClass order)
        {
            return order.senderID + "," + order.cardNo + "," + order.receiverID + "," + order.amount;
        }
    }
}
