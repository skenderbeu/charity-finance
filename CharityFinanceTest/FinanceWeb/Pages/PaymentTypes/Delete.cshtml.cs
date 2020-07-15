using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceDomain;
using FinanceServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceWeb.Pages.PaymentTypes
{
    public class DeleteModel : PageModel
    {
        private readonly IPaymentTypeCommand paymentTypeCommand;
        private readonly IPaymentTypeViewModel paymentTypeViewModel;

        public PaymentType PaymentType { get; set; }

        public DeleteModel(IPaymentTypeCommand paymentTypeCommand, IPaymentTypeViewModel paymentTypeViewModel)
        {
            this.paymentTypeCommand = paymentTypeCommand;
            this.paymentTypeViewModel = paymentTypeViewModel;
        }

        public IActionResult OnGet(Guid paymentTypeId)
        {

            PaymentType = paymentTypeViewModel.GetPaymentTypeById(paymentTypeId);

            if (PaymentType == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Guid paymentTypeId)
        {
            PaymentType = paymentTypeViewModel.GetPaymentTypeById(paymentTypeId);

            if (PaymentType == null)
            {
                return RedirectToPage("./NotFound");
            }

            paymentTypeCommand.Delete(PaymentType);

            TempData["Message"] = $"{PaymentType.LongDescription} deleted";

           return RedirectToPage("./List");
        }


    }
}