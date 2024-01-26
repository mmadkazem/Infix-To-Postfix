using System;

namespace Infix_To_Postfix
{
    public class MathExpressionsValidation
    {
        public static bool IsSuccess(string expression)
        {
            if (!IsBallance(expression))
            {
                Console.WriteLine("Your expression is not ballance!!!");
                return false;
            }
            for (int i = 0; i < expression.Length; i++)
            {
                if (!IsValidCharter(expression, i))
                {
                    return false;
                }
                if (i + 1 == expression.Length)
                {
                    break;
                }
                if (!IsCorrectToUseParentheses(expression, i))
                {
                    return false;
                }
            }
            if (IsOperator(expression[expression.Length - 1]))
            {
                return false;
            }
            return true;
        }

        private static bool IsBallance(string expression)
        {     
            var _stack = new MyStack<char>();
            foreach (char c in expression.ToCharArray())
            {
                if (c == '(')
                {
                    _stack.Push(c);
                }
                if (c == ')')
                {
                    if (_stack.IsEmpty()) return false;

                    _stack.Pop();
                }
            }
            return _stack.IsEmpty();
        }

        public static bool IsNumber(string expression)
        {
            foreach (var c in expression)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }

            return true;
        }
        static bool IsCorrectToUseParentheses(string expression, int i)
        {
            var thisChar = expression[i];
            var afterChar = expression[i + 1];
            if (char.IsLetterOrDigit(thisChar) && afterChar == '(')
            {
                Console.WriteLine("There must be an operator before the open parenthesis!!!");
                return false;
            }
            if (thisChar == ')' && char.IsLetterOrDigit(afterChar))
            {
                Console.WriteLine("Then the closing parenthesis must be an operator!!!");
                return false;
            }
            if (!char.IsLetterOrDigit(thisChar) && afterChar == ')')
            {
                Console.WriteLine("The closing parenthesis must be preceded by a number or variable!!!");
                return false;
            }
            if (thisChar == '(' && !char.IsLetterOrDigit(afterChar))
            {
                Console.WriteLine("After the open parenthesis, it must be a number or a variable!!!");
                return false;
            }
            if (IsOperator(thisChar) && IsOperator(afterChar))
            {
                Console.WriteLine("It does not work after two operators!!!");
                return false;
            }
            if (thisChar == ')' && afterChar == '(')
            {
                Console.WriteLine("You need an operator between the parentheses!!!");
                return false;
            }
            return true;
        }
        static bool IsValidCharter(string expression, int i)
        {
            var c = expression[i];
            if (!(char.IsLetterOrDigit(c) || IsOperator(c) || IsPerantessaAndSpace(c)))
            {
                Console.WriteLine($"{c} is not valid!!!");
                return false;
            }
            return true;

        }
        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        static bool IsPerantessaAndSpace(char c)
        {
            return c == '(' || c == ')' || c == ' ';
        }
    }
}