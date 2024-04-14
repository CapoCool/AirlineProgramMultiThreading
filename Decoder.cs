using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProgram
{
    class Decoder
    {

        //I figured we didn't have to go too crazy with the encoder decoder, so I just went with CSV type thing to make it
        //easier on myself
        public static OrderClass Decode(string order)
        {
            OrderClass dOrder = new OrderClass();
            string[] orderArray = order.Split(',');
            dOrder.senderID = orderArray[0];
            dOrder.cardNo = Int32.Parse(orderArray[1]);
            dOrder.receiverID = orderArray[2];
            dOrder.amount = Convert.ToInt32(orderArray[3]);

            return dOrder;
        }
    }
}
