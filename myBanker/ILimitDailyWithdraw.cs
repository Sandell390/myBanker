using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public interface ILimitDailyWithdraw
    {
        float MaxDailyWithdraw { get; }

        float DailyWithdraw { get; set; }

        bool CanDailyWithdraw(float amount);

        void ResetDailyWithdraw();

    }
}
