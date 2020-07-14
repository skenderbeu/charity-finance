using FinanceServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinanceDesktopView
{
    /// <summary>
    /// Interaction logic for PaymentType.xaml
    /// </summary>
    public partial class PaymentTypeForm : Window, INotifyPropertyChanged
    {
        private readonly IPaymentTypeCommand paymentTypeCommand;

        public PaymentTypeForm(IPaymentTypeCommand paymentTypeCommand)
        {
            InitializeComponent();

            this.paymentTypeCommand = paymentTypeCommand;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void BtnAddPaymentType_Click(object sender, RoutedEventArgs e)
        {
            var paymentTypeDescription = txtPaymentTypeDescription.Text;
            var paymentTypeLongDescription = txtPaymentTypeLongDescription.Text;

            if (string.IsNullOrWhiteSpace(paymentTypeDescription)) MessageBox.Show("Code is blank");
            if (string.IsNullOrWhiteSpace(paymentTypeLongDescription)) MessageBox.Show("Description is blank");


            var result = paymentTypeCommand.Add(
                    paymentTypeDescription, paymentTypeLongDescription);

            if (result.IsFailure)
            {
                MessageBox.Show(result.Error);
            }

            if (result.IsSuccess)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PaymentType"));
                    MessageBox.Show("Payment Type Added");
                }
            }
        }
    }
}