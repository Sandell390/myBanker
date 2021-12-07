﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanker
{
    public interface IExpiryDate
    {
        DateTime ExpiryDate { get; set; }

        void GenExpiryDate();

        bool IsExpired();
    }
}
