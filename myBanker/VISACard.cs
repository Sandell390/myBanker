using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public class VISACard : Card, ILimitMonthlyWithdraw, ILimitMonthlyUse, IExpiryDate
    {
        //Expiry Date
        public DateTime ExpiryDate { get; set; }

        //MonthlyWithdraw
        public float MaxMonthlyWithdraw { get; } = 25000;

        public float MonthlyWithdraw { get; set; }

        //MonthlyUsage
        public float MaxMonthlyUsage { get; } = 20000;
        public float MonthlyUsage { get; set; }

        public VISACard(string holderName) : base(holderName, new []{"4"})
        {
            GenExpiryDate();
        }

        #region Withdraw stuff

        public bool CanMonthlyWithdraw(float amount)
        {
            //Checks if monthly withdraw will exceed Maximum Monthly withdraw on next withdraw
            if (MonthlyWithdraw + amount < MaxMonthlyWithdraw)
            {
                return true;
            }

            return false;
        }

        public override void Withdraw(float amount)
        {
            if (CanMonthlyWithdraw(amount))
            {
                base.Withdraw(amount);
            }

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
            if (CanMonthlyPay(amount) && !IsExpired())
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
