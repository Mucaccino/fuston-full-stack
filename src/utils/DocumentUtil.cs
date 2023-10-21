using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace utils
{
    public class DocumentUtil
    {
        public static string formatCpf(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
}