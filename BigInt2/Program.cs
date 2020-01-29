using System;

namespace BigInt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1, number2, result;
            number1 = ReadBigNumber(1);
            number2 = ReadBigNumber(2);
            result = AddBigInts(number1, number2);
            Console.WriteLine();
            Console.WriteLine("Summe der Zahlen:");
            Console.WriteLine(result);
            result = MultBigInts(number1, number2);
            Console.WriteLine();
            Console.WriteLine("Produkt der Zahlen:");
            Console.WriteLine(result);
        }

        /// <summary>
        /// Asks for an Input-String and checks if it is a number or not, when not a new number is prompted
        /// </summary>
        /// <param name="counter">Number of input</param>
        /// <returns>The Input-String</returns>
        public static string ReadBigNumber(int counter)
        {
            string inputNumber;
            bool isNumber;

            do
            {
                Console.Write("Geben Sie die {0}. Zahl ein: ",counter);
                inputNumber = Console.ReadLine();
                isNumber = true;

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
        public static string AddLeadingChars(string inputString, string character, int numberOfTimes)
        {
            string outputString = "";

            for (int i = 0; i < numberOfTimes; i++)
            {
                outputString += character;
            }

            outputString += inputString;

            return outputString;
        }

        /// <summary>
        /// Takes two integer numbers as strings and makes an addition with them.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns>A string with the result of the integer addition</returns>
        public static string AddBigInts(string number1, string number2)
        {
            string result = "";
            int digit1, digit2, nextDigit=0, tempResult;

            //Adds leading zeros if needed
            if(number1.Length != number2.Length)
            {
                int timesToAddZero = number1.Length - number2.Length;
                if (timesToAddZero<0)
                {
                    timesToAddZero *= -1;
                    number1 = AddLeadingChars(number1, "0", timesToAddZero);
                }
                else
                {
                    number2 = AddLeadingChars(number2, "0", timesToAddZero);
                }
            }

            for (int i = number2.Length-1; i >= 0; i--)
            {
                digit1 = Convert.ToInt32(number1[i].ToString());
                digit2 = Convert.ToInt32(number2[i].ToString());
                tempResult = digit1 + digit2 + nextDigit;

                if (tempResult > 9)
                {
                    nextDigit = 1;
                }
                else
                {
                    nextDigit = 0;
                }

                tempResult %= 10;

                result = tempResult.ToString() + result;
            }

            if (nextDigit == 1)
            {
                result = "1" + result;
            }

            return result;
        }

        /// <summary>
        /// Adds an integer as string a called number of times to itself in an integer addition.
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <param name="numberOfTimes"></param>
        /// <returns>The multiplied integer number as string</returns>
        public static string MultBigIntWithDigit(string inputNumber, int numberOfTimes)
        {
            string outputNumber = "0";

            for (int i = 0; i < numberOfTimes; i++)
            {
                outputNumber = AddBigInts(outputNumber, inputNumber);
            }

            return outputNumber;
        }

        /// <summary>
        /// Takes two numbers as string and makes a integer multiplication
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns>The result of the integer multiplication as string</returns>
        public static string MultBigInts(string number1, string number2)
        {
            string outputString = "0";
            string[] additionCandidates = new string[number2.Length];

            for (int i = number2.Length-1; i >= 0; i--)
            {
                additionCandidates[i] = MultBigIntWithDigit(number1,Convert.ToInt32(number2[i].ToString()));
            }

            for (int j = 0; j < additionCandidates.Length; j++)
            {
                outputString = AddBigInts(outputString+"0", additionCandidates[j]);
            }

            return outputString;
        }
    }
}
