﻿using System;
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

namespace Bolniza
{
    /// <summary>
    /// Логика взаимодействия для AdWindow.xaml
    /// </summary>
    public partial class AdWindow : Window
    {
        public Product CurrentProduct { get; set; }
        public IEnumerable<ProductType> _ProductType { get; set; }


        public AdWindow(Product bolnica)
        {
            InitializeComponent();
            DataContext = this;
            CurrentProduct = bolnica;
            _ProductType = Core.DB.ProductType.ToArray();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentProduct.ID == 0)
                    Core.DB.Product.Add(CurrentProduct);

                Core.DB.SaveChanges();

                DialogResult = true;

                MessageBox.Show($"Успешно!");
            }
            catch
            {
                MessageBox.Show($"Error" +
                    $"Проверьте введённые данные");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}