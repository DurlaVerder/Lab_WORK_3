using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NCalc;

namespace Wpf_Lab2_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            unvisible.IsChecked = true;

        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            res_txt.Text += button.Content.ToString();
        }

        private void b_Click_equals(object sender, RoutedEventArgs e)
        {

            NCalc.Expression expression = new NCalc.Expression(res_txt.Text);

            res_txt.Text = Math.Round(Convert.ToDouble(expression.Evaluate()),8).ToString();

            if (check_save.IsChecked == true) save_result.Text += " " + res_txt.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            save_result.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] words = save_result.Text.Split(' ');
            if (words.Length > 0)
            {

                Array.Resize(ref words, words.Length - 1);


                save_result.Text = string.Join(" ", words);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (visible.IsChecked == true)
            {
                save_result.Visibility = Visibility.Visible;
                check_save.Visibility = Visibility.Visible;
                backspace.Visibility = Visibility.Visible;
                clear.Visibility = Visibility.Visible;
            }
        }

        private void Unvisible_Checked(object sender, RoutedEventArgs e)
        {
            if (unvisible.IsChecked == true)
            {
                save_result.Visibility = Visibility.Hidden;
                check_save.Visibility = Visibility.Hidden;
                backspace.Visibility = Visibility.Hidden;
                clear.Visibility = Visibility.Hidden;
            }
        }
    }
}
