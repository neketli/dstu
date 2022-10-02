from itertools import product

def first(n):
    data = ["0", "1"]
    l = data
    r = data
    counter = 0
    while n > counter:
        res = list(product(l, r))
        res = list(filter(lambda x: (len(x[0])+len(x[1])) % 2 == 0, res))
        res = list(map(lambda x: x[0]+x[1], res))
        if res:
            for el in res:
                print(el, end="\t")
                counter += 1
        if len(l) < len(r):
            l = list(product(l, data))
            l = list(map(lambda x: x[0]+x[1], l))
        else:
            r = list(product(r, data))
            r = list(map(lambda x: x[0] + x[1], r))


def second(n):
    data = ["0", "1.", "2"]
    f = data
    counter = 0
    i = 0
    while n > counter:
        res = list(product(f, repeat=i+1) )
        # res = list(map(lambda x: x[0]+x[1]+x[2], res))
        if res:
            for el in res:
                print("".join(el), end="  ")
                counter += 1
                if (counter == n):
                    break
        i += 1


if __name__ == "__main__":
    first(20)
    print("\n===")
    second(20)