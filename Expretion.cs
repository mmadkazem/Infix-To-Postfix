namespace Infix_To_Postfix
{
    public static class IsBallanceValidation
    {
        private static MyStack<char> _stack;
        private static char[] _openChars = { '(', '<', '[', '{' };
        private static char[] _closeChars = { ')', '>', ']', '}' };

        

        public static bool IsSuccess(string expression)
        {
             _stack = new MyStack<char>();
            foreach (char c in expression.ToCharArray())
            {
                if (isOpenChars(c))
                {
                    _stack.Push(c);
                }
                if (isCloseChars(c))
                {
                    if (_stack.IsEmpty()) return false;

                    if (Same(c))
                    {
                        _stack.Pop();
                    }
                }
            }
            return _stack.IsEmpty();
        }

        private static bool isOpenChars(char c)
        {
            foreach (char item in _openChars)
            {
                if (item == c) return true;
            }
            return false;
        }

        private static bool isCloseChars(char c)
        {
            foreach (char item in _closeChars)
            {
                if (item == c) return true;
            }
            return false;
        }
        private static bool Same(char c)
        {
            return (_stack.Peek() == '(' && c == ')') ||
                (_stack.Peek() == '{' && c == '}') ||
                (_stack.Peek() == '<' && c == '>') ||
                (_stack.Peek() == '[' && c == ']');
        }
    }
}