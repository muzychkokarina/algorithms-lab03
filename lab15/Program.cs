using System;
using System.Collections.Generic;

namespace Lab15
{
    class Program
    {
        static List<string> TopoSort(
            Dictionary<string, List<string>> before,
            Dictionary<string, List<string>> after)
        {
            var incoming = new Dictionary<string, int>();

            foreach (var item in before)
            {
                incoming[item.Key] = item.Value.Count;
            }

            var queue = new Queue<string>();

            foreach (var item in incoming)
            {
                if (item.Value == 0)
                {
                    queue.Enqueue(item.Key);
                }
            }

            var order = new List<string>();
            while (queue.Count > 0)
            {
                string v = queue.Dequeue();
                order.Add(v);

                foreach (string next in after[v])
                {
                    incoming[next]--;
                    if (incoming[next] == 0)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            return order;
        }
        static bool HasCycle(
            Dictionary<string, List<string>> before,
            Dictionary<string, List<string>> after)
        {
            var order = TopoSort(before, after);
            return order.Count < before.Count;
        }

        static void Main()
        {
            var beforeA = new Dictionary<string, List<string>>
            {
                ["Вступ"]         = new List<string>(),
                ["Математика"]    = new List<string>(),
                ["ООП"]           = new List<string> { "Вступ" },
                ["Бази даних"]    = new List<string> { "Вступ" },
                ["Алгоритми"]     = new List<string> { "Вступ", "Математика" },
                ["Вебтехнології"] = new List<string> { "ООП", "Бази даних" },
                ["Курсовий"]      = new List<string> { "Алгоритми", "Вебтехнології" }
            };

            var afterA = new Dictionary<string, List<string>>
            {
                ["Вступ"]         = new List<string> { "ООП", "Бази даних", "Алгоритми" },
                ["Математика"]    = new List<string> { "Алгоритми" },
                ["ООП"]           = new List<string> { "Вебтехнології" },
                ["Бази даних"]    = new List<string> { "Вебтехнології" },
                ["Алгоритми"]     = new List<string> { "Курсовий" },
                ["Вебтехнології"] = new List<string> { "Курсовий" },
                ["Курсовий"]      = new List<string>()
            };

            var beforeB = new Dictionary<string, List<string>>
            {
                ["Вступ"]         = new List<string>(),
                ["Математика"]    = new List<string>(),
                ["ООП"]           = new List<string> { "Вступ" },
                ["Бази даних"]    = new List<string> { "Вступ", "Вебтехнології" },
                ["Алгоритми"]     = new List<string> { "Вступ", "Математика" },
                ["Вебтехнології"] = new List<string> { "ООП", "Бази даних" },
                ["Курсовий"]      = new List<string> { "Алгоритми", "Вебтехнології" }
            };

            var afterB = new Dictionary<string, List<string>>
            {
                ["Вступ"]         = new List<string> { "ООП", "Бази даних", "Алгоритми" },
                ["Математика"]    = new List<string> { "Алгоритми" },
                ["ООП"]           = new List<string> { "Вебтехнології" },
                ["Бази даних"]    = new List<string> { "Вебтехнології" },
                ["Алгоритми"]     = new List<string> { "Курсовий" },
                ["Вебтехнології"] = new List<string> { "Курсовий", "Бази даних" },
                ["Курсовий"]      = new List<string>()
            };

            var orderA = TopoSort(beforeA, afterA);
            Console.WriteLine("=== Набір А ===");
            Console.WriteLine("Кількість предметів: " + orderA.Count);
            Console.WriteLine("Порядок: " + string.Join(" -> ", orderA));
            Console.WriteLine("hasCycle(А): " + HasCycle(beforeA, afterA));

            var orderB = TopoSort(beforeB, afterB);
            Console.WriteLine("\n=== Набір Б ===");
            Console.WriteLine("Кількість предметів: " + orderB.Count);
            Console.WriteLine("Порядок: " + string.Join(" -> ", orderB));
            Console.WriteLine("hasCycle(Б): " + HasCycle(beforeB, afterB));

            var missingB = new List<string>();
            foreach (var subject in beforeB.Keys)
            {
                if (!orderB.Contains(subject))
                    missingB.Add(subject);
            }
            Console.WriteLine("Не потрапили в Б: " + string.Join(", ", missingB));
        }
    }
}
