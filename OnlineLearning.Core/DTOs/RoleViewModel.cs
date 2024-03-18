using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.DTOs
{
    public class RoleViewModel
    {
        public int Id { get; set; }

[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
[Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
