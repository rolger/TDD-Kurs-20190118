using System;

namespace XUnitExercise
{
    public class StringCalculator
    {
        public decimal Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                throw new ArgumentException();

            string[] split = numbers.Split(',');
            decimal result;
            try
            {
                result = Decimal.Parse(split[0].Trim());
            }
            catch
            {
                throw new ArgumentException();
            }
            for (int i = 1; i < split.Length; i++)
            {
                decimal operand;
                try
                {
                    operand = Decimal.Parse(split[i].Trim());
                }
                catch
                {
                    throw new ArgumentException();
                }
                result = Decimal.Add(result, operand);
            }

            return result;
        }

        public decimal Subtract(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                throw new ArgumentException();

            string[] split = numbers.Split(',');
            decimal result;
            try
            {
                result = Decimal.Parse(split[0].Trim());
            }
            catch
            {
                throw new ArgumentException();
            }
            for (int i = 1; i < split.Length; i++)
            {
                decimal operand;
                try
                {
                    operand = Decimal.Parse(split[i].Trim());
                }
                catch
                {
                    throw new ArgumentException();
                }
                result = Decimal.Subtract(result, operand);
            }

            return result;
        }

        public decimal SubtractR(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                throw new ArgumentException();

            string[] split = numbers.Split(',');
            decimal result;
            try
            {
                result = Decimal.Parse(split[split.Length - 1].Trim());
            }
            catch
            {
                throw new ArgumentException();
            }
            for (int i = split.Length - 2; i > -1; i--)
            {
                decimal operand;
                try
                {
                    operand = Decimal.Parse(split[i].Trim());
                }
                catch
                {
                    throw new ArgumentException();
                }
                result = Decimal.Subtract(result, operand);
            }

            return result;
        }

        public decimal Multiply(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                throw new ArgumentException();

            string[] split = numbers.Split(',');
            decimal result;
            try
            {
                result = Decimal.Parse(split[0].Trim());
            }
            catch
            {
                throw new ArgumentException();
            }

            for (int i = 1; i < split.Length; i++)
            {
                decimal operand;
                try
                {
                    operand = Decimal.Parse(split[i].Trim());
                }
                catch
                {
                    throw new ArgumentException();
                }
                result = Decimal.Multiply(result, operand);
            }

            return result;
        }

        public decimal Divide(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                throw new ArgumentException();

            string[] split = numbers.Split(',');
            decimal result;
            try
            {
                result = Decimal.Parse(split[0].Trim());
            }
            catch
            {
                throw new ArgumentException();
            }
            for (int i = 1; i < split.Length; i++)
            {
                decimal operand;
                try
                {
                    operand = Decimal.Parse(split[i].Trim());
                    if (Decimal.Equals(operand, Decimal.Zero))
                    {
                        operand = Decimal.One;
                    }
                }
                catch
                {
                    throw new ArgumentException();
                }
                result = Decimal.Divide(result, operand);
            }

            return result;
        }

        public decimal DivideR(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                throw new ArgumentException();

            string[] split = numbers.Split(',');
            decimal result;
            try
            {
                result = Decimal.Parse(split[split.Length - 1].Trim());
            }
            catch
            {
                throw new ArgumentException();
            }

            for (int i = split.Length - 2; i > -1; i--)
            {
                decimal operand;
                try
                {
                    operand = Decimal.Parse(split[i].Trim());
                    if (Decimal.Equals(operand, Decimal.Zero))
                    {
                        operand = Decimal.One;
                    }
                }
                catch
                {
                    throw new ArgumentException();
                }
                result = Decimal.Divide(result, operand);
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
