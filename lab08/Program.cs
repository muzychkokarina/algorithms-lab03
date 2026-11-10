using System;
using System.Collections.Generic;

namespace Lab08
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Client(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Order
    {
        public int Number { get; set; }
        public int ClientId { get; set; }
        public int Sum { get; set; }

        public Order(int number, int clientId, int sum)
        {
            Number = number;
            ClientId = clientId;
            Sum = sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>
            {
                new Client(101, "Коваленко"),
                new Client(102, "Мельник"),
                new Client(103, "Шевчук"),
                new Client(104, "Бондар"),
                new Client(105, "Ткачук"),
                new Client(106, "Гриценко")
            };

            List<Order> orders = new List<Order>
            {
                new Order(1, 103, 450),  new Order(2, 101, 120),
                new Order(3, 105, 980),  new Order(4, 103, 300),
                new Order(5, 102,  75),  new Order(6, 106, 1500),
                new Order(7, 101, 220),  new Order(8, 103,  60)
            };

            List<int> blockedList = new List<int> { 102, 104 };

            var clientDict = new Dictionary<int, string>();
            foreach (var client in clients)
            {
                clientDict[client.Id] = client.Name;
            }

            foreach (var order in orders)
            {
                if (clientDict.TryGetValue(order.ClientId, out var clientName))
                {
                    Console.WriteLine("Замовлення " + order.Number + " — " + clientName);
                }
            }

            var blockedSet = new HashSet<int>(blockedList);
            int total = 0;
            foreach (var order in orders)
            {
                if (!blockedSet.Contains(order.ClientId))
                {
                    total += order.Sum;
                }
            }
            Console.WriteLine("Сума прийнятих замовлень: " + total);

            var orderCounts = new Dictionary<int, int>();
            foreach (var order in orders)
            {
                if (orderCounts.ContainsKey(order.ClientId))
                    orderCounts[order.ClientId]++;
                else
                    orderCounts[order.ClientId] = 1;
            }

            var printed = new HashSet<int>();
            foreach (var order in orders)
            {
                if (!printed.Contains(order.ClientId))
                {
                    printed.Add(order.ClientId);
                    Console.WriteLine(order.ClientId + ": " + orderCounts[order.ClientId]);
                }
            }

            Order best = orders[0];
            foreach (var order in orders)
            {
                if (order.Sum > best.Sum)
                    best = order;
            }
            Console.WriteLine("Найбільше замовлення: " + best.Sum);

            foreach (var order in orders)
            {
                Console.WriteLine("Замовлення " + order.Number + " — " + clientDict[order.ClientId]);
            }
        }
    }
}
