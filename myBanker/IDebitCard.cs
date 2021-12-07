using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    interface IDebitCard : ICard
    {
        void Withdraw(float amount);

    }
}
