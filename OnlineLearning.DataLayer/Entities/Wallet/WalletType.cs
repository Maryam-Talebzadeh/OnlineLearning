using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.DataLayer.Entities.Wallet
{
    public class WalletType
    {
        public WalletType()
        {
            
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Title { get; set; }

        #region Navigation properties

        public virtual List<Wallet> Wallets { get; set; }

        #endregion
    }
}
