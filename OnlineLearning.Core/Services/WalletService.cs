using OnlineLearning.Core.Services.Interfaces;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services
{
    public class WalletService : IWalletService
    {

        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public decimal BallanceUserWallet(int userId)
        {
            var deposits = _walletRepository.GetUserDeposits(userId);
            var withdrawals = _walletRepository.GetUserWithdrawals(userId);
            return deposits - withdrawals;
        }
    }
}
