using OnlineLearning.Core.DTOs;
using OnlineLearning.Core.Services.Interfaces;
using OnlineLearning.DataLayer.Entities.Wallet;
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

        public void ChargeWallet(WalletViewModel wallet, int userId)
        {
            var newWallet = new Wallet()
            {
                Amount = wallet.Amount,
                Description = wallet.Description,
                IsPaid = false,
                RegisterDate = wallet.RegisterDate,
                TypeId = wallet.Type,
                UserId = userId
            };

            _walletRepository.ChargeWallet(newWallet);
        }

        public List<WalletViewModel> GetUserWalets(int userId)
        {
            return _walletRepository.GetUserWalets(userId).Select(w => new WalletViewModel()
            {
                Amount = w.Amount,
                Description = w.Description,
                RegisterDate = w.RegisterDate,
                Type = w.TypeId
            }).ToList();
        }
    }
}
