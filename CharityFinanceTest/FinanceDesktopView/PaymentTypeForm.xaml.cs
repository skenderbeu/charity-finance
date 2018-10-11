using System;
using System.Collections.Generic;
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
    public partial class PaymentTypeForm : Window
    {
        public PaymentTypeForm()
        {
            InitializeComponent();
        }

        private void BtnAddPaymentType_Click(object sender, RoutedEventArgs e)
        {
            var paymentTypeDescription = txtPaymentTypeDescription.Text;
            var paymentTypeLongDescription = txtPaymentTypeLongDescription.Text;
        }
    }
}