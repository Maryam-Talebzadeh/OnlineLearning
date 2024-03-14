﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.DTOs
{
    public class ChargeWalletViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "مبلغ")]
        public Decimal Amount { get; set; }
    }

    public class WalletViewModel
    {
        public Decimal Amount { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
