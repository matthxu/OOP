from counter import Counter

class Clock:
    def __init__(self):
        self._hours = Counter("Hours")
        self._minutes = Counter("Minutes")
        self._seconds = Counter("Seconds")

    def tick(self):
        self._seconds.increment()
        if self._seconds.ticks == 60:
            self._seconds.reset()
            self._minutes.increment()
            if self._minutes.ticks == 60:
                self._minutes.reset()
                self._hours.increment()
                if self._hours.ticks == 12:
                    self._hours.reset()

    def get_time(self) -> str:
        # The :02 ensures two digits with leading zero if needed
        return f"{self._hours.ticks:02}:{self._minutes.ticks:02}:{self._seconds.ticks:02}"

    def reset(self):
        self._hours.reset()
        self._minutes.reset()
        self._seconds.reset()