using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Entities.Wallet
{
    public class Wallet
    {
        public Wallet()
        {
            
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }


        #region Navigation properties

        public virtual User User { get; set; }
        public virtual WalletType Type { get; set; }

        #endregion
    }
}
