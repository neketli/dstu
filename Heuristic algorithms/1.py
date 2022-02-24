import random

# Critical Method Path

# N - count of processors
# M - count of tasks
# T - priority

N = 3
M = random.randint(30, 35)
T = [random.randint(35, 40) for i in range(M)]
print(f"n = {N}\nm = {M}\nT = {T}")


def quicksort(nums):
    if len(nums) <= 1:
        return nums
    else:
        q = random.choice(nums)
    l_nums = [n for n in nums if n > q]

    e_nums = [q] * nums.count(q)
    b_nums = [n for n in nums if n < q]
    return quicksort(l_nums) + e_nums + quicksort(b_nums)


# n - count of processors, t - list of tasks priority
def cmp(n, t):
    lst = quicksort(t)
    state = [0 for i in range(n)]
    for el in lst:
        print(f"{el} => {state.index(min(state))} || {state}")
        state[state.index(min(state))] += el
    return state


if __name__ == "__main__":
    print(cmp(N, M, T))
