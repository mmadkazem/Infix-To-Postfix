using System;

namespace Infix_To_Postfix
{
    public class Convert
    {
        private static int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return -1;
            }
        }

        public static string Postfix(string infix)
        {
            var postfix = "";
            var save = "";
            var opertors = new MyStack<char>();
            foreach (var c in infix)
            {
                if (char.IsLetterOrDigit(c))
                {
                    save += c;
                }
                else if (c == '(')
                {
                    if (save != "")
                    {
                        save += ",";
                        postfix += save;
                        save = "";
                    }
                    opertors.Push(c);
                }
                else if (c == ')')
                {
                    if (save != "")
                    {
                        save += ",";
                        postfix += save;
                        save = "";
                    }
                    while (opertors.Count > 0 && opertors.Peek() != '(')
                    {
                        postfix += opertors.Pop();
                    }
                    opertors.Pop();
                }
                else if (Precedence(c) != -1)
                {
                    if (save != "")
                    {
                        save += ",";
                        postfix += save;
                        save = "";
                    }
                    while (opertors.Count > 0 && Precedence(c) <= Precedence(opertors.Peek()))
                    {
                        postfix += opertors.Pop();
                    }
                    opertors.Push(c);
                }
            }
            if (save != "")
            {
                save += ",";
                postfix += save;
            }
            while (opertors.Count > 0)
            {
                postfix += opertors.Pop();
            }
            return postfix;
        }

        internal static int ToInt32(string sb)
        {
            throw new NotImplementedException();
        }
    }
}