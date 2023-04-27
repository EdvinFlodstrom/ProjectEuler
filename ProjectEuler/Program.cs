using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem_4();
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
                if (item > largestPalindromeNumber) largestPalindromeNumber = item; //Går igenom alla palindromtal som är sparade och sparar det största värdet.
            }
            Console.WriteLine("The largest palindrome made from the product of two 3-digit numbers is: "+ largestPalindromeNumber);
        }
        static string StringReversal(string text)
        {
            char[] textArray = text.ToCharArray();
            Array.Reverse(textArray);
            return new string(textArray);
        }
    }
}
