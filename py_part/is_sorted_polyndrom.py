def is_sorted_polyndrom(could_be_polyndrom: str) -> bool:
    first = could_be_polyndrom[0]
    if could_be_polyndrom[len(could_be_polyndrom) - 1] != first:
        return False
    i = 1
    while i < len(could_be_polyndrom) / 2:
        if (could_be_polyndrom[i] != could_be_polyndrom[len(could_be_polyndrom) - 1 - i]) or (
                could_be_polyndrom[i] < first):
            return False
        first = could_be_polyndrom[i]
        i= i+1
    return True


if __name__ == '__main__':
    print(is_sorted_polyndrom("abcdcba"))
