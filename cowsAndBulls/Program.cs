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
        public static bool ifAnyDuplicate(int[] array)
        {
            // Method used to check if any numbers in a 4 digit array are duplicates
            if(array[0] == array[1] || array[0] == array[2] || array[0] == array[3])
            {
                return true;
            }
            if(array[1] == array[0] || array[1] == array[2] || array[1] == array[3])
            {
                return true;
            }
            if (array[2] == array[0] || array[2] == array[1] || array[2] == array[3])
            {
                return true;
            }
            if(array[3] == array[0] || array[3] == array[1] || array[3] == array[2])
            {
                return true;
            }
            return false;
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
            // compareAnswers() checks for cows and bulls.
            if(gen == input)
            {
                return true;
            }
            foreach(int x in input)
            {
                if(gen[x] == input[x])
                {
                    bulls++;
                }
            }
            if(gen[0] == input[1])
            {
                cows++;
            }
            if(gen[0] == input[2])
            {
                cows++;
            }
            if(gen[0] == input[3])
            {
                cows++;
            }
            if(gen[1] == input[0])
            {
                cows++;
            }
            if(gen[1] == input[2])
            {
                cows++;
            }
            if(gen[1]==input[3])
            {
                cows++;
            }
            if(gen[2] == input[0])
            {
                cows++;
            }
            if(gen[2] == input[1])
            {
                cows++;
            }
            if(gen[2] == input[3])
            {
                cows++;
            }
            if(gen[3] == input[0])
            {
                cows++;
            }
            if(gen[3] == input[1])
            {
                cows++;
            }
            if(gen[3] == input[2])
            {
                cows++;
            }
            return false;
        }
        public void Guess()
        {
            // Guess() is the method where the player guesses the number.
            int[] number = generate4Digit(); // Where the number needed is stored.
            Console.WriteLine("Enter your guess! (4 digit number)");
            int guess;
            while(!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.WriteLine("Input is not an number!\n");
            }
            int[] guessArr = new int[3];
            guessArr = Array.ConvertAll(guess.ToString().ToArray(), x => (int)x - 48);
            if(guessArr.Length != 4)
            {
                Console.WriteLine("Number is not 4 digits!\n");
                Guess();
            }
            bool check = ifAnyDuplicate(guessArr);
            if(check)
            {
                Console.WriteLine("Entered number has a duplicate!\n");
                Guess();
            }

            // Checking over, now the game starts!
        }
        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.Guess();
        }
    }
}
