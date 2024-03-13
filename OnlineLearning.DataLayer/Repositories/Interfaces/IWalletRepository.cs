using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        public decimal GetUserDeposits(int userId);
        public decimal GetUserWithdrawals(int userId);
    }
}
