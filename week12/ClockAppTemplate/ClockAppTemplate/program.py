import tracemalloc
import time
from clock import Clock

def main():
    my_clock = Clock()
    num_ticks = 10000 

    tracemalloc.start() # Starts monitoring memory usage

    for _ in range(num_ticks):
        my_clock.tick()

    print(f"Current and peak memory used: {tracemalloc.get_traced_memory()}")

    tracemalloc.stop() 

    print(f"Time: {my_clock.get_time()}")
    
    my_clock.reset()
    print(f"Time after reset: {my_clock.get_time()}")



main()