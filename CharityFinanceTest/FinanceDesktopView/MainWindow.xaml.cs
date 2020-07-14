using FinanceDomain;
using FinanceServices;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace FinanceDesktopView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IIncomeViewModel incomeViewModel;
        private readonly IIncomeCommands incomeCommands;

        public MainWindow(IIncomeViewModel incomeViewModel, IIncomeCommands incomeCommands)
        {
            InitializeComponent();

            this.incomeViewModel = incomeViewModel;
            this.incomeCommands = incomeCommands;

            BindCmbPaymentType();

            cmbBudgetType.ItemsSource = incomeViewModel.GetBudgetTypes();

            cmbFundType.ItemsSource = incomeViewModel.GetFundTypes();
        }

        private void BtnAddIncome_Click(object sender, RoutedEventArgs e)
        {

            double amount;

            if (double.TryParse(txtIncomeAmount.Text, out amount))
            {
                var result = incomeCommands.Add(
                   txtIncomeDescription.Text,
                   amount,
                   dtIncomeDate.DisplayDate,
                   txtIncomeNote.Text,
                   (PaymentType)cmbPaymentType.SelectedItem,
                   (BudgetType)cmbBudgetType.SelectedItem,
                   (FundType)cmbFundType.SelectedItem,
                   cbGiftAid.IsChecked);

                if (result.IsFailure)
                {
                    MessageBox.Show(result.Error);
                }

                if (result.IsSuccess)
                {
                    MessageBox.Show("Income Added");
                }
            }
            else
            {
                MessageBox.Show("Amount not a valid number");
            }
        }

        private void BtnAddPayment_Click(object sender, RoutedEventArgs e)
        {
        }

        private void PaymentType_Click(object sender, RoutedEventArgs e)
        {
            var paymentTypeForm = new PaymentTypeForm();
            paymentTypeForm.PropertyChanged -= PaymentTypeForm_paymentTypeChanged;
            paymentTypeForm.PropertyChanged += PaymentTypeForm_paymentTypeChanged;
            paymentTypeForm.Show();
        }

        private void BindCmbPaymentType()
        {
            cmbPaymentType.ItemsSource = incomeViewModel.GetPaymentTypes();
        }

        private void PaymentTypeForm_paymentTypeChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            BindCmbPaymentType();
        }

        private void BudgetType_Click(object sender, RoutedEventArgs e)
        {
            var budgetTypeForm = new BudgetTypeForm();
            budgetTypeForm.Show();
        }

        private void FundType_Click(object sender, RoutedEventArgs e)
        {
            var fundTypeForm = new FundTypeForm();
            fundTypeForm.Show();
        }

        private void SpendType_Click(object sender, RoutedEventArgs e)
        {
            var spendTypeForm = new SpendTypeForm();
            spendTypeForm.Show();
        }
    }
}