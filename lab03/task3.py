def main():
    N = 5
    buffer = [None] * N
    write_index = 0
    count = 0 
    
    events_stream = [
        "Подія 1", "Подія 2", "Подія 3", "Подія 4", 
        "Подія 5", "Подія 6", "Подія 7"
    ]

    for event in events_stream:
        buffer[write_index] = event
        write_index = (write_index + 1) % N
        count += 1

    print(f"--- Останні {N} подій ---")
    total_stored = min(count, N)

    start_index = (write_index - total_stored + N) % N
    
    for i in range(total_stored):
        curr_index = (start_index + i) % N
        print(buffer[curr_index])

if __name__ == "__main__":
    main()
