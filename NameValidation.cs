using System;
using System.Collections.Generic;

namespace Infix_To_Postfix
{
    public class NameValidation
    {

        public static bool IsSuccess(string expression)
        {
            var tokenList = NameToken(expression);
            foreach (var item in tokenList)
            {
                if (!IsValidVaribleName(item))
                {
                    return false;
                }
            }
            return true;
        }
        static List<string> NameToken(string expression)
        {
            var save = "";
            var TokenList = new List<string>();
            foreach (var c in expression)
            {
                if (char.IsLetterOrDigit(c))
                {
                    save += c;
                }
                else if (IsOperator(c))
                {
                    TokenList.Add(save);
                    save = "";
                }
            }
            TokenList.Add(save);

            return TokenList;
        }
        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
        static bool IsValidVaribleName(string varible)
        {
            var arrayChar = varible.ToCharArray();
            for (int i = 1; i <= arrayChar.Length - 2; i++)
            {
                if (char.IsNumber(varible[0])
                 && char.IsLetter(varible[i]))
                {
                    Console.WriteLine("The variable must not start with a number");
                    Console.WriteLine($"varible: {varible}");
                    return false;
                }
                if (char.IsNumber(varible[i])
                 && (char.IsLetter(varible[varible.Length - 1]) || 
                 char.IsNumber(varible[varible.Length - 1])))
                {
                    Console.WriteLine("The number should not be in the middle");
                    Console.WriteLine($"varible: {varible}");
                    return false;
                }
            }

            return true;

        }
    }
}