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
            if (txtDisplay.Text == "0" && lblDisplay.Content.ToString() == "")
            {
                txtDisplay.Text = a;               
                lblDisplay.Content = a;
            }
            else if(txtDisplay.Text == "0")
            {
                txtDisplay.Text = a;
                lblDisplay.Content += a;
            }
            else
            {
                txtDisplay.Text += String.Format("{0:#,##0.##}", a);
                lblDisplay.Content += String.Format("{0:#,##0.##}", a);
            }
               
        }
        private void btn_Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn_Number = (Button)sender;
            Input(btn_Number.Content.ToString());
        }

        private void btn_Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btn_Operator = (Button)sender;
            if(Operator == "")
            {
                Operator = btn_Operator.Content.ToString();
                if(num1 == 0)
                    num1 = decimal.Parse(txtDisplay.Text);                
                lblDisplay.Content += Operator;
                txtDisplay.Text = "0";
            }
            else
            {
                
                try
                {
                    num1 = decimal.Parse(BasicMathematicsCalculations(num1, decimal.Parse(txtDisplay.Text)));
                }
                catch (Exception exc)
                {
                    txtDisplay.Text = "Error!:" + exc;
                }

                Operator = btn_Operator.Content.ToString();                
                lblDisplay.Content += Operator;
                txtDisplay.Text = "0";
            }
            
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
            lblDisplay.Content = "";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text != "0")
            {
                if (txtDisplay.Text.Length == 1)
                {
                    txtDisplay.Text = "0";
                    lblDisplay.Content = txtDisplay.Text;
                }
                else if (txtDisplay.Text.Length > 0)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                    lblDisplay.Content = txtDisplay.Text;
                }
            }
        }

        private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text != "0")
            {
                if (!txtDisplay.Text.Contains("-"))
                    txtDisplay.Text = "-" + txtDisplay.Text;
            }
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            num2 = decimal.Parse(txtDisplay.Text);
            //////////////////////////////// 
            try
            {
                lblDisplay.Content = BasicMathematicsCalculations(num1, num2);
            }
            catch (Exception exc)
            {
                txtDisplay.Text = "Error!:" + exc;
            }
             txtDisplay.Text = "0";
             Operator = "";
             num1 = decimal.Parse(lblDisplay.Content.ToString());
             num2 = 0;


        }

        public string BasicMathematicsCalculations (decimal num1, decimal num2)
        {
            string result = "";
            switch (Operator)
            {
                case "+":
                    result = (num1 + num2).ToString();
                    break;
                case "-":
                    result = (num1 - num2).ToString();
                    break;
                case "*":
                    result = (num1 * num2).ToString();
                    break;
                case "/":
                    result = (num1 / num2).ToString();
                    break;
                case "Mod":
                    result = (num1 % num2).ToString();
                    break;
            }
            return result;
        }

        
    }
}
