def find_triplets_with_sum(sum)-> list:
    triplets = []
    pythagorean_triples = []
    for a in range(1, sum):
        for b in range(a + 1, sum - a):
            c = sum - (a + b)
            if a< b < c:
                triplets.append((a, b, c))
                if a ** 2 + b ** 2 == c ** 2:
                    pythagorean_triples.append((a, b, c))
    return pythagorean_triples

# def find_pythagorean_triples(triplets: list)-> list:
#     pythagorean_triples= [];
#     for element in triplets:
#         if element[0] ** 2 + element[1] ** 2 == element[2] ** 2:
#             pythagorean_triples.append((element[0], element[1], element[2]))
#     return pythagorean_triples

if __name__ == '__main__':
    target_sum = 234
    triplets = find_triplets_with_sum(target_sum)
    print(triplets)
    # p_triplets = find_pythagorean_triples(triplets)
    # print(p_triplets)
