from typing import List
import matplotlib.pyplot as plt
import numpy as np


def get_input_numbers() -> list[int]:
    numbers_given = []
    while True:
        num = int(input("write num. -1 to finish"))
        if num == int(-1):
            break
        else:
            numbers_given.append(num)
    return numbers_given


def actions_on_numbers(numbers_given: list[int]):
    show_graph(numbers_given)
    numbers_given.sort()
    print(numbers_given)
    print(calc_avg(numbers_given))
    print(count_positives(numbers_given))


def calc_avg(numbers_given: list[int]) -> float:
    sum = 0
    for number in numbers_given:
        sum += number
    avg = sum / len(numbers_given)
    return avg


def count_positives(numbers_given: list[int]) -> int:
    counter = 0
    for number in numbers_given:
        if number > 0 and number != 0:
            counter = counter + 1
    return counter


def show_graph(numbers_given: list[int]) -> None:
    y = np.array([numbers_given])
    positions_x = []
    index = 0
    while index < len(numbers_given):
        positions_x.append(index+1)
        index = index + 1
    x = np.array([positions_x])

    plt.scatter(x, y)
    plt.show()


if __name__ == '__main__':
    numbers_list = get_input_numbers()
    print(numbers_list)
    actions_on_numbers(numbers_list)
