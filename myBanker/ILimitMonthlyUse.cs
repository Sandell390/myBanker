using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public interface ILimitMonthlyUse
    {
        float MaxMonthlyUsage{ get; }

        float MonthlyUsage { get; set; }

        bool CanMonthlyPay(float amount);

        void ResetMonthlyUsage();
    }
}
