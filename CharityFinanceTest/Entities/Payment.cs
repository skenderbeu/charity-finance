using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceEntities
{
    public class Payment: Transaction
    {
        public SpendTypes SpendType { get; set; }
    }
}
