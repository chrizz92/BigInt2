using System;

namespace BigInt2
{
    class Program
    {
        /// <summary>
        /// Prueft ob ein eingelesener String eine Zahl ist. Nimmt einen Integer als Parameter entgegen um zu sagen die wievielte Zahl eingelesen worden ist.
        /// </summary>
        /// <param name="counter"></param>
        /// <returns>Gibt die eingegebene Zahl als String zurueck</returns>
        static string ReadBigNumber(int counter)
        {
            string inputNumber;
            bool isNumber = true;

            do
            {
                Console.Write("Geben Sie die {0}. Zahl ein: ",counter);
                inputNumber = Console.ReadLine();

                for (int i = 0; i < inputNumber.Length; i++)
                {
                    if(inputNumber[i] < '0' || inputNumber[i] > '9')
                    {
                        isNumber = false;
                        break;
                    }
                }
            } while (!isNumber);

            return inputNumber;
        }


        /// <summary>
        /// Takes an Input-String and adds a specified character a named number of times at the lead
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="character"></param>
        /// <param name="numberOfTimes"></param>
        /// <returns>The new string with the leading characters</returns>
        static string AddLeadingChars(string inputString, string character, int numberOfTimes)
        {
            string outputString = "";

            for (int i = 0; i < numberOfTimes; i++)
            {
                outputString += character;
            }

            outputString += inputString;

            return outputString;
        }


        static string AddBigInts(string number1, string number2)
        {
            string result = "";

            if(number1.Length != number2.Length)
            {
                int timesToAddZero = number1.Length - number2.Length;
                if (timesToAddZero<0)
                {
                    timesToAddZero *= -1;
                }
                else
                {

                }
            }

            return result;
        }



        static void Main(string[] args)
        {
            string number1, number2;

            Console.WriteLine("BIG-INT");
            Console.WriteLine("=======");

            number1 = ReadBigNumber(1);
            number2 = ReadBigNumber(2);


        }
    }
}
