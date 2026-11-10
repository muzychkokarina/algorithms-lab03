using System;
using System.Collections.Generic;

namespace Lab10
{
    class Request
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Seq { get; set; }

        public Request(string name, int priority, int seq)
        {
            Name = name;
            Priority = priority;
            Seq = seq;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Request> incoming = new List<Request>
            {
                new Request("Оновити підпис у листі", 3, 1),
                new Request("Сервер не відповідає", 1, 2),
                new Request("Не друкує принтер", 2, 3),
                new Request("Не працює термінал оплати", 1, 4),
                new Request("Змінити шпалери", 3, 5)
            };

            Request late = new Request("Відвалився інтернет у відділі", 1, 6);

            Console.WriteLine("--- Задача 1: Обробити за пріоритетом ---");
            ProcessAll(incoming);

            Console.WriteLine("\n--- Задача 2: Зробити порядок передбачуваним ---");
            ProcessStable(incoming);

            Console.WriteLine("\n--- Задача 3: Заявка, що надійшла посеред обробки ---");
            ProcessWithLate(incoming, late);
        }

        // TODO 1: Ключ — тільки priority (PriorityQueue мінімізує пріоритет за замовчуванням)
        static void ProcessAll(List<Request> incoming)
        {
            var pq = new PriorityQueue<Request, int>();

            foreach (var req in incoming)
            {
                pq.Enqueue(req, req.Priority);
            }

            int step = 1;
            while (pq.Count > 0)
            {
                var req = pq.Dequeue();
                Console.WriteLine($"{step}. {req.Name} (Пріоритет: {req.Priority}, seq: {req.Seq})");
                step++;
            }
        }

        // TODO 2: Складений ключ — (Priority, Seq) через ValueTuple
        static void ProcessStable(List<Request> incoming)
        {
            var pq = new PriorityQueue<Request, (int Priority, int Seq)>();

            foreach (var req in incoming)
            {
                pq.Enqueue(req, (req.Priority, req.Seq));
            }

            int step = 1;
            while (pq.Count > 0)
            {
                var req = pq.Dequeue();
                Console.WriteLine($"{step}. {req.Name} (Пріоритет: {req.Priority}, seq: {req.Seq})");
                step++;
            }
        }

        // TODO 3: Обробка двох заявок, потім додавання late і продовження
        static void ProcessWithLate(List<Request> incoming, Request late)
        {
            var pq = new PriorityQueue<Request, (int Priority, int Seq)>();

            foreach (var req in incoming)
            {
                pq.Enqueue(req, (req.Priority, req.Seq));
            }

            int step = 1;

            // Обробка перших двох заявок
            for (int i = 0; i < 2 && pq.Count > 0; i++)
            {
                var req = pq.Dequeue();
                Console.WriteLine($"{step}. {req.Name} (Пріоритет: {req.Priority}, seq: {req.Seq})");
                step++;
            }

            // Надійшла заявка late
            pq.Enqueue(late, (late.Priority, late.Seq));

            // Обробка решти заявок
            while (pq.Count > 0)
            {
                var req = pq.Dequeue();
                Console.WriteLine($"{step}. {req.Name} (Пріоритет: {req.Priority}, seq: {req.Seq})");
                step++;
            }
        }
    }
}
