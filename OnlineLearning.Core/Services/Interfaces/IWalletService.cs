﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services.Interfaces
{
    public interface IWalletService
    {
        public decimal BallanceUserWallet(int userId);
    }
}
