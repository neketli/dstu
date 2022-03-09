import random

N = 4
M = 6

users = {
    "sanya" : "1234",
    "vanya" : "4321",
    "danya" : "qwerty",
    "katya" : "ytrewq"
}

access = [{i: f"{random.randint(0, 7):03b}" for i in users.keys()} for j in range(M)]
for i in range(M):
    access[i]["sanya"] = "111"

for d in access:
    print(d)

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
                while choice.lower():

                    print("Перечень ваших прав:")
                    for i in range(len(access)):
                        s = ""
                        if access[i][user][2] == "1":
                            s += "Передача "
                        if access[i][user][1] == "1":
                            s += "Запись "
                        if access[i][user][0] == "1":
                            s += "Чтение "
                        if s == "":
                            s = "Нет прав"
                        print(f"file #{i+1} {s}")
                    choice = input("Выберите файл / для выхода из системы введите quit: ")
                    if choice.lower() == "quit" or choice.lower() == "exit":
                        break

                    if 0 <= int(choice)-1 <= len(access):
                        t = int(choice)-1
                        a = []
                        print("===")
                        if access[t][user][2] == "1":
                            print("Возможна передача прав | grant")
                            a.append("grant")
                        if access[t][user][1] == "1":
                            print("Возможна запись | write")
                            a.append("write")
                        if access[t][user][0] == "1":
                            print("Возможно чтение | read")
                            a.append("read")
                        if access[t][user] == 0:
                            print("Нет доступа")
                        print("===")

                        choice = input("выберите действие: ")
                        if choice.lower() in a:
                            if choice == "grant":
                                print("Какие права хотете передать?")
                                r = input("Ответ: ")
                                if r.lower() in a:
                                    print("Кому хотите передать?")
                                    print(users.keys())
                                    choice = input("Ответ: ")
                                    if choice.lower() in users.keys():
                                        temp = list(access[t][choice.lower()])
                                        print(temp)
                                        if r == "read":
                                            temp[0] = "1"
                                        if r == "write":
                                            temp[1] = "1"
                                        access[t][choice.lower()] = "".join(temp)
                                        print("Успех")

                                    else:
                                        print("Нет такого")


                            else:
                                print("Успешно\n")
                        else:
                            print("Нет доступа!\n")