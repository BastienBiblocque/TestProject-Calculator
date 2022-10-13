using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProject_Calculator
{
    internal class Calculator
    {
        internal static int Add(string numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return 0;
            
            numbers = CleanString(numbers);
            String[] numbersInArray = numbers.Split(',');
            int total = 0;
            
            foreach (String number in numbersInArray)
                total = AddNumber(total, number);
            
            return total;
        }

        private static int AddNumber(int total, string stringNumber)
        {
            if (stringNumber.Length == 0)
                return total;
            
            int number = Convert.ToInt32(stringNumber); 
            
            if (number > 1000)
                return total;
            
            if (number < 0)
                throw new ArgumentException(string.Format("string contains [{0}], which does not meet rule. Entered number should not be negative.", number));
            
            return total + number;
        }
        private static String CleanString(String numbers)
        {
            numbers = Regex.Replace(numbers, "[^0-9,\\-]", ",");
            return numbers;
        }
    }
}
