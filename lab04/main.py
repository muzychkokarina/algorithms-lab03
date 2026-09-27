# ЛАБОРАТОРНА 4. Пошук у даних

data = [42, 8, 60, 19, 3, 55, 12, 31, 68, 24, 49, 37, 71, 5, 27]
sortedData = sorted(data)

comparisons = 0

def linearSearch(items, target):
    global comparisons
    for i in range(len(items)):
        comparisons += 1
        if items[i] == target:
            return i
    return -1

def binarySearch(items, target):
    global comparisons
    low = 0
    high = len(items) - 1
    while low <= high:
        mid = (low + high) // 2
        comparisons += 1
        if items[mid] == target:
            return mid
        elif items[mid] < target:
            low = mid + 1
        else:
            high = mid - 1
    return -1

def report(name, items, target):
    global comparisons
    comparisons = 0
    index = linearSearch(items, target) if name == "linear" else binarySearch(items, target)
    print(f"{name:6} | target: {target:2} | index: {index:2} | comparisons: {comparisons}")

if __name__ == "__main__":
    print("=== ПЕРЕВІРКА НА ВІДСОРТОВАНИХ ДАНИХ ===")
    test_cases = [
        ("Значення стоїть першим", sortedData, 3),
        ("Значення стоїть останнім", sortedData, 71),
        ("Значення посередині", sortedData, 31),
        ("Відсутнє, менше за всі", sortedData, 1),
        ("Відсутнє, більше за всі", sortedData, 99),
        ("Відсутнє, між сусідніми", sortedData, 50),
        ("Масив з одного елемента [42]", [42], 42),
        ("Порожній масив []", [], 42)
    ]
    
    for title, arr, target in test_cases:
        print(f"\nCase: {title}")
        report("linear", arr, target)
        report("binary", arr, target)

    print("\n=== ЕКСПЕРИМЕНТ З НЕВІДСОРТОВАНИМИ ДАНИМИ ===")
    report("binary", data, 55)
