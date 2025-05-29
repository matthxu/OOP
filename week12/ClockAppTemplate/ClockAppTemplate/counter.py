class Counter:
    def __init__(self, name: str):
        self._name = name
        self._count = 0

    @property
    def name(self) -> str:
        return self._name

    @name.setter
    def name(self, value: str):
        self._name = value

    @property
    def ticks(self) -> int:
        return self._count

    def increment(self):
        self._count += 1

    def reset(self):
        self._count = 0
