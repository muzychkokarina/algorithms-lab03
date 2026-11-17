using System;
using System.Collections.Generic;

namespace Lab14
{
    class Program
    {
        static HashSet<string> VisitAll(Dictionary<string, List<string>> graph, string start)
        {
            var visited = new HashSet<string>();
            if (!graph.ContainsKey(start)) return visited;

            var queue = new Queue<string>();
            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                foreach (string neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return visited;
        }

        static bool Reachable(Dictionary<string, List<string>> graph, string from, string to)
        {
            var visited = VisitAll(graph, from);
            return visited.Contains(to);
        }

        static List<string> FindPath(Dictionary<string, List<string>> graph, string from, string to)
        {
            if (!graph.ContainsKey(from) || !graph.ContainsKey(to))
                return new List<string>();

            var visited = new HashSet<string> { from };
            var parent = new Dictionary<string, string>();
            var queue = new Queue<string>();
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                if (current == to) break;

                foreach (string neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parent[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            if (!visited.Contains(to))
                return new List<string>();

            var path = new List<string>();
            string curr = to;
            while (curr != null)
            {
                path.Add(curr);
                parent.TryGetValue(curr, out curr);
            }

            path.Reverse();
            return path;
        }

        static void Main()
        {
            var graph = new Dictionary<string, List<string>>
            {
                ["Центр"]   = new List<string> { "Парк", "Ринок" },
                ["Парк"]    = new List<string> { "Центр", "Вокзал" },
                ["Ринок"]   = new List<string> { "Центр", "Вокзал", "Стадіон" },
                ["Вокзал"]  = new List<string> { "Парк", "Ринок", "Озеро" },
                ["Стадіон"] = new List<string> { "Ринок" },
                ["Озеро"]   = new List<string> { "Вокзал" },
                ["Гай"]     = new List<string> { "Міст" },
                ["Міст"]    = new List<string> { "Гай" }
            };

            Console.WriteLine("visitAll(\"Центр\"): " + VisitAll(graph, "Центр").Count);
            Console.WriteLine("reachable(\"Центр\", \"Озеро\"): " + Reachable(graph, "Центр", "Озеро"));
            Console.WriteLine("reachable(\"Центр\", \"Гай\"): " + Reachable(graph, "Центр", "Гай"));
            Console.WriteLine("reachable(\"Гай\", \"Міст\"): " + Reachable(graph, "Гай", "Міст"));
            Console.WriteLine("findPath(\"Центр\", \"Озеро\"): " + string.Join(" -> ", FindPath(graph, "Центр", "Озеро")));
            Console.WriteLine("findPath(\"Центр\", \"Стадіон\"): " + string.Join(" -> ", FindPath(graph, "Центр", "Стадіон")));
            Console.WriteLine("findPath(\"Центр\", \"Міст\"): [" + string.Join(", ", FindPath(graph, "Центр", "Міст")) + "]");
        }
    }
}
