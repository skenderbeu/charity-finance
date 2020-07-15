using FinanceServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace FinanceWeb.Pages.PaymentTypes
{
    public class ListModel : PageModel
    {
        private readonly IPaymentTypeViewModel paymentTypeViewModel;
        public string Message { get; set; }
        public IEnumerable<FinanceDomain.PaymentType> PaymentTypes { get; set;} 

        public ListModel(IPaymentTypeViewModel paymentTypeViewModel)
        {
            this.paymentTypeViewModel = paymentTypeViewModel;
        }


        public void OnGet()
        {
            PaymentTypes = paymentTypeViewModel.GetPaymentTypes();
            if (TempData["Message"] != null)
            {
                Message = TempData["Message"].ToString();
            }
        }
    }
}