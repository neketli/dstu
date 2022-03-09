import random
import copy

N = 4
M = 8
t1, t2 = 10, 22

m = [[random.randint(t1, t2) for i in range(N)] for j in range(M)]
for arr in m:
    print(arr)
print("======")


def min_alg(matrix, proc_count):
    processors = [0 for i in range(proc_count)]
    sch = ["" for i in range(proc_count)]
    for arr in matrix:
        min_i = arr.index(min(arr))
        processors[min_i] += arr[min_i]
        sch[min_i] += f" {arr[min_i]}"

    for arr in matrix:
        print(f"{arr} {sum(arr)}")
    print(sch)
    print(processors)


def schedule_alg(matrix, proc_count):
    c_matrix = copy.deepcopy(matrix)
    processors = [0 for i in range(proc_count)]
    sch = ["" for i in range(proc_count)]
    for i in range(len(c_matrix)):
        min_i = c_matrix[i].index(min(c_matrix[i]))
        processors[min_i] = c_matrix[i][min_i]
        for j in range(len(c_matrix[i])):
            if j != min_i:
                c_matrix[i][j] = 0

        for j in range(i+1, len(c_matrix)):
            c_matrix[j][min_i] += c_matrix[i][min_i]
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


print("\n3.3")
schedule_alg(copy.deepcopy(m), N)

print("\nОтсортировано по убыванию")
schedule_alg(to_down(copy.deepcopy(m)), N)

print("\nПо возрастанию")
schedule_alg(to_up(copy.deepcopy(m)), N)

print("\nmin")
min_alg(copy.deepcopy(m), N)

