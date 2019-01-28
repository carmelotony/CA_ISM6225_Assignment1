using System;
using System.Linq;

namespace Assignment1_S19
{
    class Program
    {
        public static void Main()
        {
            int a = 5, b = 15;
            printPrimeNumbers(a, b);
            

            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);
            

            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);
            

            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);
            

            int n4 = 5;
            printTriangle(n4);
            

            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);
            Console.ReadKey(true);
            // write your self-reflection here as a comment
            /* The assignment was definitely challenging for me. While the first couple of methods I was able to
             * conceptualize an approach, the last few I had to research heavily. Researching conversions for the
             * binary problems led me to find out that I should review the built in system methods as there were
             * ways to acheive the goal without developing a more convoluted method.
            */
        }

        public static void printPrimeNumbers(int x, int y)
        {
            /*
             * x – starting range, integer (int)
             * y – ending range, integer (int)
             * 
             * summary: This method prints all the prime numbers between x and y
             * For example 5, 25 will print all the prime numbers between 5 and 25 i.e. 
             * 
             * 5, 7, 11, 13, 17, 19, 23
             * 
             * Tip: Write a method isPrime() to compute if a number is prime or not.
             * 
             * returns      : N/A
             * return type  : void
             */

            try
            {
                //instantiate a boleen variable to assign to numbers in range
                bool isPrime = true;

                //print string describing output of method
                Console.WriteLine("The prime numbers from " + x.ToString() + " to " + y.ToString() + " are: ");

                //create a for loop that checks each number against all other numbers within set starting at 2 
                //and changes the value of isPrime if modulo of numbers that are not equal to itself are zero
                for (int i = x; i <= y; i++)
                {
                    for (int j = 2; j <= y; j++)
                    {
                        if (i != j && i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        Console.WriteLine(" " + i);
                    }
                    isPrime = true;
                }
            }//End try
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }//End catch
        }//End Method PrintPrime
        public static double getSeriesResult(int n)
        {
            // Write your code here
            /*
             * para n – number of terms of the series, integer (int)
             * summary: This method computes the series 1/2 – 2!/3 + 3!/4 – 4!/5 --- n
             * where ! means factorial, i.e., 4! = 4*3*2*1 = 24. Round off the results to 
             * three decimal places. 
             * Hint: Odd terms are all positive whereas even terms are all negative.
             * Tip: Write a method to compute factorial of n, call it whenever required.
             * 
             * returns        : result
             * return type    : double
             */
            try
            {
                // interate through input and sum factorial imput numerator and +1 input as denominator
                // call factorial method to  

                int sum = 0;
                for (int i = 1; i <= n; i++)
                    if (n % 2 == 0)
                    {
                        sum +=  factorial(i)/(i+1);
                    }
                    else
                    {
                        sum -= factorial(i)/(i+1);
                    }
                return sum;

            }//End try
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return 0;
        }

        public static long decimalToBinary(long n)
        {
            /*
             * n - non-negative number to be converted to , integer (long)
             * 
             * summary: This method converts a number from decimal (base 10) to binary (base 2).
             * 
             * Implementation: A number can be converted from decimal to binary in the following
             * steps: 1) Divide it by 2 2) Get the integer quotient for next interation
             * 3)Get the remainder for binary digi. 4)Repeat the steps intil the quotient is equal to 0.
             * 
             * returns: integer
             * input type: long
             */

            try
            {
                // Use native conversion to convert long to binary string then parse to integer
                string binary = Convert.ToString(n,2);
                int return_bin = int.Parse(binary);

                return return_bin;

                

            }//End try
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }//End catch

            return 0;
        }

        public static long binaryToDecimal(long n)
        {
            try
            {
                //convert long  to string and then string to int using native methods
                string binary = Convert.ToString(n);
                int return_dec = Convert.ToInt32(binary, 2);

                return return_dec;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }

        public static void printTriangle(int n)
        {
            /*
             * n number of lines for the pattern, integer (int)
             * 
             * summary: This method prints a triangle using *
             * 
             * fro example n = 5 will display the output as:
             *   *
             *  ***
             * *****
             * etc
             * 
             * returns N/A
             * returnd type void
             */

            try
            {
                //Create a for loop that prints odd number of * for each itearation of input and 
                //prints it on a new line.

                string triang = "";
                for (int i = 0; i <= n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        triang += " ";
                    }
                    for (int k = 0; k < 2 * i - 1; k++)
                    {
                        triang += "*";
                    }
                    triang += Environment.NewLine;
                }
                Console.Write(triang);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static void computeFrequency(int[] a)
        {
            /*a array of elements, integer (int)
             * 
             * summary: This method computes the frequency of each element in the array
             * for example a = {1,2,3,2,2,1,3,2} will display the output as:
             * Number Frequency 
             * 1    2
             * 2    4
             * 3    2
             */

            try
            {
                //Use group by method from System.Linq to group by key and count frequency
                Console.WriteLine("Number Frequency");
                foreach (var grp in a.GroupBy(i => i))
                    {
                        Console.WriteLine("{0} : {1}", grp.Key, grp.Count());
                    }
                
            }//End try
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }//End of main
        private static int factorial(int n)
        {
            int numer = 1;
            for (int i = 2; i <= n; i++)
            {
                numer *= n;
            }
            return numer;
        }

    }
}

