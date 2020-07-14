using FinanceDomain;
using FinanceServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace FinanceWeb.Pages.PaymentTypes
{
    public class DetailModel : PageModel
    {
        private readonly IPaymentTypeViewModel paymentTypeViewModel;
        public PaymentType PaymentType { get; set; }

        public DetailModel(IPaymentTypeViewModel paymentTypeViewModel)
        {
            this.paymentTypeViewModel = paymentTypeViewModel;
        }

        public IActionResult OnGet(Guid paymentTypeId)
        {
         
            PaymentType = paymentTypeViewModel.GetPaymentTypeById(paymentTypeId);

            if(PaymentType == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}