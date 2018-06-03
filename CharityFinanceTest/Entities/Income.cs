using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceEntities
{
    public class Income : Transaction
    {
        private string _payingInSlip;

        public string PayingInSlip {
            get { return _payingInSlip;  }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    _payingInSlip = value;
                }
            }
        }

        public GiftAidStatus GiftAidStatus { get; set; }
    }
}
