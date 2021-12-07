using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public class MasterCard : Card, ILimitMonthlyUse, ILimitDailyWithdraw, ILimitMonthlyWithdraw, IExpiryDate
    {
        //Daily Withdraw
        public float MaxDailyWithdraw { get; } = 5000;

        public float DailyWithdraw { get; set; }

        //Monthly Withdraw
        public float MaxMonthlyWithdraw { get; } = 30000;

        public float MonthlyWithdraw { get; set; }

        //Monthly Usage
        public float MaxMonthlyUsage { get; } = 40000;
        public float MonthlyUsage { get; set; }

        //Expiry Date
        public DateTime ExpiryDate { get; set; }

        public MasterCard(string holderName) : base(holderName, new[] { "4026", "417500", "4508", "4844", "4913", "4917" })
        {
            GenExpiryDate();
        }

        #region Withdraw stuff
        

        public bool CanDailyWithdraw(float amount)
        {
            //Checks if daliy withdraw will exceed Maximum daliy withdraw on next withdraw
            if (DailyWithdraw + amount < MaxDailyWithdraw)
            {
                return true;
            }

            return false;
        }

        public bool CanMonthlyWithdraw(float amount)
        {
            //Checks if monthly withdraw will exceed Maximum monthly withdraw on next withdraw
            if (MonthlyWithdraw + amount < MaxMonthlyWithdraw)
            {
                return true;
            }

            return false;
        }

        public override void Withdraw(float amount)
        {
            if (CanDailyWithdraw(amount) && CanMonthlyWithdraw(amount))
            {
                base.Withdraw(amount);
            }

        }
        public void ResetDailyWithdraw()
        {
            DailyWithdraw = 0;
        }

        public void ResetMonhlyWithdraw()
        {
            MonthlyWithdraw = 0;
        }

        #endregion

        #region MonthlyUsage stuff
        

        public bool CanMonthlyPay(float amount)
        {
            //Checks if monthly usage will exceed Maximum Monthly usage on next payment
            if (MonthlyUsage + amount < MaxMonthlyUsage)
            {
                return true;
            }

            return false;
        }

        public override void Pay(float amount)
        {
            //Checks if the monthly usage has reachs its limit
            if (CanMonthlyPay(amount) && amount < Balance && !IsExpired())
            {
                base.Pay(amount);
                MonthlyUsage += amount;
            }
        }


        public void ResetMonthlyUsage()
        {
            MonthlyUsage = 0;
        }
        #endregion

        #region ExpiryDate stuff

        

        public void GenExpiryDate()
        {
            //Adds 5 year from today
            ExpiryDate = DateTime.Now.AddYears(5);
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
