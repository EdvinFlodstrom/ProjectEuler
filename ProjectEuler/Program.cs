﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem_54();
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
            int indexOfLastElement = 1;
            int targetNum = 1000000;

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
                        primeSumList.Add(sumOfPrimes);
                    }
                    else indexPrimeLoop = true;
                    if (indexPrimeLoop)
                    {
                        indexOfLastElement = primeList.IndexOf(primeList.Last());
                        for (int indexOfPrime = 0; indexOfPrime < indexOfLastElement; indexOfPrime++)
                        {
                            loopIndex = true;
                            sumOfPrimes = 0;
                            for (int index = indexOfPrime; loopIndex; index++)
                            {
                                if (index < indexOfLastElement) sumOfPrimes = sumOfPrimes + primeList[index];
                                else loopIndex = false;
                                if (sumOfPrimes < targetNum)
                                {
                                    if (primeSumList.Contains(sumOfPrimes) == false) primeSumList.Add(sumOfPrimes);
                                }                                
                            }
                        }
                        loop = false;
                    }
                }
                /*
                 * 2, 3, 5, 7, 11
                 * sum (2-11)
                 * sum (3 - 11)
                 * for (startIndex = 0; startIndex <= lastIndex; ++startIndex)
                 * 
                 * int sum = 0
                 * 
                 * for (index = startIndex; index >= lastIndex; ++index)
                 * {
                 *      if (sum + lista[index] > 1000) break
                 *      sum += lista[index]
                 *      }
                 *   
                 *  spara sum
                 *  
                 */


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
        static void Problem_54()
        {
            string docPath =
  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathAndFileName = Path.Combine(docPath, "p054_poker.txt");

            //C = Clubs; D = Diamond; H = Hearts; S = Spades
            List<string> player1Hand = new List<string>();
            List<string> player2Hand = new List<string>();
            int player1HandStrength = 0;
            int player2HandStrength = 0;

            int player1Wins = 0;
            int player2Wins = 0;

            using (var sr = new StreamReader(pathAndFileName))
            {
                string row = "placeHolder";
                while (row != null)
                {                    
                    row = sr.ReadLine();                                        
                    if (row != null)
                    {
                        String[] cards = row.Split(' '); //Tar första raden och sparar varje element i en array separerat vid mellanslag
                        for (int i = 0; i < cards.Length; ++i)
                        {
                            if (i < 5)
                            {
                                player1Hand.Add(cards[i]); //Spelare 1 för första fem korten.
                            }
                            else
                            {
                                player2Hand.Add(cards[i]); //Spelare 2 för resten av korten, alltså de sista fem.
                            }
                        }

                        
                        player1Hand.Clear();
                        player1Hand.Add("3D");
                        player1Hand.Add("2D");
                        player1Hand.Add("5D");
                        player1Hand.Add("1D");
                        player1Hand.Add("4D");
                        


                        player1HandStrength = HandStrength(player1Hand); //Beräknar styrkan av spelarnas kort, i en int.
                        //player2HandStrength = HandStrength(player2Hand);
                        if (player1HandStrength > 10) //Hela denna if-sats är endast till för debugging.
                        {
                            Console.WriteLine("p1 strength " + player1HandStrength);
                            foreach (string item in player1Hand)
                            {
                                Console.WriteLine(item);
                            }                            
                        }
                        break; //Avbryter programmet efter en körning. *ENDAST FÖR DEBUGGING*
                        if (WinningHand(player1HandStrength, player2HandStrength) == 1)
                        {
                            player1Wins++; //Avgör vilken av spelarna som hade bäst hand, och ökar vinnarens antal vinster med 1.
                        }
                        else
                        {
                            player2Wins++;
                        }
                        player1Hand.Clear();
                        player2Hand.Clear();
                    }
                }
            }
        }
        static int HandStrength(List<string> hand)
        {
            bool royalFlush = false;
            int strength = 0;
            bool sameSuit = true;
            List<char> cardRanks = new List<char>();            
            cardRanks.Add('T');
            cardRanks.Add('J');
            cardRanks.Add('Q');
            cardRanks.Add('K');
            cardRanks.Add('A');

            string firstChard = hand[0];
            char suit = firstChard[1];
            foreach (string item in hand) //Kollar ifall alla kort tillhör samma färg.
            {                
                if (item[1] != suit)
                {
                    sameSuit = false;
                }
            }

            if (sameSuit) //Är spelarens alla kort i samma färg?
            {                
                foreach (string item in hand) //Kollar ifall spelaren har en royal flush.
                {                   
                    if (cardRanks.Contains(item[0]))
                    {
                        cardRanks.Remove(item[0]);
                        royalFlush = true;
                    }
                    else
                    {
                        royalFlush = false;
                        break;
                    }
                }
                if (royalFlush)
                {
                    return 999; //Skickar tillbaka värdet av en royal flush; 999. Högst möjliga styrka.
                }
                else //Kollar ifall spelaren har en straight flush
                {
                    List<int> cardValueList = new List<int>();
                    foreach (string item in hand)
                    {
                        char cardChar = item[0];
                        int cardValue = 0;
                        if (cardChar == 'T')
                        {
                            cardValue = 10;
                        }
                        else if (cardChar == 'J')
                        {
                            cardValue = 11;
                        }
                        else if (cardChar == 'Q')
                        {
                            cardValue = 12;
                        }
                        else if (cardChar == 'K')
                        {
                            cardValue = 13;
                        }
                        else if (cardChar == 'A')
                        {
                            cardValue = 14;
                        }
                        else
                        {
                            cardValue = cardChar - '0';
                        }
                        cardValueList.Add(cardValue); //Sparar värdena av korten i en lista. Klädda kort (även tio) räknas om till en int-vänlig ekvivalent. T = 10, J = 11 etc.
                    }
                    cardValueList.Sort();
                    if (Straight(cardValueList, true))
                    {
                        return 900; //Skickar tillbaka värdet av en straight flush; 900. Näst högst möjliga styrka.
                    }
                }
            }
            

            return strength;
        }
        static bool Straight(List<int> cardValueList, bool sameSuit)
        {
            //Fixa funktion som kollar ifall spelaren har en stege. Om sameSuit = true har spelaren en straight flush. Annars har spelaren en straight.


            bool straight = false;

            return straight;
        }
        static int WinningHand(int player1HandStrength, int player2HandStrength)
        {
            int winningPlayer = 0;

            if (player1HandStrength > player2HandStrength)
            {
                winningPlayer = 1;
            }
            else
            {
                winningPlayer = 2;
            }
            return winningPlayer;
        }
    }    
}
