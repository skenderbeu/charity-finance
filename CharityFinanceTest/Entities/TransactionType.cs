using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceEntities
{
    public struct TransactionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
    }
}