import random

N = 4
M = 6

users = {
    "sanya" : "1234",
    "vanya" : "4321",
    "danya" : "qwerty",
    "katya" : "ytrewq"
}


objects_access = {j: random.randint(0, 2) for j in range(M)}
users_access = {i: random.randint(0, 2) for i in users.keys()}
users_access["sanya"] = 2

print(users_access)
print(objects_access)

if __name__ == "__main__":
    choice = "choice"
    user = None
    password = None
    while choice.lower() != "exit":
        print("Здравствуйте. Авторизируйтесь пожалуйста")
        user = input()
        if user.lower() == "quit" or user.lower() == "exit":
            break

        if user in users.keys():
            print(f"Здравствуйте, {user}, введите ваш пароль")
            password = input()
            if password == users[user]:
                print(f"Добро пожаловать, {user}!")
                print(f"Ваши права доступа: {users_access[user]}\nВам доступны следующие файлы:")
                for key, value in objects_access.items():
                    if value <= users_access[user]:
                        print(f"Файл №{key + 1}")
                while True:
                    choice = input("Выберите файл")
                    if choice == "quit()":
                        break
                    if (users_access[user] >= objects_access[int(choice)-1]):
                        print("Успешно")
                    else:
                        print("Отказано")

