using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace myBanker
{
    public abstract class Card
    {
        public float Balance { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }

        public Card(string holderName, string[] prefix, int cardNumberLenght = 16)
        {
            CardHolderName = holderName;
            Balance = 1000;
            AccountNumber = GenAccountNumber();
            CardNumber = GenCardNumber(cardNumberLenght, prefix);
        }

        private string GenCardNumber(int maxCardNumber, string[] prefix)
        {
            string cardNumbers = string.Empty;

            Random random = new Random();

            //Choose a random prefix
            string usedPrefix = prefix[random.Next(0, prefix.Length - 1)];

            //Gets the lenght of the remaining missing numbers
            maxCardNumber -= usedPrefix.Length;

            //Adds the prefix to string
            cardNumbers += usedPrefix;

            //Adds the remaining numbers to string
            for (int i = 0; i < maxCardNumber; i++)
            {
                cardNumbers += random.Next(0, 9).ToString();
            }

            //Make space between numbers
            int numberCount = 0;
            for (int i = 0; i < cardNumbers.Length; i++)
            {
                if (numberCount >= 4)
                {
                    cardNumbers = cardNumbers.Insert(i, " ");
                    numberCount = 0;
                }

                numberCount++;
            }

            return cardNumbers;
        }

        private string GenAccountNumber()
        {
            //Starts the accountnumber with 3520
            string accountNumber = "3520 ";

            Random random = new Random();

            //Generates 10 more number for accountnumber
            for (int i = 0; i < 10; i++)
            {
                accountNumber += random.Next(0,9);
            }

            return accountNumber;
        }

        public virtual void Pay(float amount)
        {
            Balance -= amount;
        }

        public virtual void Withdraw(float amount)
        {
            if (amount < Balance)
            {
                Balance -= amount;
            }
        }
    }
}
