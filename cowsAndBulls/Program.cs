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

        public static int[] generate4Digit()
        {
            bool stopLoop = false;
            int[] randomDigit = new int[4];
            Random rnd = new Random();
            randomDigit[0] = rnd.Next(0, 9);
            randomDigit[1] = rnd.Next(0, 9);
            while (!stopLoop)
            {
                if (randomDigit[0] == randomDigit[1])
                {
                    randomDigit[1] = rnd.Next(0, 9);
                }
                else if (randomDigit[0] != randomDigit[1])
                {
                    stopLoop = true;
                }
            }
            randomDigit[2] = rnd.Next(0, 9);
            while (stopLoop)
            {
                if (randomDigit[0] == randomDigit[2])
                {
                    randomDigit[2] = rnd.Next(0, 9);
                }
                else if (randomDigit[1] == randomDigit[2])
                {
                    randomDigit[2] = rnd.Next(0, 9);
                }
                else if (randomDigit[0] != randomDigit[2] & randomDigit[1] != randomDigit[2])
                {
                    stopLoop = false;
                }
            }
            randomDigit[3] = rnd.Next(0, 9);
            while(!stopLoop)
            {
                if(randomDigit[0] == randomDigit[3])
                {
                    randomDigit[3] = rnd.Next(0, 9);
                }
                else if(randomDigit[1] == randomDigit[3])
                {
                    randomDigit[3] = rnd.Next(0, 9);
                }
                else if(randomDigit[2] == randomDigit[3])
                {
                    randomDigit[3] = rnd.Next(0, 9);
                }
                else if(randomDigit[0] != randomDigit[3] & randomDigit[1] != randomDigit[3] & randomDigit[2] != randomDigit[3])
                {
                    stopLoop = true;
                }
            }
            return randomDigit;
        }

        static void Main(string[] args)
        {
            int[] x = generate4Digit();
            for(int i=0; i < 4; i++)
            {
                Console.WriteLine(x[i]);
            }
            Console.ReadKey();
        }
    }
}
