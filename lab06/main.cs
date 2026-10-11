using System;
using System.Collections.Generic;

class Category
{
    public string Name { get; set; }
    public int Products { get; set; }
    public List<Category> Children { get; set; }

    public Category(string name, int products, List<Category> children = null)
    {
        Name = name;
        Products = products;
        Children = children ?? new List<Category>();
    }
}

class Program
{
    static int callCount = 0;

    static void PrintTree(Category node, int level = 0)
    {
        callCount++;

        Console.WriteLine(new string(' ', level * 2) + node.Name);
        foreach (var child in node.Children)
        {
            PrintTree(child, level + 1);
        }
    }

    static int CountProducts(Category node)
    {
        callCount++;

        int total = node.Products;
        foreach (var child in node.Children)
        {
            total += CountProducts(child);
        }
        return total;
    }

    static int MaxDepth(Category node)
    {
        callCount++;

        if (node.Children == null || node.Children.Count == 0)
            return 1;

        int maxChildDepth = 0;
        foreach (var child in node.Children)
        {
            int childDepth = MaxDepth(child);
            if (childDepth > maxChildDepth)
            {
                maxChildDepth = childDepth;
            }
        }
        return 1 + maxChildDepth;
    }

    static void Main()
    {
        var catalog = new Category("Каталог", 0, new List<Category>
        {
            new Category("Одяг", 0, new List<Category>
            {
                new Category("Верхній одяг", 0, new List<Category>
                {
                    new Category("Куртки", 12),
                    new Category("Пальта", 7)
                }),
                new Category("Светри", 15)
            }),
            new Category("Взуття", 4, new List<Category>
            {
                new Category("Кросівки", 23),
                new Category("Чоботи", 9)
            }),
            new Category("Аксесуари", 0, new List<Category>
            {
                new Category("Сумки", 18),
                new Category("Ремені", 5)
            })
        });

        callCount = 0;
        PrintTree(catalog);

        callCount = 0;
        int totalProducts = CountProducts(catalog);

        callCount = 0;
        int depth = MaxDepth(catalog);
    }
}
