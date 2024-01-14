using System;

namespace Infix_To_Postfix
{
    public static class Compute
    {
        public static int CalculatePostfix(string expression)
        {
            var stack = new MyStack<int>();
            var postfixNum = InuputNumberPostfix(expression);
            string save = "";
            foreach (char c in postfixNum)
            {
                if (char.IsNumber(c))
                {
                    save += c;
                }
                else if (c == ',')
                {
                    stack.Push(System.Convert.ToInt32(save));
                    save = "";
                }
                else if (IsOperator(c))
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    int result = PerformOperation(operand1, operand2, c);
                    stack.Push(result);
                }
            }
            return stack.Pop();
        }
        public static string InuputNumberPostfix(string expression)
        {
            var save = "";
            var postfixNum = "";

            foreach (char c in expression)
            {
                if (char.IsLetterOrDigit(c))
                {
                    save += c;
                }
                else if (c == ',')
                {
                    if (MathExpressionsValidation.IsNumber(save))
                    {
                        postfixNum += save + ',';
                        continue;
                    }

                    Console.Write($"{save}: ");
                    postfixNum += Console.ReadLine() + ',';
                    save = "";
                }
                else if (IsOperator(c))
                {
                    postfixNum += c;
                }
            }

            return postfixNum;
        }
        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        static int PerformOperation(int operand1, int operand2, char op)
        {
            switch (op)
            {
                case '+':
                    return operand1 + operand2;
                case '-':
                    return operand1 - operand2;
                case '*':
                    return operand1 * operand2;
                case '/':
                    return operand1 / operand2;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
    }
}