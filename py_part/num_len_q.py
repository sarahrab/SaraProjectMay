import math


def num_len(num: int) -> int: return int(math.log10(abs(num))) + 1 if num != 0 else 1


if __name__ == '__main__':
    print(num_len(2221222))
