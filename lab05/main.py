# ЛАБОРАТОРНА 5. Сортування об'єктів

class Student:
    def __init__(self, surname: str, group: str, grade: float, year: int):
        self.surname = surname
        self.group = group
        self.grade = grade
        self.year = year

    def __repr__(self):
        return f"{self.surname:10} | {self.group:7} | {self.grade:<4} | {self.year}"

students = [
    Student("Ткаченко",  "ІПЗ-3/1", 85, 2024),
    Student("Бондар",    "ІПЗ-3/2", 92, 2023),
    Student("Іваненко",  "ІПЗ-3/1", 85, 2024),
    Student("Коваль",    "ІПЗ-3/2", 78, 2024),
    Student("Сидоренко", "ІПЗ-3/1", 85, 2023),
    Student("Мельник",   "ІПЗ-3/2", 92, 2024),
    Student("Гриценко",  "ІПЗ-3/1", 78, 2023),
    Student("Дяченко",   "ІПЗ-3/2", 85, 2023),
]

def printAll(title, items):
    print(f"\n=== {title} ===")
    for s in items:
        print(f"{s.surname:10} {s.group:7} {s.grade:<4} {s.year}")

if __name__ == "__main__":
    # TODO 1: за прізвищем, за абеткою
    by_surname = sorted(students, key=lambda s: s.surname)
    printAll("1. За прізвищем (за абеткою)", by_surname)

    # TODO 2: за балом, від вищого до нижчого
    by_grade = sorted(students, key=lambda s: s.grade, reverse=True)
    printAll("2. За балом (від вищого до нижчого)", by_grade)

    # TODO 3: за групою, а всередині групи — за балом від вищого
    by_group_then_grade = sorted(students, key=lambda s: (s.group, -s.grade))
    printAll("3. За групою, а всередині — за балом від вищого", by_group_then_grade)

    # Частина 2: за балом (від вищого), а за однакових балів — за абеткою
    by_grade_then_surname = sorted(students, key=lambda s: (-s.grade, s.surname))
    printAll("4. За балом (від вищого), а для однакових — за абеткою", by_grade_then_surname)
