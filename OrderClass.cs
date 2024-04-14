using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProgram
{
    class OrderClass
    {

        //Basic order class
        public override string ToString()
        {
            return "ORDER\n\t{ID: " + senderID
                + "}\n\t{RECEIVER_ID: " + receiverID
                + "}\n\t{CARD_NO: " + cardNo
                + "}\n\t{AMOUNT: " + amount
                + "}\n\t{CREATED: " + date.ToString("MM-dd-yyyy h:mm:ss tt") + "}";
        }

        public string senderID { get; set; }
        public string receiverID { get; set; }
        public int cardNo { get; set; }
        public int amount { get; set; }
        public DateTime date { get; set; }

    }
}
