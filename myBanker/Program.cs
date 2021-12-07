using System;
using System.Collections.Generic;

namespace myBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Generates new cards
            List<Card> cards = new List<Card>();
            cards.Add(new DebitCard("Jesper Sandell"));
            cards.Add(new MaestroCard("John Larsen"));
            cards.Add(new VISAElectronCard("Mike Hunt"));
            cards.Add(new MasterCard("Bob Lund"));
            cards.Add(new VISACard("Astrid Grøndal"));



            //Shows the info from cards
            foreach (Card card in cards)
            {
                Console.WriteLine($"Card holder Name: {card.CardHolderName}");
                Console.WriteLine($"Card Numbers: {card.CardNumber}");
                Console.WriteLine($"Card Account number: {card.AccountNumber}");

                //Checks which Interface card has

                if (card is ILimitMonthlyUse monthlyUse)
                {
                    Console.WriteLine($"Card Monthly Usage: {monthlyUse.MonthlyUsage}"); 
                }

                if (card is ILimitDailyWithdraw daliyWithdraw)
                {
                    Console.WriteLine($"Card Daliy Withdraw amount: {daliyWithdraw.DailyWithdraw}");
                }

                if (card is ILimitMonthlyWithdraw monthlyWithdraw)
                {
                    Console.WriteLine($"Card Monthly Withdraw amount: {monthlyWithdraw.MonthlyWithdraw}");
                }

                if (card is IExpiryDate expiryDate)
                {
                    Console.WriteLine($"Card Expiry Date: {expiryDate.ExpiryDate.Date}");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
