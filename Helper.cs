using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    public class Helper
    {
        public static string BasicMathematicsCalculations(decimal num1, decimal num2, string Operator)
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
