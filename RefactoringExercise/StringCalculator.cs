using System;
using System.Collections.Generic;

namespace RefactoringExercise
{
    public class StringCalculator
    {
        public decimal Add(string inputData)
        {
            ValidateInput(inputData);

            return ExecuteOperation(ParseNumbers(inputData), Decimal.Add);
        }
        
        public decimal Subtract(string inputData)
        {
            ValidateInput(inputData);

            return ExecuteOperation(ParseNumbers(inputData), Decimal.Subtract);
        }

        public decimal Multiply(string inputData)
        {
            ValidateInput(inputData);

            return ExecuteOperation(ParseNumbers(inputData), Decimal.Multiply);
        }

        public decimal Divide(string inputData)
        {
            ValidateInput(inputData);

            return ExecuteOperation(ParseNumbers(inputData), Decimal.Divide);
        }

        public decimal SubtractR(string inputData)
        {
            ValidateInput(inputData);

            var numbers = ParseNumbers(inputData);
            numbers.Reverse();

            return ExecuteOperation(numbers, Decimal.Subtract);
        }

        public decimal DivideR(string inputData)
        {
            ValidateInput(inputData);

            var numbers = ParseNumbers(inputData);
            numbers.Reverse();

            return ExecuteOperation(numbers, Decimal.Divide);
        }

        private void ValidateInput(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                throw new ArgumentException();
        }

        private List<decimal> ParseNumbers(string numbers)
        {
            string[] split = numbers.Split(',');
            var parsedNumbers = new List<decimal>();
            foreach (var operand in split)
            {
                parsedNumbers.Add(ParseNumber(operand));
            }

            return parsedNumbers;
        }

        private decimal ParseNumber(string numberToParse)
        {
            decimal result;
            try
            {
                result = Decimal.Parse(numberToParse.Trim());
            }
            catch
            {
                throw new ArgumentException();
            }

            return result;
        }

        private decimal ExecuteOperation(List<decimal> numbers,
            Func<decimal, decimal, decimal> operation)
        {
            decimal result = numbers[0];
            numbers.RemoveAt(0);

            foreach (var operand in numbers)
            {
                result = operation.Invoke(result, operand);
            }

            return result;
        }


        public string[] GetNumbers(string numbers)
        {
            var nums = numbers.Split(' ');
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i].Trim();
            }
            return nums;
        }

        public void PrintNumbers(string op, string numbers)
        {
            var numArray = GetNumbers(numbers);

            string formated = AddBrackets(op, numArray);
            Console.WriteLine(formated);
        }

        private string AddBrackets(string op, string[] numArray)
        {
            if (numArray.Length == 0)
            {
                return "";
            }
            else if (numArray.Length == 1)
            {
                return numArray[0];
            }
            else
            {
                var last = numArray[numArray.Length - 1];
                Array.Resize(ref numArray, numArray.Length - 1);
                return "(" + AddBrackets(op, numArray) + " " + op + " " + last + ")";
            }
        }
    }
}
