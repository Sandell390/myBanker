using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public class MaestroCard : Card, IExpiryDate
    {
        //Expiry Date
        public DateTime ExpiryDate { get; set; }

        public MaestroCard(string holderName) : base(holderName, new[] { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" }, 19)
        {
            GenExpiryDate();
        }

        public override void Pay(float amount)
        {
            //Checks so the card can be overdrawn and if it is expired
            if (amount < Balance && !IsExpired())
            {
                base.Pay(amount);
            }
            else
            {
                //Error Message
            }
        }

        #region ExpiryDate stuff

        

        
        public void GenExpiryDate()
        {
            //Adds 5 year and 8 months from today
            ExpiryDate = DateTime.Now.AddYears(5).AddMonths(8);
        }

        public bool IsExpired()
        {
            //Checks if exipyDate has exceed today's date
            if (ExpiryDate > DateTime.Now)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
