using System;
using System.Collections.Generic;

namespace Lab07
{
    class Task1_Stack
    {
        static void Main(string[] args)
        {
            string[] lines = new string[]
            {
                "",
                "a + b",
                "{[a] + (b)}",
                "([)]",
                "a)",
                "(a[b]",
                "f(x[1]) * {y + (z)}"
            };

            Console.WriteLine("--- Задача 1: Перевірка дужок (Стек) ---");
            foreach (var line in lines)
            {
                string displayLine = string.IsNullOrEmpty(line) ? "(порожній рядок)" : line;
                string res = IsBalanced(line) ? "так" : "ні";
                Console.WriteLine($"{displayLine,-25} -> {res}");
            }
        }

        static bool IsBalanced(string line)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (char ch in line)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.Count == 0 || stack.Peek() != pairs[ch])
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
          
            return stack.Count == 0;
        }
    }
}
