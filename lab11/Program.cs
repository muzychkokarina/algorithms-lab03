using System;
using System.Collections.Generic;

namespace Lab11
{
    class Node
    {
        public string Title { get; set; }
        public List<Node> Children { get; set; }

        public Node(string title, List<Node> children = null)
        {
            Title = title;
            Children = children ?? new List<Node>();
        }
    }

    class Program
    {
        static int callCount = 0; // лічильник викликів countItems

        static void Main(string[] args)
        {
            // Дерево згідно із заготовкою
            Node menu = new Node("Головне меню", new List<Node>
            {
                new Node("Файл", new List<Node> { new Node("Новий"), new Node("Зберегти") }),
                new Node("Правка", new List<Node> { new Node("Копіювати") }),
                new Node("Вигляд", new List<Node> { new Node("Масштаб", new List<Node> { new Node("Збільшити"), new Node("Зменшити") }) }),
                new Node("Довідка")
            });

            Console.WriteLine("--- Функція 1: Виведення меню ---");
            PrintMenu(menu, 0);

            Console.WriteLine("\n--- Функція 2: Підрахунок пунктів ---");
            int totalItems = CountItems(menu);
            Console.WriteLine($"Усього пунктів меню: {totalItems}");
            Console.WriteLine($"Лічильник викликів callCount: {callCount}");

            Console.WriteLine("\n--- Функція 3: Пошук елементів ---");
            Console.WriteLine("find(menu, \"Зберегти\"): " + Find(menu, "Зберегти"));
            Console.WriteLine("find(menu, \"Масштаб\"): " + Find(menu, "Масштаб"));
            Console.WriteLine("find(menu, \"Довідка\"): " + Find(menu, "Довідка"));
            Console.WriteLine("find(menu, \"Експорт\"): " + Find(menu, "Експорт"));
        }

        // TODO 1: Вивести всю ієрархію з відступом у 2 пробіли на рівень
        static void PrintMenu(Node node, int level = 0)
        {
            if (node == null) return;

            string indent = new string(' ', level * 2);
            Console.WriteLine(indent + node.Title);

            foreach (var child in node.Children)
            {
                PrintMenu(child, level + 1);
            }
        }

        // TODO 2: Повернути кількість усіх пунктів (разом із самим вузлом)
        static int CountItems(Node node)
        {
            callCount++;
            if (node == null) return 0;

            int count = 1; // сам вузол
            foreach (var child in node.Children)
            {
                count += CountItems(child);
            }
            return count;
        }

        // TODO 3: Повернути true, якщо в дереві є пункт із такою назвою
        static bool Find(Node node, string name)
        {
            if (node == null) return false;

            if (node.Title == name)
                return true;

            foreach (var child in node.Children)
            {
                if (Find(child, name))
                    return true;
            }

            return false;
        }
    }
}
