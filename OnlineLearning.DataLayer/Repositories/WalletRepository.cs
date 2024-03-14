using OnlineLearning.DataLayer.Context.EfCore;
using OnlineLearning.DataLayer.Entities.Wallet;
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

        public void ChargeWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
        }

        public decimal GetUserDeposits(int userId)
        {
            return _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPaid == true).Select(w => w.Amount).ToList().Sum();
        }

        public List<Wallet> GetUserWalets(int userId)
        {
            return _context.Wallets.Where(w => w.UserId == userId && w.IsPaid == true).Select(w => w).ToList();
        }

        public decimal GetUserWithdrawals(int userId)
        {
            return _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 2 && w.IsPaid == true).Select(w => w.Amount).ToList().Sum();
        }
    }
}
