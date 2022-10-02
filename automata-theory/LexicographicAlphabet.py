# Должен быть алфавит, порядок имеет значение, не должно быть цифр и символов (буквы либо англ либо рус)
# По слову вывести его номер
# По номеру вывести слово

def init_alphabet():
    char = '0'
    alphabet = []
    lang = ""
    while char:
        char = str(input("Введите букву алфавита или enter, чтобы завершить\n"))
        if len(char) > 1 or not char.isalpha():
            if not char:
                break
            print("Введите одну БУКВУ!")
            continue

        if 97 <= ord(char.lower()) <= 122 and (lang == "en" or lang == ""):
            if not lang:
                lang = "en"
            alphabet.append(char.lower())
        elif 1072 <= ord(char.lower()) <= 1103 and (lang == "ru" or lang == ""):
            if not lang:
                lang = "ru"
            alphabet.append(char.lower())
        else:
            continue
    return alphabet


# n**(k-(1 to k) * i(1 to k)
# n = len(alphabet) ; k = len(word) ; i - номер буквы в алфавите.

def lexicographic_numbering_to_num(alphabet, word):
    current_word = list(word)
    n = len(alphabet)
    k = len(current_word)

    for el in current_word:
        if el not in alphabet:
            return f"Буквы {el} нет в данном алфавите!"

    def find_number(i):
        if i == k - 1:
            print(alphabet.index(current_word[i]) + 1, end='')
            return alphabet.index(current_word[i]) + 1
        print(f"{n} ^ {k - (i + 1)} * {alphabet.index(current_word[i]) + 1} + ", end='')
        return (n ** (k - (i + 1)) * (alphabet.index(current_word[i]) + 1)) + find_number(i + 1)

    return " = " + str(find_number(0))


def lexicographic_numbering_to_word(alphabet, number):
    n = len(alphabet)
    code = []

    def find_word(acc):
        if acc // n == 0:
            print(f"0 * {n} + {acc // n}", end=" => ")
            code.append(acc % n)
            return acc % n
        if acc % n == 0:
            print(f"{(acc // n - 1)} * {n} + {n}", end=" => ")
            code.append(n)
            return find_word((acc // n - 1))
        print(f"{acc // n} * {n} + {acc % n}", end=" => ")
        code.append(acc % n)
        return find_word(acc // n)
    find_word(number)
    word = ""
    code.reverse()
    k = len(code)
    print("")
    for el in code:
        print(f"{el} * {n}^{k-1}", end='')
        k = k - 1
        if k != 0:
            print(" + ", end='')
    print(" =>\n=> ", end='')
    for el in code:
        word += alphabet[el - 1]

    return word


if __name__ == '__main__':
    alph = []
    choice = "choice"
    while choice:
        choice = input("Выберите один из пунктов:\n1. Ввести алфавит\n2. Слово в число\n3. Число в слово \n")
        if choice == "1":
            alph = init_alphabet()
        elif choice == "2":
            if not alph:
                alph = init_alphabet()
            word = input("Введите слово: ")
            print(lexicographic_numbering_to_num(alph, word))
        elif choice == "3":
            if not alph:
                alph = init_alphabet()
            while True:
                try:
                    number = int(input("Введите число: "))
                    break
                except ValueError:
                    print("Введите ЧИСЛО N: ")
            print(lexicographic_numbering_to_word(alph, number))
        else:
            print("Не пойдёт")

    print("До свидания")