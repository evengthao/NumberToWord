using System;
using System.Text;

namespace NumbersToWord
{
    class Program
    {
        private static StringBuilder _displayNumberToWord = new StringBuilder();

        static void Main(string[] args)
        {
            int theNumber = 15425;  // Number you want to display as word



            int multiplyBy;
            
            // Find the max group of 3 
            var maxGroupIndex =  GetArrayIndex(theNumber, out multiplyBy);

            // Get the Array value of each group
            int[] resultOfGroups =  SplitIntoGroupOfThree(maxGroupIndex, theNumber, multiplyBy);

            var groupIndex = resultOfGroups.Length;

            if (theNumber == 0)
            {
                _displayNumberToWord.Append(TranslateNumberToWord(theNumber));
            }
            else
            {
                foreach (var groupNumber in resultOfGroups)
                {
                    SetNumberToWord(groupNumber, groupIndex);
                    SetGroupSuffix(groupIndex);
                    groupIndex -= 1;
                }
            }

  
            Console.WriteLine("The Number:   "+ theNumber + "       English Word : " + _displayNumberToWord);
            Console.ReadKey();
        }

        private static void SetGroupSuffix(int groupIndex)
        {
            switch (groupIndex)
            {
                case 7:
                    _displayNumberToWord.Append("sextillion");
                    break;
                case 6:
                    _displayNumberToWord.Append("quintillion");
                    break;
                case 5:
                    _displayNumberToWord.Append("quadrillion");
                    break;
                case 4:
                    _displayNumberToWord.Append("trillion");
                    break;
                case 3:
                    _displayNumberToWord.Append("billion");
                    break;
                case 2:
                    _displayNumberToWord.Append("thousand");
                    break;
            }
            _displayNumberToWord.Append(" ");
        }


        private static void SetNumberToWord(int number, int groupIndex)
        {
            var temp = number;

            while (temp != 0)
            {
                if (temp < 20)
                {
                    _displayNumberToWord.Append(TranslateNumberToWord(temp));
                    temp = 0;  // no more reminder
                }
                else if (temp < 100 )
                {
                    _displayNumberToWord.Append(TranslateNumberToWord(temp));
                    temp = temp % 10; // get the reminder
                }
                else
                {
                    var hundredNumber = (number/100);
                    _displayNumberToWord.Append(TranslateNumberToWord(hundredNumber));
                    _displayNumberToWord.Append(" ");
                    _displayNumberToWord.Append(TranslateNumberToWord(number));
                    temp = temp % 100;  // get the reminder 
                }

                _displayNumberToWord.Append(" ");

            }


        }

        private static int GetArrayIndex(int number, out int multiplyBy)
        {
            int numberOfGroupOfThree = 1;
            multiplyBy = 1;
            while (number >= multiplyBy * 1000)
            {
                numberOfGroupOfThree++;
                multiplyBy *= 1000;
            }
            return numberOfGroupOfThree;
        }

        private static int[] SplitIntoGroupOfThree(int numberOfGroupOfThree, int number, int multiplyBy)
        {
            int[] result = new int[numberOfGroupOfThree];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = number / multiplyBy; // Get the sets of 3 
                number %= multiplyBy; // Get Reminder
                multiplyBy /= 1000;
            }
            return result;
        }


        private static string TranslateNumberToWord(int number)
        {
            var strNumber = string.Empty;

            switch (number)
            {
                case 0:
                    strNumber = "zero";
                    break;
                case 1:
                     strNumber = "one";
                    break;
                case 2:
                     strNumber = "two";
                    break;
                case 3:
                    strNumber = "three";
                    break;
                case 4:
                    strNumber = "four";
                    break;
                case 5:
                    strNumber = "five";
                    break;
                case 6:
                    strNumber = "six";
                    break;
                case 7:
                    strNumber = "seven";
                    break;
                case 8:
                    strNumber = "eight";
                    break;
                case 9:
                    strNumber = "nine";
                    break;
                case 10:
                    strNumber = "ten";
                    break;
                case 11:
                    strNumber = "eleven";
                    break;
                case 12:
                    strNumber = "twelve";
                    break;
                case 13:
                    strNumber = "thirteen";
                    break;
                case 14:
                    strNumber = "fourteen";
                    break;
                case 15:
                    strNumber = "fifteen";
                    break;
                case 16:
                    strNumber = "sixteen";
                    break;
                case 17:
                    strNumber = "seventeen";
                    break;
                case 18:
                    strNumber = "eighteen";
                    break;
                case 19:
                    strNumber = "nineteen";
                    break;
                default:
                    strNumber = TranslateNumberGreaterThen19(number);
                    break;
            }

            return strNumber;
        }

        private static string TranslateNumberGreaterThen19(int number)
        {
            var strNumber = "";

            if (number >= 20 && number < 30)
            {
                strNumber = "twenty";
            } else if (number >= 30  && number < 40)
            {
                strNumber = "thirty";
            } else if (number >= 40  && number < 50)
            {
                strNumber = "fourty";
            }
            else if (number >= 50 && number < 60)
            {
                strNumber = "fifty";
            }
            else if (number >= 60 && number < 70)
            {
                strNumber = "sixty";
            }
            else if (number >= 70 && number < 80)
            {
                strNumber = "seventy";
            }
            else if (number >= 80 && number < 90)
            {
                strNumber = "eighty";
            }
            else if (number >= 90 && number < 100)
            {
                strNumber = "ninty";
            }
            else if (number >= 100 && number < 1000)
            {
                strNumber = "hundred";
            }
     

            return strNumber;
        }

      
    }
}
