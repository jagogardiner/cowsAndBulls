using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cowsAndBulls
{
    class Program
    {
        // Variables needed for global use
        int guesses = 0;
        int bulls = 0;
        int cows = 0;
        public static int[] generate4Digit()
        {
            // generate4Digit generates a four digit number, with no duplicate numbers.
            bool stopLoop = false;
            int[] randomDigit = new int[4]; // Array used to store the number.
            Random rnd = new Random();
            randomDigit[0] = rnd.Next(0, 9); // Generate a number from 0-9.
            randomDigit[1] = rnd.Next(0, 9);
            while(!stopLoop)
            {
                if (!checkDuplicate(randomDigit[0], randomDigit[1]))
                {
                    stopLoop = true;
                }
                else
                {
                    randomDigit[1] = rnd.Next(0, 9);
                }
            }
            randomDigit[2] = rnd.Next(0, 9);
            while(stopLoop)
            {
                if(!checkDuplicate(randomDigit[0], randomDigit[2]) & !checkDuplicate(randomDigit[1], randomDigit[2]))
                {
                    stopLoop = false;
                }
                else
                {
                    randomDigit[2] = rnd.Next(0, 9);
                }
            }
            randomDigit[3] = rnd.Next(0, 9);
            while(!stopLoop)
            {
                if (!checkDuplicate(randomDigit[0], randomDigit[3])
                    & !checkDuplicate(randomDigit[1], randomDigit[3])
                    & !checkDuplicate(randomDigit[2], randomDigit[3]))
                {
                    stopLoop = true;
                }
                else
                {
                    randomDigit[3] = rnd.Next(0, 9);
                }
            }
            return randomDigit;
        }
        public static bool checkDuplicate(int gen1, int gen2)
        {
            // checkDuplicate() is the method used for checking if the two inputs are equal.
            if (gen1 == gen2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool compareAnswers(int[] gen, int[] input)
        {
            if(gen == input)
            {
                return true;
            }
            if(gen[0] == input[0])
            {
                bulls++;
            }
            if(gen[0] == input[1])
            {
                cows++;
            }
            foreach(int x in input)
            {
                if(gen[x] == input[x])
                {
                    bulls++;
                }
            }
            for(int a=1; a < 3; a++)
            {
                if(gen[0] == input[a])
                {
                    cows++;
                }
            }
            for(int b=1; b < 3; b++)
            {
                
            }
            return true;
        }
        public void Guess()
        {
            // Guess() is the method where the player guesses the number.
            int[] number = generate4Digit(); // Where the number needed is stored.
            Console.WriteLine("Enter your guess!");

        }
        static void Main(string[] args)
        {
            int[] x = generate4Digit();
            for(int i=0; i < 4; i++)
            {
                Console.WriteLine(x[i]);
            }
            int fullnum = 0;
            for (int c = 0; c < x.Length; c++)
            {
                fullnum += x[c] * Convert.ToInt32(Math.Pow(10, x.Length - c - 1));
            }
            string con = fullnum.ToString();
            Console.WriteLine(con);
            Console.ReadKey();
        }
    }
}
