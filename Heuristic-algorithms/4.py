import random
import copy

N = 3
M = 12
t1, t2 = 10, 22

m = [[random.randint(t1, t2) for i in range(N)] for j in range(M)]
for arr in m:
    print(arr)
print("======")


def barrier_alg(matrix, proc_count):
    barrier = 0
    processors = [0 for _ in range(proc_count)]
    c_matrix = copy.deepcopy(matrix)
    for arr in matrix:
        barrier += min(arr)
    barrier = barrier/proc_count
    print(f"Барьер: {barrier}")
    i = 0
    while max(processors) < barrier:
        if i == len(c_matrix):
            return processors
        min_i = c_matrix[i].index(min(c_matrix[i]))
        processors[min_i] += c_matrix[i][min_i]
        for j in range(len(c_matrix[i])):
            if j != min_i:
                c_matrix[i][j] = 0
        print(c_matrix[i])
        i += 1

    for j in range(0, proc_count):
        for k in range(0, len(c_matrix)):
            c_matrix[k][j] += processors[j]

    while i < len(c_matrix):
        min_i = c_matrix[i].index(min(c_matrix[i]))

        for j in range(i + 1, len(c_matrix)):
            c_matrix[j][min_i] -= processors[min_i]

        processors[min_i] = c_matrix[i][min_i]
        for j in range(len(c_matrix[i])):
            if j != min_i:
                c_matrix[i][j] = 0

        for j in range(i + 1, len(c_matrix)):
            c_matrix[j][min_i] += processors[min_i]

        print(c_matrix[i])
        i += 1

    print("===\nResult")
    print(f"Load of processors: {processors}")
    return processors

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


#print("\nБарьер")
barrier_alg(copy.deepcopy(m), N)
#
print("\nОтсортировано по убыванию")
barrier_alg(to_down(copy.deepcopy(m)), N)
#
#print("\nПо возрастанию")
#barrier_alg(to_up(copy.deepcopy(m)), N)

