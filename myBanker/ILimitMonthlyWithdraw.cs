using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public interface ILimitMonthlyWithdraw
    {
        float MaxMonthlyWithdraw { get; }

        float MonthlyWithdraw { get; set; }

        bool CanMonthlyWithdraw(float amount);

        void ResetMonhlyWithdraw();
    }
}
