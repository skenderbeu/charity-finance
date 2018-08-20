using FinanceServices;
using System.Windows;

namespace FinanceDesktopView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IEditIncomeViewModel incomeViewModel = new EditIncomeViewModel();

            cmbPaymentType.ItemsSource = incomeViewModel.GetPaymentTypes();
        }
    }
}