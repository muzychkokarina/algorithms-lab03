using System;
using System.Collections.Generic;

namespace Lab12
{
    class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    class Program
    {
        static int compareCount = 0; // лічильник порівнянь

        static void Main(string[] args)
        {
            Node root = null;
            int[] values = { 42, 18, 65, 9, 27, 55, 90, 33 };

            // Вставка елементів
            foreach (int val in values)
            {
                root = Insert(root, val);
            }

            Console.WriteLine("--- Функція 3: Симетричний обхід (Inorder) ---");
            Inorder(root);
            Console.WriteLine();

            Console.WriteLine("\n--- Функція 2: Пошук у дереві ---");
            
            // Пошук 55
            compareCount = 0;
            bool found55 = Search(root, 55);
            int comp55 = compareCount;
            Console.WriteLine($"search(root, 55): {found55}, порівнянь: {comp55}");

            // Пошук 30
            compareCount = 0;
            bool found30 = Search(root, 30);
            int comp30 = compareCount;
            Console.WriteLine($"search(root, 30): {found30}, порівнянь: {comp30}");

            Console.WriteLine("\n--- Перевірка повторної вставки 27 ---");
            root = Insert(root, 27);
            int countNodes = CountNodes(root);
            Console.WriteLine($"Вузлів після повторної вставки числа 27: {countNodes}");
        }

        // TODO 1: Вставити число в дерево; якщо воно вже є — нічого не робити
        static Node Insert(Node node, int key)
        {
            if (node == null)
            {
                return new Node(key);
            }

            if (key < node.Value)
            {
                node.Left = Insert(node.Left, key);
            }
            else if (key > node.Value)
            {
                node.Right = Insert(node.Right, key);
            }

            return node;
        }

        // TODO 2: Повернути true, якщо число є в дереві; рахувати порівняння
        static bool Search(Node node, int key)
        {
            if (node == null)
            {
                return false;
            }

            compareCount++;

            if (key == node.Value)
            {
                return true;
            }
            else if (key < node.Value)
            {
                return Search(node.Left, key);
            }
            else
            {
                return Search(node.Right, key);
            }
        }

        // TODO 3: Надрукувати всі числа дерева за зростанням
        static void Inorder(Node node)
        {
            if (node == null) return;

            Inorder(node.Left);
            Console.Write(node.Value + " ");
            Inorder(node.Right);
        }

        // Допоміжна функція для підрахунку вузлів у дереві
        static int CountNodes(Node node)
        {
            if (node == null) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
    }
}
