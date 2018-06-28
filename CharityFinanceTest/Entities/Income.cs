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
                else
                {
                    throw new ArgumentException("A PayingIn Slip with non numeric characters is not allowed.");
                }
            }
        }

        public GiftAidStatus GiftAidStatus { get; set; }


        public override bool FieldsValidated()
        {
            if ((PaymentType == PaymentTypes.CASH || PaymentType == PaymentTypes.CHQ) && !string.IsNullOrEmpty(PayingInSlip))
            {
                return base.FieldsValidated();
            }
            else
            {
                return false;
            }
        }
    }
}
