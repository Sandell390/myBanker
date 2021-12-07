using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public class Hævekort : ICard
    {
     
        public Hævekort(string holderName)
        {
            typeCard = "Hævekort";
            cardHolderName = holderName;
            minAge = 0;

        }

        public float balance { get; set; }
        public string cardHolderName { get; set; }
        public string cardNumber { get; set; }
        public int[] cardStartNumbers { get; set; }
        public DateTime expiryDate { get; set; }
        public int minAge { get; set; }
        public string typeCard { get; set; }

        public bool checkAge(int age)
        {
            if (age > minAge)
                return true;

            return false;
        }
    }
}
