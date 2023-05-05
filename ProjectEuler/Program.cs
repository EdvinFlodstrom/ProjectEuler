using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem_50();
        }
        static void Problem_1()
        {
            int num_1MultipleNumber = 3;
            int num_2MultipleNumber = 5;
            int targetMaxNumber = 1000;

            List<int> multiplesList = new List<int>();

            int totalSum = 0;

            for (int num_1 = 3; num_1 < targetMaxNumber; num_1 += num_1MultipleNumber)
            {
                multiplesList.Add(num_1);
            }
            for (int num_2 = 5; num_2 < targetMaxNumber; num_2 += num_2MultipleNumber)
            {
                if (!multiplesList.Contains(num_2)) multiplesList.Add(num_2);
            }
            foreach (int item in multiplesList)
            {                
                totalSum = totalSum + item;
            }
            Console.WriteLine("The total sum of all the multiples of 3 or 5 below 1000 is: " + totalSum);
        }
        static void Problem_2()
        {
            int num_1 = 1;
            int num_2 = 0;
            int num_3 = 0;
            int targetMaxNum = 4000000;
            int totalSum = 0;

            List<int> fibonacciSequenceNumList = new List<int>();

            for (num_1 = 1; num_1 < targetMaxNum;)
            {
                fibonacciSequenceNumList.Add(num_1);
                num_2 = num_1;
                num_1 = num_2 + num_3;
                num_3 = num_2;
            }
            foreach (int item in fibonacciSequenceNumList)
            {
                if (item % 2 == 0)
                {
                    totalSum = totalSum + item;
                }
            }
            Console.WriteLine("The total sum of the even-valued terms in the Fibonacci sequence below 4 million is: " + totalSum);
        }
        static void Problem_4()
        {
            List<int> palindromeNumbersList = new List<int>();

            int num_1;
            int num_2 = 100;
            int maxNum = 999;
            int palindromeNumber;
            int palindromeNumberReversed;
            int largestPalindromeNumber = 0;

            for (num_1 = 100; num_2 < maxNum; num_1++)
            {
                palindromeNumber = num_1 * num_2; //Tar produkten av tal 1 och 2
                palindromeNumberReversed = int.Parse(StringReversal(palindromeNumber.ToString())); //Tar produkten ovan och vänder på den
                if (palindromeNumber == palindromeNumberReversed) palindromeNumbersList.Add(palindromeNumber); //Kollar om de två variablerna är likadana. Om de är det så är talet ett palindrom.
                if (num_1 == 999)
                {                    
                    num_2++;
                    num_1 = num_2; //Sparar lite på uträkningarna. Till exempel räknas inte 100 * 105 ut flera gånger.
                }                
            }
            foreach (int item in palindromeNumbersList)
            {
                if (item > largestPalindromeNumber) largestPalindromeNumber = item; //Går igenom alla sparade palindromtal som är sparade och sparar det största värdet.
            }
            Console.WriteLine("The largest palindrome made from the product of two 3-digit numbers is: "+ largestPalindromeNumber);
        }
        static string StringReversal(string text)
        {
            char[] textArray = text.ToCharArray();
            Array.Reverse(textArray);
            return new string(textArray);
        }
        static void Problem_5()
        {
            bool loop = true;
            int tal;
            for (tal = 1; loop; tal++)
            {
                for (int division = 1; division < 21; division++)
                {
                    if (tal % division != 0) break; //Om resten inte är 0 så avbryts for-loopen.
                    else
                    {
                        if (division == 20) loop = false; //Om talet har kunnat divideras utan rest med alla tal mellan 1-20, ska loopen avbrytas.
                    }
                }
            }
            tal--;
            Console.WriteLine("The smallest positive number that is evenly divisible by all of the numbers from 1 to 20 is: " + tal);
        }
        static void Problem_50()
        {            
            List<int> primeList = new List<int>();
            List<int> primeSumList = new List<int>();
            List<int> largestPrimeSumList = new List<int>();
            primeList.Add(2);
            bool loop = true;
            bool loopIndex = true;
            bool indexPrimeLoop = false;
            int largestPrime = 0;
            int targetNum = 1000;

            //Primtalen måste inte börja med 2. Kan börja med 5, 13 osv. De måste följa varandra, men inte från 2.
            //Hitta största primtalet! Inte talet med flest primtal i rad.
            for (int num = 1; loop; num++)
            {
                if (PrimeChecker(num))
                {
                    primeList.Add(num);
                    int sumOfPrimes = 0;
                    foreach (int item in primeList)
                    {
                        sumOfPrimes = sumOfPrimes + item;
                    }
                    if (sumOfPrimes < targetNum)
                    {                        
                        Console.WriteLine("Prime number: " + num + ", sum: " + sumOfPrimes);
                        primeSumList.Add(sumOfPrimes);
                    }
                    else indexPrimeLoop = true;
                    if (indexPrimeLoop)
                    {
                        for (int indexOfPrime = 0; indexOfPrime < primeList.Last(); indexOfPrime++)
                        {
                            loopIndex = true;
                            sumOfPrimes = 0;
                            indexOfPrime++;
                            for (int index = indexOfPrime; loopIndex; index++)
                            {
                                if (index < primeList.Last()) sumOfPrimes = sumOfPrimes + primeList[index];
                                Console.WriteLine("Sum of primes: " + sumOfPrimes);
                                if (sumOfPrimes < targetNum)
                                {
                                    if (primeSumList.Contains(sumOfPrimes) == false) primeSumList.Add(sumOfPrimes);
                                }
                                else loopIndex = false;
                            }                            
                        }
                        loop = false;
                    }                    
                }
            }
            foreach (int item in primeSumList)
            {
                if (item > largestPrime)
                {
                    if (PrimeChecker(item)) largestPrime = item;
                }
            }
            Console.WriteLine("The largest prime which is a sum of previous primes below one million is: " + largestPrime);
        }
        static bool PrimeChecker(int num)
        {
            int sqrtNum = (int)Math.Round(Math.Sqrt(num));
            bool prime = false;

            for (int division = 2; division < sqrtNum + 1; division++)
            {
                if (num % division == 0) break;
                if (division == sqrtNum) prime = true;                    
            }
            return prime;
        }
    }
}
