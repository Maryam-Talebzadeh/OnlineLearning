using OnlineLearning.DataLayer.Context.EfCore;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly OnlineLearningContext _context;

        public WalletRepository(OnlineLearningContext context)
        {
            _context = context;
        }

        public decimal GetUserDeposits(int userId)
        {
            return _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 1).Select(w => w.Amount).ToList().Sum();
        }

        public decimal GetUserWithdrawals(int userId)
        {
            return _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 2).Select(w => w.Amount).ToList().Sum();
        }
    }
}
