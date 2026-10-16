using System;
using System.Collections.Generic;

namespace Lab07
{
    class Request
    {
        public string Name { get; set; }
        public int Minutes { get; set; }

        public Request(string name, int minutes)
        {
            Name = name;
            Minutes = minutes;
        }
    }

    class Task2_Queue
    {
        static void Main(string[] args)
        {
            List<Request> requests = new List<Request>
            {
                new Request("Довідка про навчання", 4),
                new Request("Академічна відпустка", 7),
                new Request("Копія наказу", 2),
                new Request("Виписка з оцінками", 6),
                new Request("Перескладання", 9),
                new Request("Студентський квиток", 3)
            };

            Console.WriteLine("--- Задача 2: Обробка заявок (Черга) ---");
            ProcessQueue(requests);
        }

        static int ProcessQueue(List<Request> reqList)
        {
            if (reqList == null || reqList.Count == 0)
            {
                Console.WriteLine("Немає заявок для обробки (черга порожня).");
                return 0;
            }

            Queue<Request> queue = new Queue<Request>(reqList);
            int currentTime = 0;
            int processedCount = 0;

            while (queue.Count > 0)
            {
                Request req = queue.Dequeue();
                int startTime = currentTime;
                int endTime = startTime + req.Minutes;
                currentTime = endTime;
                processedCount++;

                Console.WriteLine($"{processedCount}. {req.Name,-25} з {startTime} до {endTime} хв");
            }

            Console.WriteLine($"\nОброблено заявок: {processedCount}, загальний час: {currentTime} хв");
            return currentTime;
        }
    }
}
