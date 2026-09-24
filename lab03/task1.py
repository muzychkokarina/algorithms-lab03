def main():
    
    logs = [
        "2026-09-24 10:00: System Started",
        "2026-09-24 10:05: User logged in",
        "2026-09-24 10:15: File downloaded",
        "2026-09-24 10:20: User logged out"
    ]
    
    log_list = []
    for entry in logs:
        log_list.append(entry)
        
    print("--- Журнал подій (у зворотному порядку) ---")
    for i in range(len(log_list) - 1, -1, -1):
        print(log_list[i])

if __name__ == "__main__":
    main()
