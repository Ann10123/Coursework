using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Kursach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddProductBox_Click(object sender, RoutedEventArgs e)
        {
            StackPanel row = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            TextBox productBox = new TextBox
            {
                Width = 200, Height = 25, FontSize = 15,
                Margin = new Thickness(25,10,52,5)
            };

            TextBox minBox = new TextBox
            {
                Width = 100, Height = 25, FontSize = 15,
                Margin = new Thickness(25, 10, 48, 5)
            };

            TextBox maxBox = new TextBox
            { 
                Width = 100, Height = 25, FontSize = 15,
                Margin = new Thickness(46, 10, 0, 5)
            };

            row.Children.Add(productBox);
            row.Children.Add(minBox);
            row.Children.Add(maxBox);

            ProductListPanel.Children.Add(row);
        }
    }
}

