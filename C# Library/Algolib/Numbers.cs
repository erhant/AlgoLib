using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Most of the algorithms were written by hand by Erhan Tezcan. 
/// Help was taken from geeksforgeeks.com and "Teoriden Uygulamalara algoritmalar", Prof. Dr. Vasif NABIYEV, 5. Baski, Seckin Yayinevi
/// </summary>
namespace Algolib
{
    public class Numbers
    {
        public class Constants
        {
            public const double Pi = Math.PI;
            public const double E = Math.E;
            public const double Phi = 1.6180339887;
        }

        public class Algorithms
        {
            /// <summary>
            /// Karatsuba Multiplication taken from the book
            /// This multiplication is used for multiplicating two very big numbers.
            /// Say each number is n digits, if we were to multiply normally it would be O(n^2),
            /// but using Karatsuba the complexity is lesser. O(n^(log(3)))
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <param name="Base"></param>
            /// <param name="m"></param>
            /// <returns></returns>
            public static int KaratsubaMultiplication(int num1, int num2, int Base, int m)
            {
                int res;
                int z1, z2, z3, n1_1, n1_0, n2_1, n2_0;
                // Make sure B^m is less than both numbers.
                while (Math.Pow(Base, m) > num1 && Math.Pow(Base, m) > num2)
                {
                    if (m > 1)
                    {
                        m--;
                    }
                    else
                    {
                        Base--;
                    }
                }
                // Find how many numbers of the given base is i the number
                n1_1 = (int)Math.Floor(num1 / Math.Pow(Base, m));
                n2_1 = (int)Math.Floor(num2 / Math.Pow(Base, m));
                n1_0 = num1 - n1_1 * (int)Math.Pow(Base, m);
                n2_0 = num2 - n2_1 * (int)Math.Pow(Base, m);
                // Calculate parameters
                z3 = n1_1 * n2_1;
                z1 = n1_0 * n2_0;
                z2 = (n1_1 + n1_0) * (n2_1 + n2_0) - (z1 + z3);
                // Final Calculation
                res = z3 * (int)Math.Pow(Base, 2 * m) + z2 * (int)Math.Pow(Base, m) + z1;
                return res;
            }

            /// <summary>
            /// This addition function is special, such that it does not use any of the arithmethic operators like +, -, ++, --, etc.
            /// How it works is, sum of 1 and 1 is considered carry and is stored elsewhere, while normal addition of 1 and 0 is stored in x.
            /// Iterations end when carry is 0, then x is the result of our addition.
            /// </summary>
            /// <returns></returns>
            public static int AddWithoutArithmethics(int x, int y)
            {
                // Iterate till there is no carry
                while (y != 0)
                {
                    // Carry now contains common set bits of x and y
                    int carry = x & y;

                    // Sum of bits of x and y where at least one of the bits is 0
                    x = x ^ y;

                    // Carry is shifted by one so that adding it to x gives the required sum
                    y = carry << 1;
                }
                return x;
            }

            /// <summary>
            /// This algorithm is to multiply 2 very very big numbers that dont fit in "long long int", represented in strings.
            /// The result is also represented as a string.
            /// 
            /// Time Complexity : O(m*n) where m and n are number of digits of each number.
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            public static string MultiplyLarge(string num1, string num2)
            {
                int n1 = num1.Length;
                int n2 = num2.Length;
                if (n1 == 0 || n2 == 0)
                {
                    return "0";
                }

                // Result will be kept in reverse order
                int[] result = new int[n1 + n2]; // this is where we will hold minor calculation results

                // Indexes to find position in result array
                int i_n1 = 0;
                int i_n2 = 0;

                // go from right to left in num1
                for (int i = n1 - 1; i >= 0; i--)
                {
                    int carry = 0;
                    int n_n1 = num1[i] - '0'; // current digit in num1

                    i_n2 = 0;
                    // go from right to left in num2
                    for (int j = n2 - 1; j >= 0; j--)
                    {
                        int n_n2 = num2[j] - '0'; // current digit in num2
                        int sum = n_n1 * n_n2 + result[i_n1 + i_n2] + carry; // multiplication
                        carry = sum / 10; // carry for the next iteration
                        result[i_n1 + i_n2] = sum % 10; // store result
                        i_n2++;

                    }
                    // if carry, store it in next cell
                    if (carry > 0)
                    {
                        result[i_n1 + i_n2] += carry;
                    }

                    i_n1++;
                }

                // ignore 0's from the right
                int r_i = result.Length - 1;
                while (r_i >= 0 && result[r_i] == 0)
                {
                    r_i--;
                }
                // if one of the numbers or maybe both of them were all 0's this condition will be true
                if (r_i == -1)
                {
                    return "0";
                }
                // generating the result string
                for (int i = 0; i < (result.Length + 1) / 2; i++)
                {
                    int tmp = result[result.Length - 1 - i];
                    result[result.Length - 1 - i] = result[i];
                    result[i] = tmp;
                }
                string s = String.Join("", result);
                int s_i = 0;
                while (s[s_i] == '0')
                {
                    s_i++;
                }
                return s.Substring(s_i);
            }

            /// <summary>
            /// Multiply a number with 3.5 using shift operations.
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static int MultiplyWith3Point5(int num)
            {
                return (num << 1) + num + (num >> 1);
            }

            /// <summary>
            /// Multiply a number with 7 using shift operations.
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static int MultiplyWith7(int num)
            {
                return ((num << 3) - num); // 8n - n = 7n
            }

            /// <summary>
            /// Multiply a number with 10 using shift operations.
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static int MultiplyWith10(int num)
            {
                return (num << 3 + num << 2); // 8n + 2n = 10n
            }

            /// <summary>
            /// Returns the smallest of 3 parameters without using a comparison between them.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="z"></param>
            /// <returns></returns>
            public static int SmallestOf3NonNegative(int x, int y, int z)
            {
                int c = 0;
                while (x != 0 && y != 0 && z != 0)
                {
                    x--; y--; z--; c++;
                }
                return c;
            }

            /// <summary>
            /// This function adds 2 very large numbers represented as strings and returns the result as a string.
            /// 
            /// Time Complexity : O(n+m) where n and m are the total number of digits
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            public static string AddLarge(string num1, string num2)
            {
                int n1 = num1.Length;
                int n2 = num2.Length;
                int[] result = new int[Math.Max(n1, n2) + 1];
                byte carry = 0;
                int sum = 0, num1dig, num2dig;
                int i = n1 - 1, j = n2 - 1, k = result.Length - 1;
                // iterate for both numbers
                while (i >= 0 && j >= 0)
                {
                    num1dig = num1[i--] - '0';
                    num2dig = num2[j--] - '0';
                    sum = num1dig + num2dig + carry;
                    if (sum >= 10)
                    {
                        sum = sum % 10;
                        carry = 1;
                    }
                    result[k--] = sum;
                }
                if (n1 == n2)
                {
                    result[k--] = carry;
                }
                else
                {
                    // iterate for the rest of num1
                    while (i >= 0)
                    {
                        sum = num1[i--] - '0' + carry;
                        if (sum >= 10)
                        {
                            result[k--] = sum % 10;
                            carry = 1;
                        }
                        else
                        {
                            result[k--] = sum;
                            carry = 0;
                        }
                    }
                    // iterate for the rest of num2
                    while (j >= 0)
                    {
                        sum = num2[j--] - '0' + carry;
                        if (sum >= 10)
                        {
                            result[k--] = sum % 10;
                            carry = 1;
                        }
                        else
                        {
                            result[k--] = sum;
                            carry = 0;
                        }
                    }
                }
                // generating the result string
                string s = String.Join("", result);
                if (s.Substring(0, 1) == "0")
                {
                    return s.Substring(1);
                }
                return s;
            }
            
            /// <summary>
            /// The number of numbers up to N that are relatively prime to N. 
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public static int EulerTotient(int n)
            {
                int result = 1;
                for (int i = 2; i < n; i++)
                    if (GreatestCommonFactor(i, n) == 1)
                        result++;
                return result;
            }

            /// <summary>
            /// Returns an array of all positive dividers of this number.
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
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

            /// <summary>
            /// Returns an array of all positive dividers of this number excluding the number itself.
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
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

            /// <summary>
            /// Alliquot Sum is the sum of all proper divisors.
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
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

            /// <summary>
            /// Returns an array of all prime numbers that make up this number, without recurrences
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
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

            /// <summary>
            /// Returns an array of all prime numbers that make up this number, allowing recurrences
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
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

            /// <summary>
            /// Returns prime numbers less than N using Sieve of Eratosthenes.
            /// 
            /// O(nlog(log(n)))
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static int[] GetPrimesUpToNEratosthenes(int num)
            {
                // Initialization
                int[] arr = new int[num + 1];
                int i, j, k;
                List<int> primes = new List<int>();
                for (i = 1; i <= num; i++)
                {
                    arr[i] = i; // +1 because numbers range from 1 to N
                }
                k = (int)Math.Sqrt(num);
                i = 2;
                // Start the algorithm
                while (arr[i] <= k)
                {
                    if (arr[i] != 0)
                    {
                        for (j = i * i; j <= num; j += i)
                        {
                            arr[j] = 0;
                        }
                    }
                    i++;
                }
                // Sieve is done, get non-zero values (which are the primes we want)
                for (i = 2; i <= num; i++)
                {
                    if (arr[i] != 0)
                    {
                        primes.Add(arr[i]);
                    }
                }
                return primes.ToArray();
            }

            /// <summary>
            /// Also known as EBOB in Turkish
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            public static int GreatestCommonFactor(int num1, int num2)
            {
                if (num1 == 0)
                    return num2;
                return GreatestCommonFactor(num2 % num1, num1);
            }

            /// <summary>
            /// Also known as EKOK in Turkish
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            public static int LeastCommonMultiple(int num1, int num2)
            {
                return num1 * num2 / GreatestCommonFactor(num1, num2);
            }

            /// <summary>
            /// Greeks had 3 types of numbers.
            /// Let S be the alluqiot sum of a number N.
            /// If:
            /// S is less than N : Deficient Number
            /// S equals N : Perfect Number
            /// S is greater than N : Abundant Number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static string GetGreekType(int num)
            {
                int sum = GetAlliquotSum(num);
                if (sum > num)
                {
                    return "Abundant Number";
                }
                if (sum < num)
                {
                    return "Deficient Number";
                }
                return "Perfect Number";
            }

            /// <summary>
            /// Returns the number of digits in a number.
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static int GetDigitCount(int num)
            {
                int count = 0;
                while (num > 0)
                {
                    num = num / 10;
                    count++;
                }
                return count;
            }

            /// <summary>
            /// Gets the specified digit of the number.
            /// If the specified digit is too big or less than 0 it returns -1.
            /// </summary>
            /// <param name="num"></param>
            /// <param name="digitNo"></param>
            /// <returns></returns>
            public static int GetDigit(int num, int digitNo)
            {
                // get digit count
                int digitCount = 0;
                int tmpnum = num;
                while (tmpnum > 0)
                {
                    tmpnum = tmpnum / 10;
                    digitCount++;
                }

                if (digitNo <= 0 || digitNo > digitCount)
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

            /// <summary>
            /// Flips a number vertically
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static int ReverseNumber(int num)
            {
                // find digit count
                int digitcount = 0;
                int tmpnum = num;
                while (tmpnum > 0)
                {
                    tmpnum /= 10;
                    digitcount++;
                }
                int newnum = 0;
                // for every digit:
                for (int i = 1; i <= digitcount; i++)
                {
                    newnum *= 10;
                    tmpnum = num;
                    // write get digit here
                    int digit = 1; //-<<<<<< digit = GetDigit(num,i)

                    newnum += digit;
                }
                return newnum;
            }

            /// <summary>
            /// Returns all digits of a number in an array
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static int[] GetDigits(int num)
            {
                int[] digits = new int[GetDigitCount(num)];
                for (int i = 0; i < digits.Length; i++)
                {
                    digits[i] = GetDigit(num, digits.Length - i);
                }
                return digits;
            }

            /// <summary>
            /// Returns a boolean value indicating if the number is boolean or not.
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPerfectSquare(int num)
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

            /// <summary>
            /// Returns a boolean value indicating if the number is boolean or not.
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public static bool IsPrime(int n)
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

            /// <summary>
            /// Author: Erhan Tezcan
            /// Kaprekar number is a number that when you divide the digits of the square of the number in a way
            /// that adds up to the original number, that number is a Kaprekar number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsKaprekarNumber(int num)
            {
                int numsqr = num * num;
                int[] digits = GetDigits(numsqr);
                int lefthandside = 0;
                int righthandside = numsqr;
                int mod10 = (int)Math.Pow(10, digits.Length - 1);
                for (int i = 0; i < digits.Length - 1; i++)
                {
                    lefthandside *= 10;
                    lefthandside += digits[i];
                    for (int j = i + 1; j < digits.Length; j++)
                    {
                        righthandside = righthandside % mod10;
                        if (lefthandside + righthandside == num)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            /// <summary>
            /// Author: Erhan Tezcan
            /// A harshad number is a number whose digits when summed up divide the number itself.
            /// <example>
            /// 12 is a harshad number because:
            /// 1 + 2 = 3, 12 % 3 = 0
            /// </example>
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsHarshadNumber(int num)
            {
                int[] digits = GetDigits(num);
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

            /// <summary>
            /// Author: Erhan Tezcan
            /// An evil number is a non-negative number that has an even number of 1s in its binary expression. (Opposite of Odious)
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsEvilNumber(uint num)
            {
                // TRUE = 1, FALSE = 0
                bool even = num % 2 == 0;
                while (num > 0)
                {
                    even = (num = num >> 1) % 2==1 ^ even;
                }
                return even;
            }

            /// <summary>
            /// Author: Erhan Tezcan
            /// An odious number is a non-negative number that has an odd number of 1s in its binary expression. (Opposite of Evil)
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsOdiousNumber(uint num)
            {
                // TRUE = 1, FALSE = 0
                bool even = num % 2 == 0;
                while (num > 0)
                {
                    even = (num = num >> 1) % 2 == 1 ^ even;
                }
                return !even; // if its not even its odd.
            }

            /// <summary>
            /// A number is called Ugly if its prime factors only consist of 2s, 3s or 5s. Number 1 is also included.
            /// <example>
            /// 1, 2, 3, 5, 6, 8, 9, 10, 12, 15, ...
            /// </example>
            /// </summary> 
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsUglyNumber(int num)
            {
                while (num % 2 == 0)
                {
                    num /= 2;
                }
                while (num % 3 == 0)
                {
                    num /= 3;
                }
                while (num % 5 == 0)
                {
                    num /= 5;
                }
                return (num == 1) ? true : false;
            }
            
            /// <summary>
            /// Given two numbers, if a numbers Alliquot Sum is equal to the other number itself and vice versa, they are Amicable Numbers.
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            public static bool AreAmicableNumbers(int num1, int num2)
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

            /// <summary>
            /// If the Alliquot Sum divided by the number itself is same for 2 numbers, it means they are friendly.
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            public static bool AreFriendlyNumbers(int num1, int num2)
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

            /// <summary>
            /// Two integers are relatively prime if they share no common positive factors except 1. So their GCD is 1.
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            public static bool AreRelativelyPrime(int num1, int num2)
            {
                return (GreatestCommonFactor(num1, num2) == 1) ? true : false;
            }
            
        }

        public class Puzzles
        {
            /// <summary>
            /// A number is called Ugly if its prime factors only consist of 2s, 3s or 5s. Number 1 is also included.
            /// This algorithms finds the Nth ugly number using an iterative approach, checking if the number is ugly or not everytime.
            /// Has a bad complexity since it does the checking operation for each number.
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public static int NthUglyNumberNaive(int n)
            {
                int count = 1;
                int tmp = 1;
                while (count <= n)
                {
                    if (Algorithms.IsUglyNumber(tmp))
                    {
                        count++;
                    }
                    tmp++;
                }
                return tmp-1;
            }

            /// <summary>
            /// A number is called Ugly if its prime factors only consist of 2s, 3s or 5s. Number 1 is also included.
            /// Dynamic Programming approach solves this problem by generating ugly numbers, rather than checking if a number is ugly or not.
            /// Finally, it returns the Nth generated number, because we are looking for the Nth ugly number.
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public static int NthUglyNumberDynamicProgramming(int n)
            {
                int[] ugly = new int[n]; ugly[0] = 1;
                int i2, i3, i5; i2 = i3 = i5 = 0;
                int m2, m3, m5; m2 = 2; m3 = 3; m5 = 5;
                int nextUgly=1;
                for (int i = 1; i < n; i++)
                {
                    nextUgly = Math.Min(Math.Min(m3, m5), m2);
                    ugly[i] = nextUgly;
                    // Be careful with these "if" conditions, they might not have to be if-else everytime!
                    if (nextUgly==m2)
                    {
                        m2 = ugly[++i2] * 2;
                    }
                    if(nextUgly==m3)
                    {
                        m3 = ugly[++i3] * 3;
                    }
                    if (nextUgly == m5)
                    {
                        m5 = ugly[++i5] * 5;
                    }                    
                }
                return nextUgly;
            }
        }
    }
}
