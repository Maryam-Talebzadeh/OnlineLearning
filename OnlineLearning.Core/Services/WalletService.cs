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

        public int ChargeWallet(WalletViewModel wallet, int userId)
        {
            var newWallet = new Wallet()
            {
                Id = wallet.Id,
                Amount = wallet.Amount,
                Description = wallet.Description,
                IsPaid = false,
                RegisterDate = wallet.RegisterDate,
                TypeId = wallet.Type,
                UserId = userId
            };

           return _walletRepository.ChargeWallet(newWallet);
        }

        public List<WalletViewModel> GetUserWalets(int userId)
        {
            return _walletRepository.GetUserWalets(userId).Select(w => new WalletViewModel()
            {
                Id = w.Id,
                IsPaid = w.IsPaid,
                Amount = w.Amount,
                Description = w.Description,
                RegisterDate = w.RegisterDate,
                Type = w.TypeId
            }).ToList();
        }

        public WalletViewModel GetWalletById(int walletId)
        {
            var wallet = _walletRepository.GetWalletById(walletId);

            return new WalletViewModel()
            {
                Id = wallet.Id,
                IsPaid = wallet.IsPaid,
                Amount = wallet.Amount,
                Description = wallet.Description,
                RegisterDate = wallet.RegisterDate,
                Type = wallet.TypeId
            };
        }

        public void UpdateWallet(WalletViewModel wallet)
        {
            var dbWallet = GetWalletById(wallet.Id);
            dbWallet.IsPaid = wallet.IsPaid;
            _walletRepository.Update();
        }
    }
}
