using System;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal num1 = 0;
        decimal num2 = 0;
        string Operator = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Input(string a)
        {
            if (txtDisplay.Text == "0")
                txtDisplay.Text = a;
            else
                txtDisplay.Text += String.Format("{0:#,##0.##}", a); 
        }
        private void btn_Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn_Number = (Button)sender;
            Input(btn_Number.Content.ToString());
        }

        private void btn_Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btn_Operator = (Button)sender;
            Operator = btn_Operator.Content.ToString();
            num1 = decimal.Parse(txtDisplay.Text);
            //Input(Operator);
            txtDisplay.Text = "0";
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text != "")
            {
                if (!txtDisplay.Text.Contains("."))
                    Input(".");
            }
        }

        private void btnClr_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            Operator = "";
            num1 = 0;
            num2 = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text != "0")
            {
                if (txtDisplay.Text.Length == 1)
                {
                    txtDisplay.Text = "0";
                }
                else if (txtDisplay.Text.Length > 0)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                }
            }
        }
    }
}
