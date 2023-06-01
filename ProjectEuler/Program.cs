using System;
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

                        bool theTemporary = false;

                        /*
                        foreach (string item in player1Hand)
                        {
                            Console.WriteLine(item);
                        }
                        foreach (string item in player2Hand)
                        {
                            Console.WriteLine(item);
                        }
                        
                        player1Hand.Clear();
                        player1Hand.Add("2H");
                        player1Hand.Add("2D");
                        player1Hand.Add("4C");
                        player1Hand.Add("4D");
                        player1Hand.Add("4S");

                        player2Hand.Clear();
                        player2Hand.Add("3C");
                        player2Hand.Add("3D");
                        player2Hand.Add("3S");
                        player2Hand.Add("9S");
                        player2Hand.Add("9D");
                        */

                        player1HandStrength = HandStrength(player1Hand, false, false); //Beräknar styrkan av spelarnas kort, i en int.
                        player2HandStrength = HandStrength(player2Hand, false, false);
                        
                        if (player1HandStrength >= 700 && player1HandStrength < 800 && player2HandStrength >= 700 && player2HandStrength < 800)
                        {
                            player1HandStrength = 0;
                            player2HandStrength = 0;
                        }
                        if (player1HandStrength >= 300 && player1HandStrength < 400 && player2HandStrength >= 300 && player2HandStrength < 400)
                        {
                            player1HandStrength = 0;
                            player2HandStrength = 0;
                        }

                        if (player1HandStrength > player2HandStrength) //Avgör vilken av spelarna som hade bäst hand, och ökar vinnarens antal vinster med 1.
                        {
                            player1Wins++; 
                        }
                        else if (player1HandStrength == player2HandStrength) //Följande är endast till för att avgöra vilken spelare som har bäst andrahandskort, ifall de gick lika först.
                        {                      
                            player1HandStrength = HandStrength(player1Hand, true, false);
                            player2HandStrength = HandStrength(player2Hand, true, false);

                            if (player1HandStrength == player2HandStrength)
                            {
                                player1HandStrength = HandStrength(player1Hand, true, true);
                                player2HandStrength = HandStrength(player2Hand, true, true);
                            }
                            while (player1HandStrength == player2HandStrength)
                            {
                                List<int> cardValueListP1 = new List<int>(); //Lista av korten spelare 1 har, endast i tal.
                                List<int> cardValueListP2 = new List<int>(); //Lista av korten spelare 2 har, endast i tal.

                                cardValueListP1 = CardListSorter(player1Hand);
                                cardValueListP2 = CardListSorter(player2Hand);

                                player1HandStrength = cardValueListP1.Last();
                                player2HandStrength = cardValueListP2.Last(); 

                                if (player1HandStrength == player2HandStrength)
                                {
                                    cardValueListP1.Remove(player1HandStrength);
                                    cardValueListP2.Remove(player2HandStrength);
                                }
                            }
                            if (player1HandStrength > player2HandStrength)
                            {
                                player1Wins++;
                            }
                            else
                            {
                                player2Wins++;                                
                            }
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
            Console.WriteLine("Spelare 1 vann " + player1Wins + " gånger.");
            Console.WriteLine("Spelare 2 vann " + player2Wins + " gånger.");
            Console.WriteLine("Matcher spelade: " + (player1Wins + player2Wins));
        }
        static int HandStrength(List<string> hand, bool tie, bool tieTwice)
        {
            List<int> cardValueList = new List<int>(); //Sorterad lista av spelarens kort.

            cardValueList = CardListSorter(hand);

            int firstCard = cardValueList[0];

            int strength = 0;
            int bonusPointsForHighCards = 0;
            bool royalFlush = false;
            bool sameSuit = true;
            List<char> cardRanks = new List<char>();            
            cardRanks.Add('T');
            cardRanks.Add('J');
            cardRanks.Add('Q');
            cardRanks.Add('K');
            cardRanks.Add('A');

            if (tie)
            {
                if (!tieTwice)
                {
                    strength = XOfAKind(cardValueList, 3, false);
                    if (strength != 0)
                    {
                        strength += 400;
                        return strength; //Värdet av three of a kind
                    }
                }
                strength = XOfAKind(cardValueList, 2, false);
                if (strength != 0)
                {
                    strength += 200;
                    return strength; //Värdet av ett par
                }
            }

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
                    if (Straight(cardValueList))
                    {
                        foreach (int item in cardValueList)
                        {
                            bonusPointsForHighCards += item;
                        }
                        return 900 + bonusPointsForHighCards; //Skickar tillbaka värdet av en straight flush; 900. Näst högst möjliga styrka.
                    }
                }
            }
            
            strength = XOfAKind(cardValueList, 4, false);
            if (strength != 0)
            {
                strength += 800;
                return strength; //Skickar tillbaka värdet av four of a kind.
            }
            
            strength = XOfAKind(cardValueList, 3, true);
            if (strength != 0)
            {
                strength += 700;
                return strength; //Skickar tillbaka värdet av full house.
            }
            
            if (sameSuit)
            {
                foreach (int item in cardValueList)
                {
                    bonusPointsForHighCards += item;
                }
                return 600 + bonusPointsForHighCards; //Skickar tillbaka värdet av flush.
            }

            if (Straight(cardValueList))
            {
                foreach (int item in cardValueList)
                {
                    bonusPointsForHighCards += item;
                }
                return 500 + bonusPointsForHighCards; //Skickar tillbaka värdet av en straight (ej straight flush eftersom !sameSuit).
            }

            strength = XOfAKind(cardValueList, 3, false);
            if (strength != 0)
            {
                strength += 400;
                return strength; //Skickar tillbaka värdet av three of a kind.
            }

            strength = XOfAKind(cardValueList, 2, true);
            if (strength != 0)
            {
                strength += 300;
                return strength; //Skickar tillbaka värdet av två par.
            }

            strength = XOfAKind(cardValueList, 2, false);
            if (strength != 0)
            {
                strength += 200;
                return strength; //Skickar tillbaka värdet av ett par.
            }
            
            return cardValueList.Last();
        }
        static List<int> CardListSorter(List<string> hand)
        {
            List<int> cardValueList = new List<int>(); //Sorterad lista av spelarens kort.

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
            cardValueList.Sort(); //Sorterar värdena i storleksordning för att göra en senare funktion mer simpel.

            return cardValueList;
        }
        static int XOfAKind(List<int> cardValueList, int XOfAKindValue, bool twoChecks)
        {
            int strength = 0; //Denna variabel utgör bonuspoängen som räknas med beroende på kortens individuella styrka. Om den inte är 0 så har spelaren t.ex. ett par.
            bool equalCards = false;
            bool fullHouseOrTwoPairs = false;
            int forbiddenNumber = 0;            
            restart: //Tillbakahopp så att undanstående foreach-loop kan användas två gånger per gång funktionen kallas.
            int indexValue = 1;
            int valueOfAKindLoopValue = 0;
            int xOfAKindCard = cardValueList[indexValue];
            
            foreach (int item in cardValueList) //Foreach-loop som kollar för X (värde som 3 eller 4) of a kind.
            {
                equalCards = false;
                if (item == xOfAKindCard && item != forbiddenNumber)
                {
                    valueOfAKindLoopValue++;
                    equalCards = true;
                }
                else if (item != xOfAKindCard && valueOfAKindLoopValue == 0 || item == forbiddenNumber)
                {                    
                    indexValue++;
                    if (indexValue >= 5)
                    {
                        return 0; //Ser till att funktionen inte stendör genom att försöka sätta kortet till index [5] (utanför listan).
                    }
                    xOfAKindCard = cardValueList[indexValue];
                }
                if (valueOfAKindLoopValue >= XOfAKindValue)
                {
                    if (!twoChecks)
                    {
                        if (XOfAKindValue == 2)
                        {
                            strength = xOfAKindCard * 2;
                        }
                        else if (XOfAKindValue == 3)
                        {
                            strength = xOfAKindCard * 3;
                        }
                        else if (XOfAKindValue == 4)
                        {
                            strength = xOfAKindCard * 4;
                        }
                        return strength; //Skickar ifall spelaren har x of a kind och programmet INTE är ute efter flera par/full house.
                    }
                    else
                    {
                        strength += xOfAKindCard * valueOfAKindLoopValue;
                        if (fullHouseOrTwoPairs)
                        {
                            return strength; //Koden kommer hit om spelaren först har ett par eller trepar, och sedan har ett till par.
                        }
                        forbiddenNumber = xOfAKindCard;
                        XOfAKindValue = 2; //Om spelaren letar efter full house eller tvåpar så består den andra kortkombinationen ALLTID av två kort.
                        fullHouseOrTwoPairs = true;
                        goto restart;
                    }
                }
                else
                {
                    if (valueOfAKindLoopValue > 0 && !equalCards)
                    {
                        if (fullHouseOrTwoPairs)
                        {
                            return 0;
                        }
                        strength += xOfAKindCard * valueOfAKindLoopValue;
                        forbiddenNumber = xOfAKindCard;
                        fullHouseOrTwoPairs = true;
                        indexValue = cardValueList.FindIndex(x => x == item);
                        goto restart;
                    }
                }
            }
            return 0;
        }
        static bool Straight(List<int> cardValueList)
        {
            bool straight = false;

            int currentCardValue = cardValueList[0] - 1; //Litet knep för att se till att foreach-loopen alltid körs minst en gång.
            foreach (int item in cardValueList)
            {
                if (item == currentCardValue + 1)
                {
                    straight = true;
                }
                else
                {
                    straight = false;
                    return straight;
                }
                currentCardValue = item;
            }
            return straight;
        }
    }    
}
