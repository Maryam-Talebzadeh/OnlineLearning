using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.DTOs
{
    public class InformationUserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Wallet { get; set; } = 0;
        public string ImageName { get; set; }
    }

    public class SidebarUserPanelViewModel
    {
        public string Username { get; set; }
        public DateTime RegisterDate { get; set; }
        public string ImageName { get; set; }
    }
}
