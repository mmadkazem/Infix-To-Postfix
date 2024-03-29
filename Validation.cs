using System;

namespace Infix_To_Postfix
{
    public class Validation
    {
        public static bool IsValid(string expression)
        {
            if (!MathExpressionsValidation.IsSuccess(expression))
            {
                Console.WriteLine("Your statement is not mathematically correct!!!");
                return false;
            }
            if (!NameValidation.IsSuccess(expression))
            {
                Console.WriteLine("The variable name is wrong!!!");
                return false;
            }
            return true;
        }
    }
}