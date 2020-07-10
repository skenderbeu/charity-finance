using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinanceServices;
using FinanceDomain;

namespace FinanceWeb.Pages.PaymentTypes
{
    public class DetailModel : PageModel
    {
        private readonly IPaymentTypeViewModel paymentTypeViewModel;
        public FinanceDomain.PaymentType PaymentType { get; set; }

        public DetailModel(IPaymentTypeViewModel paymentTypeViewModel)
        {
            this.paymentTypeViewModel = paymentTypeViewModel;
        }

        public void OnGet(Guid paymentTypeId)
        {
         
            PaymentType = paymentTypeViewModel.GetPaymentTypeById(paymentTypeId);

            if(PaymentType == null)
            {

            }
        }
    }
}