using FinanceDomain;
using Repositories;
using System;
using System.Collections.Generic;

namespace FinanceServices
{
    public class IncomeCommands : IIncomeCommands
    {
        private readonly IRepository<Income> incomeRepository;

        public IncomeCommands(IRepository<Income> incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        public Result Add(string description, double amount, DateTime date, string note, PaymentType paymentType,
            BudgetType budgetType, FundType fundType, bool? giftAid = false)
        {
            Result<Note> incomeNote = Note.Create(note);
            Result<TransactionDescription> incomeDescription = TransactionDescription.Create(description);

            var incomeGiftAid = giftAid == null ?
                    GiftAidStatus.NotSet :
                        (bool)giftAid ?
                        GiftAidStatus.GiftAid :
                        GiftAidStatus.NotGiftAid;

            var result = Result.Combine(incomeNote, incomeDescription);

            if (result.IsSuccess)
            {
                var income = Income.Create(
                incomeDescription.Value, date, paymentType,
                amount, budgetType, incomeNote.Value, fundType);

                Add(income);

                return Result.Ok();
            }

            return result;
        }

        private void Add(Income income)
        {
            if (income.FieldsValidated())
            {
                incomeRepository.Add(income);
            }
        }

        public void Update(Income income)
        {
            if (income.FieldsValidated())
            {
                incomeRepository.Update(income);
            }
        }

        public void Delete(Income income)
        {
            incomeRepository.Remove(income);
        }
    }
}