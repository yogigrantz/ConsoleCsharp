using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prgramming_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // This program will check whether or not a series of braces are set in pairs
            // Coded by Yogi Grantz - 10/20/2015
            Console.WriteLine("Enter combination of braces, i.e: { } ( ) [ ] <> (x to exit): ");
            Console.Write("===>");

            string inputString = "";
            bool validTest;
            while (inputString != "x")
            {
                inputString = Console.ReadLine();
                if (inputString != "x")
                {
                    validTest = CheckBraces(inputString);
                    if (validTest)
                        Console.WriteLine("Valid matching braces: " + validTest);
                    else
                        Console.WriteLine("Invalid matching braces: " + inputString + " Please try again");

                    Console.WriteLine();
                }
                Console.WriteLine("Enter combination of braces, i.e: { } ( ) [ ] <> (x to exit): ");
                Console.Write("===>");

            }
        }

        static bool CheckBraces(string chars)
        {
            if (chars.Length % 2 != 0)
                return false;
            if (chars.Length < 2)
                return false;
            if (chars.Length > 100)
                return false;

            List<char> charList = new List<char>();
            for (int i = 0; i < chars.Length; i++)
            {
                charList.Add(chars[i]);
            }
            Dictionary<char,char> braces = new Dictionary<char,char>();
            braces.Add('}', '{');
            braces.Add(')', '(');
            braces.Add(']', '[');
            braces.Add('>', '<');
            char[] rightBraces = new char[] { ')', '}', ']' };
            int currNbrOfChars = charList.Count();
            while (charList.Count() > 0)
            {
                for (int i = 0; i < charList.Count(); i++)
                {
                    if (rightBraces.Contains(charList[i]) & i > 0)
                    {
                        if (MatchedBraces(charList[i - 1], charList[i], braces))
                        {
                            charList.RemoveAt(i);
                            charList.RemoveAt(i - 1);
                            break;
                        }
                        else
                            return false;
                    }
                }
                if (charList.Count() == currNbrOfChars & charList.Count() > 0)
                    return false;
            }
            return true;

        }

        static bool MatchedBraces(char x, char y, Dictionary<char, char> bracesDictionary)
        {
            char leftBrace;
            if (bracesDictionary.TryGetValue(y, out leftBrace))
            {
                if (x == leftBrace)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
