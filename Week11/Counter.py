class Counter:
    def __init__(self, name):
        self._name = name
        self._count = 0

    def increment(self):
        self._count += 1
        return self._count
    
    def reset(self):
        self._count = 0
        return self._count
    
    @property
    def tick(self):
        return self._count
    
    @property
    def name(self):
        return self._name
    
    @name.setter
    def name(self, value):
        self._name = value