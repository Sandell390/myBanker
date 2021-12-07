using System;

namespace myBanker
{
    public interface ICard
    {
        float balance { get; set; }
        string cardHolderName { get; set; }
        string cardNumber { get; set; }
        int[] cardStartNumbers { get; set; }
        DateTime expiryDate { get; set; }
        int minAge { get; set; }
        string typeCard { get; set; }
        bool checkAge(int age);
    }
}