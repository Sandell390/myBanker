using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public class VISAElectronCard : Card, ILimitMonthlyUse
    {
        //Monthly Usage
        public float MaxMonthlyUsage { get; } = 10000;
        public float MonthlyUsage { get; set; }

        public VISAElectronCard(string holderName) : base(holderName, new[] { "4026", "417500", "4508", "4844", "4913", "4917" })
        {

        }

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
            if (CanMonthlyPay(amount) && amount < Balance)
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

    }
}
