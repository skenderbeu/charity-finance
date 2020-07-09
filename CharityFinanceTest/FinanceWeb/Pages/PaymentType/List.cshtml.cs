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
    public class ListModel : PageModel
    {
        private readonly IPaymentTypeViewModel paymentTypeViewModel;
        public IEnumerable<PaymentType> PaymentTypes { get; set;} 

        public ListModel(IPaymentTypeViewModel paymentTypeViewModel)
        {
            this.paymentTypeViewModel = paymentTypeViewModel;
        }


        public void OnGet()
        {
            PaymentTypes = paymentTypeViewModel.GetPaymentTypes();
        }
    }
}