import random
import copy

N = 5
M = 12
t1, t2 = 10, 20

m = [[random.randint(t1, t2) for i in range(N)] for j in range(M)]
for arr in m:
    print(arr)
print("======")


def pow_sch_alg(matrix, proc_count, powder):
    c_matrix = copy.deepcopy(matrix)

    processors = [0 for _ in range(proc_count)]
    for i in range(len(c_matrix)):
        #t = list(map(lambda x: (sum(map(lambda y: y**powder, c_matrix[i]))) - processors[c_matrix[i].index(x)]**powder + (processors[c_matrix[i].index(x)]+x)**powder, c_matrix[i]))
        t = [0 for _ in range(proc_count)]
        for j in range(len(processors)):
            t[j] = (sum(list(map(lambda x: x**powder, processors)))) - (processors[j] ** powder) + ((c_matrix[i][j] + processors[j]) ** powder)

        # print(processors)
        # print(c_matrix[i])
        # print(t)
        min_i = t.index(min(t))

        # for j in range(i+1, len(c_matrix)):
        #     c_matrix[j][min_i] -= processors[min_i]

        processors[min_i] += c_matrix[i][min_i]

        for j in range(len(c_matrix[i])):
            if j != min_i:
                c_matrix[i][j] = 0

        # for j in range(i+1, len(c_matrix)):
        #     c_matrix[j][min_i] += processors[min_i]

        print(c_matrix[i])

    print("===\nResult")
    print(f"Load of processors: {processors}")
    # print(f"Schedule: {sch}")
    return c_matrix


def schedule_alg(matrix, proc_count):
    c_matrix = copy.deepcopy(matrix)

    processors = [0 for i in range(proc_count)]
    sch = [[] for i in range(proc_count)]
    for i in range(len(c_matrix)):
        min_i = c_matrix[i].index(min(c_matrix[i]))

        for j in range(i+1, len(c_matrix)):
            c_matrix[j][min_i] -= processors[min_i]

        processors[min_i] = c_matrix[i][min_i]
        for j in range(len(c_matrix[i])):
            if j != min_i:
                c_matrix[i][j] = 0

        for j in range(i+1, len(c_matrix)):
            c_matrix[j][min_i] += processors[min_i]

        print(c_matrix[i])
        # sch[min_i] += f"{c_matrix[i][min_i]} "

    print("===\nResult")
    print(f"Load of processors: {processors}")
    # print(f"Schedule: {sch}")
    return c_matrix


def to_down(matrix):
    c_matrix = copy.deepcopy(matrix)

    for j in matrix:
        for i in range(len(c_matrix)-1):
            if sum(c_matrix[i]) < sum(c_matrix[i+1]):
                c_matrix[i], c_matrix[i+1] = c_matrix[i+1], c_matrix[i]

    for arr in c_matrix:
        print(f"{arr} {sum(arr)}")
    print("===")
    return c_matrix


def to_up(matrix):
    c_matrix = matrix

    for j in matrix:
        for i in range(len(c_matrix)-1):
            if sum(c_matrix[i]) > sum(c_matrix[i+1]):
                c_matrix[i], c_matrix[i+1] = c_matrix[i+1], c_matrix[i]

    for arr in c_matrix:
        print(f"{arr} {sum(arr)}")
    print("===")
    return c_matrix


print("\nquad")
pow_sch_alg(to_up(copy.deepcopy(m)), N, 2)
#
# print("\nОтсортировано по убыванию")
# schedule_alg(to_down(copy.deepcopy(m)), N)
#
# print("\nПо возрастанию")
# schedule_alg(to_up(copy.deepcopy(m)), N)


