using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class NumberAlgorithms
    {
        public const double Pi = Math.PI;
        public const double E = Math.E;
        public const double Phi = 1.6180339887;

        public static int[] GetPositiveDividers(int num)
        {
            List<int> dividersList = new List<int>();
            dividersList.Add(1);
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    dividersList.Add(i);
                }
            }
            dividersList.Add(num);
            return dividersList.ToArray();
        }
        public static int GetAlliquotSum(int num)
        {
            int[] divisors = GetPositiveProperDividers(num);
            int sum = 0;
            foreach (int i in divisors)
            {
                sum += i;
            }
            return sum;
        }
        public static int[] GetPrimeFactorsUnique(int num)
        {
            HashSet<int> factorsList = new HashSet<int>();
            int divider = 2;
            while (num > 1)
            {
                if (num % divider == 0)
                {
                    num = num / divider;
                    factorsList.Add(divider);
                }
                else
                {
                    divider++;
                }
            }
            return factorsList.ToArray();
        }
        public static int[] GetPrimeFactorsAll(int num)
        {
            List<int> factorsList = new List<int>();
            int divider = 2;
            while (num > 1)
            {
                if (num % divider == 0)
                {
                    num = num / divider;
                    factorsList.Add(divider);
                }
                else
                {
                    divider++;
                }
            }
            return factorsList.ToArray();
        }
        public static int[] GetPositiveProperDividers(int num)
        {
            List<int> dividersList = new List<int>();
            dividersList.Add(1);
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    dividersList.Add(i);
                }
            }
            return dividersList.ToArray();
        }
        /* EBOB
         */
        public static int GreatestCommonFactor(int num1, int num2)
        {
            if (num1 == 0)
                return num2;
            return GreatestCommonFactor(num2 % num1, num1);
        }
        /* Greeks had 3 types of numbers.
         * Let S be the alluqiot sum of the number, and N be the number itself:
         * If:
         *  S < N => Deficient Number
         *  S = N => Perfect Number
         *  S > N => Abundant Number
         */
        public static string GetGreekType(int num1)
        {
            int sum = GetAlliquotSum(num1);
            if (sum > num1)
            {
                return "Abundant Number";
            }
            if (sum < num1)
            {
                return "Deficient Number";
            }
            return "Perfect Number";
        }
        /* EKOK
         */
        public static int LeastCommonMultiple(int num1, int num2)
        {
            return num1 * num2 / GreatestCommonFactor(num1, num2);
        }
        public static bool isPerfectSquare(int num)
        {
            double d; int i;
            d = Math.Sqrt(num);
            i = (int)Math.Sqrt(num);
            if (d == i)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool isPrime(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            if (n == 2)
            {
                return true;
            }
            if (n % 2 == 0)
            {
                return false;
            }
            for (int i = 3; i <= Math.Sqrt(n) + 1; i = i + 2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool areAmicableNumbers(int num1, int num2)
        {
            int sum1 = GetAlliquotSum(num1);
            int sum2 = GetAlliquotSum(num2);
            if ((sum1 == num2) && (sum2 == num1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool areFriendlyNumbers(int num1, int num2)
        {
            double sum1 = GetAlliquotSum(num1);
            double sum2 = GetAlliquotSum(num2);
            sum1 = sum1 / (double)num1;
            sum2 = sum2 / (double)num2;
            if (sum1 == sum2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /* Returns how many digits the number has
         */
        private static int getDigitCount(int num)
        {
            int count = 0;
            while (num > 0)
            {
                num = num / 10;
                count++;
            }
            return count;
        }
        /* Gets the specified digit of the number
         * If the specified digit is too big or less than 0 returns -1
         */
        public static int getDigit(int num, int digitNo)
        {
            if (digitNo <= 0 || digitNo > getDigitCount(num))
            {
                return -1;
            }
            else
            {
                int div10 = 1, mod10 = 1;
                for (int i = 0; i < digitNo; i++)
                {
                    mod10 *= 10;
                    div10 *= 10;
                }
                div10 /= 10;
                num = num % mod10;
                num = num / div10;
                return num;
            }
        }
        /* Flips a number vertically
         */
        public static int reverseNumber(int num)
        {
            int newnum = 0;
            for (int i = 1; i <= getDigitCount(num); i++)
            {
                newnum *= 10;
                newnum += getDigit(num, i);
            }
            return newnum;
        }
        /* Returns all digits of a number in an array
         */
        private static int[] getDigits(int num)
        {
            int[] digits = new int[getDigitCount(num)];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = getDigit(num, digits.Length - i);
            }
            return digits;
        }
    /* Kaprekar number is a number that when you divide the digits of the square of the number in a way
         * that adds up to the original number, that number is a Kaprekar number
         */
        public static bool isKaprekarNumber(int numorg)
        {
            int num = numorg * numorg;
            int[] digits = getDigits(num);
            int lefthandside = 0;
            int righthandside = num;
            int mod10 = (int)Math.Pow(10, digits.Length - 1);
            for (int i = 0; i < digits.Length - 1; i++)
            {
                lefthandside *= 10;
                lefthandside += digits[i];
                for (int j = i + 1; j < digits.Length; j++)
                {
                    righthandside = righthandside % mod10;
                    if (lefthandside + righthandside == numorg)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /* A harshad number is a number whose digits when summed up divide the number itself
         * e.g. 12 is a harshad number because:
         * 1 + 2 = 3, 12 % 3 = 0
         */
        public static bool isHarshadNumber(int num)
        {
            int[] digits = getDigits(num);
            int sum = 0;
            foreach (int i in digits)
            {
                sum += i;
            }
            if (num % sum == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int GetRandomNumber()
        {
            Random r = new Random();
            return r.Next();
        }
        public static int EulerTotient(int n)
        {
            int result = 1;
            for (int i=2; i < n; i++)
                if (GreatestCommonFactor(i, n) == 1)
                    result++;
            return result;
        }
    }
}
