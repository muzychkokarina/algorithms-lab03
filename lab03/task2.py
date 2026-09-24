def main():

    transactions = [
        {"month": 1, "amount": 1500.0},
        {"month": 3, "amount": 2300.5},
        {"month": 1, "amount": 500.0},
        {"month": 12, "amount": 4100.0},
        {"month": 5, "amount": 800.0}
    ]
    
    monthly_totals = [0.0] * 12

    for t in transactions:
        month_index = t["month"] - 1
        monthly_totals[month_index] += t["amount"]

    print("--- Підсумки за місяцями ---")
    for month in range(12):
        print(f"Місяць {month + 1:2d}: {monthly_totals[month]:8.2f} грн")

if __name__ == "__main__":
    main()
