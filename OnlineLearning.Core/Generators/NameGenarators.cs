using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.Generators
{
    public class NameGenarators
    {
        public static string GenerateUniqeCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }


    }
}
