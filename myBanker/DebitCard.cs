using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public class DebitCard : Card
    {
        public DebitCard(string holderName) : base(holderName, new[] { "2400" })
        {

        }

        public override void Pay(float amount)
        {
            //Checks so the card can be overdrawn
            if (amount < Balance)
            {
                base.Pay(amount);
            }
            else
            {
                //Error Message
            }
        }
    }
}
