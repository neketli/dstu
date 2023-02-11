from prettytable import PrettyTable


def e_path(mas, dict1, key, eps_mas):
    if chr(949) in [el[-1] for el in dict1[key] if
                    el[-1] == chr(949)]:  # [el for el in dict1[key] if el[-1] == chr(949)] - значения с ε
        for element in [el[:2] for el in dict1[key] if el[-1] == chr(949)]:
            eps_mas.append(element)
        eps_mas = set(eps_mas)
        eps_mas = list(eps_mas)
        element = eps_mas[0]
        if len(eps_mas) == 0:
            return mas
        eps_mas.remove(element)
        mas.append(element)
        key = element
        return e_path(mas, dict1, key, eps_mas)
    else:
        return mas


def s_points_create(dict1):  # использую e_path для поиска путей эпсилон
    mas = [[] for _ in range(len(dict1))]
    check = [[] for _ in range(len(dict1))]
    for num, val in enumerate(dict1):
        if chr(949) in [el[-1] for el in dict1[val] if el[-1] == chr(949)]:
            check[num].append(1)
    sum_ = sum([sum(elem) for elem in check])
    if sum_ != len(dict1):
        for i, key in enumerate(dict1):
            value = e_path([], dict1, key, [])
            if len(value) != 0:
                mas[i].append(f'q{i}')
                for el in value:
                    mas[i].append(el)
            else:
                mas[i].append(f'q{i}')
        new_dict = {f'S{_}': set(mas[_]) for _ in range(len(mas))}
        return new_dict
    else:
        return {f'S{_}': {f'q{i}' for i in range(len(dict1))} for _ in range(len(dict1))}


def beautiful_table(head, values):
    columns = len(head)  # Подсчитаем кол-во столбцов на будущее.
    table = PrettyTable(head)  # Определяем таблицу.
    # Cкопируем список td, на случай если он будет использоваться в коде дальше.
    td_data = values[:]  # Входим в цикл который заполняет нашу таблицу. Цикл будет выполняться до тех пор пока
    # у нас не кончатся данные для заполнения строк таблицы (список td_data).
    while td_data:
        table.add_row(td_data[:columns])  # Используя срез добавляем первые три элементов в строку (columns = 3).
        td_data = td_data[columns:]  # Используя срез переопределяем td_data так, чтобы он
        # больше не содержал первых 3 элементов.

    print(table)  # Печатаем таблицу


def q_path(value, dict1, alph, key, mas, count):
    if len(value) > 0:
        if alph in [el[-1] for el in dict1[value[0]] if el[-1] == alph]:
            for elem in [el[:2] for el in dict1[value[0]] if el[-1] == alph]:
                mas.append(elem)
            value.remove(value[0])
            return q_path(value, dict1, alph, key, mas, 0)
        else:
            value.remove(value[0])
            return q_path(value, dict1, alph, key, mas, 0)
    else:
        if len(mas) > 0:
            key = mas[count]
            if chr(949) in [el[-1] for el in dict1[key] if el[-1] == chr(949)]:
                for elem in [el[:2] for el in dict1[key] if el[-1] == chr(949)]:
                    mas.append(elem)
                return q_path([], dict1, alph, key, mas, count + 1)
            else:
                return mas
        else:
            return mas


def new_s_table(points_s, dict1, alph):
    mas = [[] for _ in range(len(dict1))]
    for i, key in enumerate(points_s):
        value_s_points = points_s[key]
        value = q_path(value_s_points, dict1, alph, key, [], 0)
        if value is None:
            mas[i].append('')
        else:
            for elem in value:
                mas[i].append('S' + elem[-1])
    for i, elem in enumerate(mas):
        if len(elem) > 0:
            for el in elem:
                if (''.join(elem)).count(el) > 1:
                    mas[i].remove(el)
        #print(elem)
    #print(mas)
    return mas


def p_create(weights):
    mas, count = ['S0'], 0
    while count != len(weights):
        for elem in weights[count]:
            if elem != '' and elem not in mas:
                mas.append(elem)
        count += 1
    dict1 = {f'P{i}': mas[i] for i in range(len(mas))}
    return dict1


def p_table(dict_p, dict_s, translate, alph):
    mas = [set() for _ in range(len(dict_p))]
    for i, elem in enumerate(dict_p):
        for el in dict_p[elem]:
            if dict_s[el][alph] != chr(909):
                for num in dict_s[el][alph]:
                    mas[i].add(num)
    new_mas = []
    mas = [tuple(sorted(elem)) for elem in mas]
    for elem in mas:
        if len(elem) > 0:
            for el in translate:
                if el == elem:
                    new_mas.append(translate[el])
                    continue
        else:
            new_mas.append(chr(909))
    return new_mas


def word_check(dict1, word, final_points, key, count):
    if count == len(word):
        if key in final_points:
            return True
        else:
            return False
    else:
        if word[count] in [el[-1] for el in dict1[key] if el[-1] == word[count]]:
            return word_check(dict1, word, final_points, ''.join([el[:2] for el in dict1[key] if el[-1] == word[count]]), count + 1)
        else:
            return False


if __name__ == "__main__":
    while True:
        choice = input('Выполнить пресет для 10 варианта?  Да/Нет введу сам: ')
        if choice.lower() == 'нет':
            alphabet = input('Введите алфавит > ')
            amount_points = int(input('Введите кол-во вершин > '))
            q_points = ['q' + str(_) for _ in range(amount_points)]
            while True:
                endpoint = input('Введите финальные вершины через пробел > ').split()
                flag = False
                for elem in endpoint:
                    if len(endpoint) > len(q_points):
                        print('Кол-во финальных вершин не должно превышать общее кол-во вершин!')
                        break
                    if len(elem) > 3 and elem not in q_points:
                        print('Некорректный ввод!')
                        break
                        if elem[1:].isdigit() == True:
                            if int(elem[1:]) < amount_points:
                                print(elem)
                            else:
                                print('Индекс финальной вершины не может быть равен или более количества вершин!')
                                break
                        else:
                            print('Индекс должен быть числом!')
                            break
                    if endpoint[-1]:
                        flag = True
                if flag:
                    break
            e_connections = {}
            i = 0
            while i != amount_points:
                amount_connections = input(f'Сколько связей у вершины q{i} > ')
                flag = False
                if amount_connections.isdigit():
                    if int(amount_connections) <= amount_points:
                        j = 0
                        values = []
                        while j != int(amount_connections):
                            connections = f"q{input(f'Введите с какими вершинами связана вершина q{i} > q')}"
                            flag = False
                            if connections[1:].isdigit():
                                if int(connections[-1]) < amount_points:
                                    while True:
                                        alph_check = input(f'Введите символ алфавита (Эпсилон - {chr(949)})> ')
                                        values.append(connections + ':' + alph_check)
                                        j += 1
                                        if alph_check not in alphabet + chr(949):
                                            j -= 1
                                            print('Неккорректный символ алфавита, попробуйте еще раз!')
                                        else:
                                            break
                                else:
                                    print('Индекс вершины не может быть больше кол-ва вершин!')
                            else:
                                print('Введён некорректный символ!')
                    else:
                        i -= 1
                        print('Связей больше чем вершин!')
                    flag = True
                else:
                    i -= 1
                    print('Введён некорректный символ')
                if flag:
                    e_connections[f'q{i}'] = values
                i += 1
            #print(e_connections)
            th = ['q']
            for elem in alphabet:
                th.append(elem)
            th.append(chr(949))
            alphabet = th[1:]
            td = []
            for elem in e_connections:
                if elem not in endpoint:
                    td.append(elem)
                else:
                    td.append('(final){0}'.format(elem))
                for letter in alphabet:
                    if letter not in [elem[-1] for elem in e_connections[elem] if elem[-1] == letter]:
                        td.append(chr(909))
                    for el in e_connections[elem]:
                        if el[-1] == letter:
                            td.append(el[:2])
            print('СВЯЗИ В ГРАФЕ:')
            beautiful_table(th, td)
            break
        elif choice.lower() == 'да':
            e_connections = {'q0': [f'q1:a', f'q3:{chr(949)}'],
                             'q1': ['q0:b', 'q1:a', f'q2:{chr(949)}'],  # chr(949) = ε
                             'q2': ['q1:b'],
                             'q3': [f'q2:b']}
            endpoint = 'q2'.split()
            amount_points = len(e_connections)
            q_points = ['q' + str(_) for _ in range(amount_points)]
            th = ['q', 'a', 'b', f'{chr(949)}']
            alphabet = ['a', 'b', f'{chr(949)}']

            td = []
            for elem in e_connections:
                if elem not in endpoint:
                    td.append(elem)
                else:
                    td.append('(final){0}'.format(elem))
                for letter in alphabet:
                    if letter not in [elem[-1] for elem in e_connections[elem] if elem[-1] == letter]:
                        td.append(chr(909))
                    for el in e_connections[elem]:
                        if el[-1] == letter:
                            td.append(el[:2])
            print('СВЯЗИ В ГРАФЕ:')
            beautiful_table(th, td)
            break

    # Формируем S-точки и собираем данные для создания S-таблицы:
    s_points = s_points_create(e_connections)
    s_points = {key: sorted(value) for key, value in s_points.items()}
    zero = new_s_table(s_points, e_connections, alphabet[0])
    s_points = s_points_create(e_connections)
    s_points = {key: sorted(value) for key, value in s_points.items()}
    one = new_s_table(s_points, e_connections, alphabet[1])
    s_points = s_points_create(e_connections)
    s_points = {key: sorted(value) for key, value in s_points.items()}
    zipp = [''.join(zero[i]) + ' ' + ''.join(one[i]) for i in range(amount_points)]
    s_dict = {f'S{_}': zipp[_] for _ in range(amount_points)}
    s = []
    for key, value in s_points_create(e_connections).items():
        if len(set(endpoint) & {elem for elem in list(value)}) > 0:
            s.append(f'(final){key}={value}')
        else:
            s.append(f'{key}={value}')

    # Cохраним финальные S:
    dictS = s_points_create(e_connections)
    final_s = []
    for elem in dictS:
        for el in dictS[elem]:
            if el in endpoint:
                final_s.append(elem)
    print(s_dict)

    # Создаём S-таблицу
    th = ['S', alphabet[0], alphabet[1]]
    td_old = [s_dict[elem].split(' ') for elem in s_dict]
    td = []
    for i, elem in enumerate(td_old):
        td.append(s[i])
        for el in elem:
            td.append(el)
    td = [elem if elem != '' else chr(909) for elem in td]  # chr(8709) = ∅
    beautiful_table(th, td)

    # Формируем P-точки
    p_weights = [elem.split(' ') for elem in zipp]
    p_points = p_create(p_weights)
    print('P-точки:', *[key + '=' + '{' + value + '}' for key, value in p_points.items()])

    # Собираем и реализовываем данные для создания P-таблицы:
    value_s_table = [td[i + 1: i + 3] for i in range(0, amount_points * 3, 3)]
    new_value_s_table = [[] for _ in range(amount_points)]
    for j, elem in enumerate(value_s_table):
        for el in elem:
            num = []
            for i in range(len(el) // 2):
                num.append(el[i * 2:(i + 1) * 2])
            new_value_s_table[j].append(num)
    dict_s_table = {td[i][:2] if '(final)' != td[i][:7] else td[i][7:9]: new_value_s_table[i // 3] for i in
                    range(0, amount_points * 3, 3)}
    p_points_values = [p_points[elem] for elem in p_points]
    #print(p_points_values)
    new_p_points_values = [[] for _ in range(amount_points)]
    for i in range(len(p_points_values)):  # amount_points
        for j in range(0, len(p_points_values[i]), 2):
            #print(p_points_values[i][j:j + 2])
            new_p_points_values[i].append(p_points_values[i][j:j + 2])
    p_dict = {f'P{i}': new_p_points_values[i] for i in range(amount_points)}
    reverse_p_dict = {tuple(sorted(value)): key for key, value in p_dict.items()}
    p_values = [key + '=' + '{' + value + '}' for key, value in p_points.items()]

    # Cохраним финальные P:
    final_p = []
    for elem in p_dict:
        for el in p_dict[elem]:
            for end in final_s:
                if el == end:
                    final_p.append(elem)

    # Создаём P-таблицу
    p_table_values = [elem if f'P{i}' not in final_p else '(final)' + elem for i, elem in enumerate(p_values)]
    zero = p_table(p_dict, dict_s_table, reverse_p_dict, 0)
    one = p_table(p_dict, dict_s_table, reverse_p_dict, 1)
    td = []
    for i in range(len(p_table_values)):
        td.append(p_table_values[i])
        td.append(zero[i])
        td.append(one[i])
    th = ['P', alphabet[0], alphabet[1]]
    beautiful_table(th, td)

    # Компануем данные для проверки на слово:
    p_connections = {
        td[i][:2] if td[i][:7] != '(final)' else td[i][7:9]: [f'{elem}:{alphabet[count]}' if elem != chr(909) else elem for
                                                              count, elem
                                                              in enumerate(td[i + 1:i + 3])]
        for i in range(0, len(td), 3)}

    print(p_connections)
    # Проверка искомого слова:
    while True:
        choice = input('Ввести слово для проверки/Выйти? (да): ')
        if choice.lower() == 'да':
            word = input('Введите слово для проверки: ')
            if word_check(p_connections, word, final_p, 'P0', 0):
                print('Автомат допускает цепочку!')
            else:
                print('Данная цепочка не допустима для искомого автомата!')
        else:
            break
