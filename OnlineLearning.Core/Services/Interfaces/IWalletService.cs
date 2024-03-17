using OnlineLearning.Core.DTOs;
using OnlineLearning.DataLayer.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Services.Interfaces
{
    public interface IWalletService
    {
        public decimal BallanceUserWallet(int userId);
        public List<WalletViewModel> GetUserWalets(int userId);
        public int ChargeWallet(WalletViewModel wallet, int userId);
        public WalletViewModel GetWalletById(int walletId);
        public void UpdateWallet(WalletViewModel wallet);
    }
}
