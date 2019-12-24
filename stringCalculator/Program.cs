using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace stringCalculator
{
    class MainClass
    {
        //Create Comma string
        private static List<String> delimiters = new List<String>() { ",", "\n" };//defaults
        private const String customDelimiter = "//";//singles customer delimiter
        public static void Main(string[] args)
        {
            bool keepGoing = true;
            do
            {
                Console.WriteLine("Input string");
                int result = 0;
                List<int> list = new List<int>();
                string input = Console.ReadLine();
                input = input.Replace("\\n", "\n");
                list = createList(input);
                //checkListCount(list);//restraint for step 1
                result = doSum(list);
                Console.Write("Formula:  ");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i < list.Count - 1)
                    {
                        Console.Write(list[i] + "+");
                    }//end if
                    else
                    {
                        Console.Write(list[i]);
                    }//end else
                }//end for
                Console.WriteLine("\nResult is " + result +"\n");
            } while (keepGoing);
        }//end Main

        private static List<int> createList(String input)
        {
            List<int> list = new List<int>();
            if (input.StartsWith(customDelimiter))
            {
                list = customDelimiterList(input);
            }
            //else if(input.Contains(delimiters.ElementAt(0))|| input.Contains(delimiters.ElementAt(1)))
            else
            {
                list = delimitList(input);
            }
            return list;
        }//end createList

        private static void checkListCount(List<int> list)
        {
            if (list.Count > 2)
            {
                throw new Exception("Cannot have more than 2 entries");
            }//end checkListCount

        }//end checkListCount
        private static List<int> customDelimiterList(string input)
        {
            List<String> multiDelimiter = new List<String>() { "[", "]" };
            multiDelimiter.Add(customDelimiter);
            List<String> customerDelimiters = new List<String>();
            List<int> numList = new List<int>();
            List<int> cleanList = new List<int>();

            var firstInput = input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();
            var lastInput = input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Last();
            string[] customDelimit = firstInput.Split(multiDelimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var splitList = lastInput.Split(customDelimit, StringSplitOptions.RemoveEmptyEntries);

            foreach (var num in splitList)
            {
                try
                {
                    int number = int.Parse(num);
                    numList.Add(checkInt(number));

                }
                catch (Exception e)//characters that can't be parsed into ints.
                {
                    numList.Add(0);
                }
            }//end for each

            foreach (var num in numList)
            {
                if (num < 0)
                {
                    try
                    {
                        throw new ApplicationException(num + " is negative");
                    }
                    catch (Exception e)
                    {
                        //numList.Remove(num);
                        Console.WriteLine(num + " is negative and invalid");
                    }//end catch
                }
                else
                    cleanList.Add(num);
            }//end foreach


            return cleanList;
        }//end customDelimiterList


        private static List<int> delimitList(string input)
        {
            List<int> numList = new List<int>();
            List<int> cleanList = new List<int>();
            var splitComma = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var num in splitComma)
            {
                try
                {
                    int number = int.Parse(num);
                    numList.Add(checkInt(number));

                }
                catch (Exception e)//characters that can't be parsed into ints.
                {
                    numList.Add(0);
                }
            }//end for each

            foreach (var num in numList)
            {
                if (num < 0)
                {
                    try
                    {
                        throw new ApplicationException(num + " is negative");
                    }
                    catch (Exception e)
                    {
                        //numList.Remove(num);
                        Console.WriteLine(num + " is negative and invalid");

                    }//end catch
                }
                else
                    cleanList.Add(num);
            }

            return cleanList;

        }//end customDelimiterList

        private static int checkInt(int num)//checks the value of the integer
        {
            if (num <= 1000)
                return num;
            else//if >1000
                return 0;
        }//end checkInt
        private static int doSum(List<int> intList)
        {
            int result = 0;
            foreach (var num in intList)
            {
                result += num;
            }//end foreach
            return result;
        }//end doSum
    }//end MainClass
}
