﻿using System.Windows;
using FinanceServices;

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

            IncomeViewModel incomeViewModel = new IncomeViewModel();

            cmbPaymentType.ItemsSource = incomeViewModel.GetPaymentTypes();
        }
    }
}