import requests


# def reverse_n_pi_digits(n:int) -> str:
#     pi_digits_until_n = ""
#     url = "http://www.geom.uiuc.edu/~huberty/math5337/groupe/digits.html"
#     response = requests.get(url)
#     if response.status_code == 200:
#         html = response.text
#         pi_str = html.split("<br>")[1]
#         i = 0
#         while pi_str[i] != '3':
#             i = i + 1
#         index= n + 1 + i
#         while index >=0:
#             if index != 1:
#                 pi_digits_until_n += pi_str[index]
#             index = index-1
#         return pi_digits_until_n
#     else:
#         print("response status not succeeded")
#         return "try again"


def reverse_n_pi_digits2(n:int) -> str:
    pi_str = requests.get("http://www.geom.uiuc.edu/~huberty/math5337/groupe/digits.html").text.split("<br>")[1]
    url = "http://www.geom.uiuc.edu/~huberty/math5337/groupe/digits.html"
    return "".join(pi_str[index] for index in range(n + 1 + next(i for i, digit in enumerate(pi_str) if digit == '3'), -1, -1) if index != 1) if requests.get(url).status_code == 200 else "try again"


if __name__ == '__main__':
        n = int(input("Enter the number of Pi digits you want to retrieve:"))
        pi_digits = reverse_n_pi_digits2(n)
        if pi_digits:
            print(pi_digits)
