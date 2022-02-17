#include <iostream>
#include <fstream>
#include <utility>
#include <vector>
#include <string>
#include <vector>
#include <cmath>
#include <sstream>
using namespace std;

// Сигнатуры функций
vector <pair <char, double> > frequency_analysis(string);
void out_table(vector <pair<char, double> >);
vector <pair <char, double> > sort_vector_desc(vector <pair <char, double> >);
vector<double> sum_frequencies(vector <pair <char, double> >);
void out_vector(vector<double>);
vector <pair <char, string> > to_sh_f(vector <pair <char, double> >, vector<double>);
void out_codes_table(vector<pair<char, string> >);
bool check_prefix(vector<pair<char, string> >);
pair <vector <pair<char, string> >, string> encoding_to_code(string, vector<pair<char, string> >);
pair <vector <pair<char, string> >, string> decoding_to_decode(pair <vector <pair<char, string> >, string>);
void efficiency_coefficient(string input, pair <vector <pair<char, string> >, string>);

int sex()
{
	system("chcp 1251");  // Переходим на русский язык в консоли
	system("cls");
	string input;
	cout << "Введите сообщение, которое вы желаете кодировать: ";
	getline(cin, input);
	vector <pair <char, double> > freq_table = frequency_analysis(input); // "Таблица" символ-вероятность 
	cout << "\nПолучившейся таблица вероятностей символов: \n";
	out_table(freq_table);
	vector <pair <char, double> > freq_desc = sort_vector_desc(freq_table);
	cout << "\nОтсортированная по убыванию таблица: \n";
	out_table(freq_desc);
	vector<double> sum_freq = sum_frequencies(freq_desc);
	cout << "\nКумулятивные вероятности: \n";
	out_vector(sum_freq);
	vector<pair<char, string> > sh_f_codes = to_sh_f(freq_desc, sum_freq);
	cout << "\nТаблица символ  - код: \n";
	out_codes_table(sh_f_codes);
	bool is_prefix = check_prefix(sh_f_codes);
	pair <vector <pair<char, string> >, string> tables_code_and_code;
	pair <vector <pair<char, string> >, string> tables_code_and_decode;
	if (is_prefix)
	{
		tables_code_and_code = encoding_to_code(input, sh_f_codes);
		cout << "\nИсходное сообщение: \n" << input << "\n\nЗакодированное сообщение\n" << tables_code_and_code.second;
		cout << "\n\nДекодинг кода в исходное сообщение:\n";
		tables_code_and_decode = decoding_to_decode(tables_code_and_code);
		cout << "Исходное сообщение: \n" << tables_code_and_decode.second << "\n\n";
		if (tables_code_and_decode.second == input)
		{
			cout << "Исходная строка совпала с декодированной!\n\n";
		}
		else
		{
			return -2;
		}
	}
	else // Код не префиксный
	{
		return -1;
	}
	efficiency_coefficient(input, tables_code_and_code);
	system("pause");
	return 0;
}

// Частотный анализ
vector <pair <char, double> > frequency_analysis(string input)
{
	/*
	Функция, реализующая частотный анализ заданной строки. Результатом набор пар ключ-значение, где ключ - буква,
	Значение - вероятность встретить букву в передаваемом сообщении.
	*/
	vector <pair <char, double> > freq_table;

	for (int counter = 0; counter < input.size(); counter++) //Проходем по каждому символу в слове
	{
		//считаем количество букв
		for (int counter2 = 0; counter2 < freq_table.size(); counter2++)
		{
			if (freq_table[counter2].first == input[counter]) // Сравниваем его с имеющимися символами в "Таблице"
			{
				freq_table[counter2].second += 1.0 / input.size(); // Если совпали, увличиваем вероятность
				goto out_label;
			}
		}
		freq_table.push_back(pair<char, double>(input[counter], 1.0 / input.size()));
		// К сожеланию приходиться добавлять goto, вместо else, иначе не добавится первый элемент и второй цикл не будет работать. 
	out_label:;
	}
	return freq_table;
}

// Вывод "таблицы" на экран
void out_table(vector <pair <char, double> > container)
{
	int size = container.size();
	for (int counter = 0; counter < size; counter++)
	{
		cout << "Ключ: " << container[counter].first << "\tЗначение: " << container[counter].second << '\n';
	}
}

//Сортировка вектора по убыванию частот
vector <pair <char, double> > sort_vector_desc(vector <pair <char, double> > freq_table)
{
	int size = freq_table.size();
	pair<char, double> tmp;
	for (int counter = 0; counter < size - 1; counter++)
	{
		for (int counter2 = 0; counter2 < size - counter - 1; counter2++)
		{
			if (freq_table[counter2].second < freq_table[counter2 + 1].second)
			{
				tmp = freq_table[counter2];
				freq_table[counter2] = freq_table[counter2 + 1];
				freq_table[counter2 + 1] = tmp;
			}
		}
	}
	return freq_table;
}

//Образование возрастающих сумм частот q
vector<double> sum_frequencies(vector <pair <char, double> > freq_table)
{
	vector<double> sum_freq;
	sum_freq.push_back(0);
	int size = freq_table.size();
	for (int counter = 1; counter <= size; counter++)
	{
		sum_freq.push_back(sum_freq[counter - 1] + freq_table[counter - 1].second);
	}
	return sum_freq;
}

// Вывод вектора на экран
void out_vector(vector<double> container)
{
	int size = container.size();
	for (int counter = 0; counter < size; counter++)
	{
		cout << "Значение: " << container[counter] << '\n';
	}
}


// Образование кодов символов
vector <pair<char, string> > to_sh_f(vector <pair <char, double> > freq_table, vector<double> sum_freq)
{
	// Массив кодовых слов
	vector<pair<char, string> > codes;
	int size = freq_table.size();
	for (int counter = 0; counter < size; counter++) //Для каждой комулятивной вероятности
	{
		vector<int> code; // Под одной буквы
		// Переводим вещественные числа в двоичную систему
		int number_char = ceil(-log2(freq_table[counter].second)); // Ограничение знаков двоичного числа
		for (int counter2 = 0; counter2 < number_char; counter2++)
		{
			sum_freq[counter] *= 2;
			code.push_back(floor(sum_freq[counter]));
			if (sum_freq[counter] >= 1)
			{
				sum_freq[counter]--;
			}
		}
		// Переводим в строку
		string result;
		for (int counter2 = 0; counter2 < code.size(); counter2++)
		{
			result += code[counter2] ? '1' : '0';
		}
		codes.push_back(pair<char, string>(freq_table[counter].first, result));
	}
	return codes;
}

// Вывод таблицы кодов на экран 
void out_codes_table(vector<pair<char, string> > shf)
{
	int size = shf.size();
	for (int counter = 0; counter < size; counter++)
	{
		cout << "Символ: " << shf[counter].first << "\tКод: " << shf[counter].second << '\n';
	}
}

// Проверка префиксности получившихся кодов
bool check_prefix(vector<pair<char, string> > codes)
{
	int size = codes.size();
	for (int counter = 0; counter < size; counter++) // Проход по всем кодам
	{
		for (int counter2 = counter + 1; counter2 < size; counter2++) // Проход по всем кодам, которые следует после нынешнего 
		{
			bool flag = false; // Индикатор совпадения кодов, если они не совпали меняем значение на false
			for (int counter3 = 0; counter3 < codes[counter].second.size(); counter3++) // Проход по буквам текущих сравниваемых кодов 
			{
				/*
				Здесь не возникает проблемы выхода за границы массива-кода, тк изначально сортировка по неубыванию
				*/
				if (codes[counter].second[counter3] != codes[counter2].second[counter3])
				{
					flag = true;
				}
			}
			if (!flag)
			{
				cout << "\nДанная таблица кодов не является префиксной\n";
				return false;
			}
		}
	}
	cout << "\nДанная таблица кодов является префиксной\n";
	return true;
}

// Функция, кодирующая исходное сообщение, принимает исходную таблицу кодов и сообщение, возвращает исходную таблицу кодов и закодированное сообщение. 
pair <vector <pair<char, string> >, string> encoding_to_code(string input, vector<pair<char, string> > sh_f_codes)
{
	int size = input.size();
	int size_table = sh_f_codes.size();
	pair <vector <pair<char, string> >, string> table_codes_and_code;
	table_codes_and_code.first = sh_f_codes;
	for (int count = 0; count < size; count++) // Для каждой буквы исходной строки
	{
		for (int count2 = 0; count2 < size_table; count2++) // Рассматриваем все кодовые слова, пока не встретится необходимый код
		{
			if (input[count] == sh_f_codes[count2].first)
			{
				table_codes_and_code.second += sh_f_codes[count2].second;
				break;
			}
		}
	}
	return(table_codes_and_code);
}

// Функция, декодирующая исходное сообщение, принимает исходную таблицу кодов и сообщение, возвращает исходную таблицу кодов и декодированное сообщение. 
pair <vector <pair<char, string> >, string> decoding_to_decode(pair <vector <pair<char, string> >, string> table_codes_and_code)
{
	int code_size = table_codes_and_code.second.size();
	int size_table = table_codes_and_code.first.size();
	pair <vector <pair<char, string> >, string> table_codes_and_decode;
	table_codes_and_decode.first = table_codes_and_code.first;
	string code;
	for (int count = 0; count < code_size; count++) // Для каждой цифры исходной строки будем формировать кодовое слово, и проверять его на соответсвие таблице кодов, если не нашли
													// То увеличиваем кодовое слово, добавляяя следующую цифру.
	{
		code += table_codes_and_code.second[count];
		for (int count2 = 0; count2 < size_table; count2++) // Рассматриваем все кодовые слова, пока не встретится необходимый код
		{
			if (code == table_codes_and_decode.first[count2].second)
			{
				table_codes_and_decode.second += table_codes_and_decode.first[count2].first;
				code = ""; // Если подходящее кодовое слово найдено, добавляем в декод символ, хранящийся под этим кодом и обнуляем код.
				break;
			}
		}
	}
	return(table_codes_and_decode);
}

// Функция, вычисляющая степень сжатия
void efficiency_coefficient(string input, pair <vector <pair<char, string> >, string> tables_code_and_code)
{
	double size_input = input.size();
	double size_code = tables_code_and_code.second.size();
	cout << "Сжатие исходного сообщения с помощью данного кодирования для данного сообщения составило:\n" << size_input * 8 / size_code << "\n\n\n";
}

// Сигнатуры функций
vector<vector<int>> to_lzss(string);
void show_code(vector<vector<int>>);
string decode_lzss(vector<vector<int>>);

int test()
{
	system("chcp 1251");  // Переходим на русский язык в консоли
	system("cls");
	string input;
	cout << "Введите сообщение, которое вы желаете кодировать: \n\t\t";
	cin >> input;
	vector<vector<int>> code = to_lzss(input);
	cout << "\nЗакодированное сообщение:\n";
	show_code(code);
	cout << "\nДекодированное закодированное сообщение:\n";
	string decode = decode_lzss(code);
	cout << "\t\t" << decode << "\n\n";
	if (input == decode)
		cout << "Исходное сообщение совпало c декодированным!\n\n";
	else
		cout << "Исходное сообщение не совпало c декодированным!\n\n";
	system("pause");
	return 0;
}

vector<vector<int>> to_lzss(string input)
{
	// буффера, в привычном плане алгоритма тут нет, в роли него выступает динамически расширяющийся словарь, а строка поступает посимвольно(буффер 1).
	vector<vector<int>> codes; // Кодовые диады, вместо символа будет код символа
	string buffer;
	for (int counter = 0; counter < input.size();)
	{
		int is_find = buffer.rfind(input[counter]); // Если подстрока не найдена вернется string::npos (-1)
		while (is_find == -1 && counter < input.size())
		{
			codes.push_back({ 0,input[counter] }); // Подстрока, не встречавшиеся ранее всегда будет иметь 0,0
			buffer += input[counter];
			is_find = buffer.rfind(input[++counter]);
		}
		if (counter >= input.size()) // без данного условия(в том числе и в while) возможно кодировать только последовательности хотя бы с одним повторением
			return codes;
		string substr;
		do
		{
			substr += input[counter];
			is_find = buffer.rfind(substr + input[++counter]);
		} while (is_find != -1 && counter < input.size());
		is_find = buffer.rfind(substr);
		codes.push_back({ counter - is_find - (int)substr.size(), (int)substr.size() });
		buffer += substr;
	}
	return codes;
}

void show_code(vector<vector<int>> code)
{
	for (int counter = 0; counter < code.size(); counter++)
	{
		cout << '(' << code[counter][0] << ',';
		if (code[counter][0])
			cout << code[counter][1];
		else
			cout << (char)code[counter][1];
		cout << ")\n";
	}
}

void file_code_out(vector<vector<int>> code, string fileName)
{
	ofstream fout(fileName + ".bin");
	for (int counter = 0; counter < code.size(); counter++)
	{
		fout << code[counter][0] << ' ' << code[counter][1];
		if (counter != code.size() - 1) fout << "\n";
	}
	fout.close();
}

vector<vector<int>> file_code_in(string fileName)
{
	ifstream fin(fileName + ".bin");
	vector<vector<int>> code;
	char line[100];
	if (!fin) throw(-1);
	while (fin)
	{
		fin.getline(line, 100);
		stringstream iss(line);
		int num;
		vector<int > tmp;
		while (iss >> num)
		{
			tmp.push_back(num);
		}
		code.push_back(tmp);
	}
	fin.close();
	code.pop_back();
	return code;
}

void file_alphbet_out(vector <pair<char, string> > alphabet, string fileName)
{
	ofstream fout(fileName + ".a.bin");
	for (int counter = 0; counter < alphabet.size(); counter++)
	{
		fout << alphabet[counter].first << ' ' << alphabet[counter].second;
		if (counter != alphabet.size() - 1) fout << "\n";
	}
	fout.close();
}

vector<pair<char, string>> file_alphabet_in(string fileName)
{
	ifstream fin(fileName + ".a.bin");
	vector<pair<char, string>> alphabet;
	char line[100];
	if (!fin) throw(-1);
	while (fin)
	{
		fin.getline(line, 100);
		string s = "";
		pair<char, string> tmp;
		tmp.first = line[0];
		for (int i = 2; line[i] != '\0'; i++)
		{
			s += line[i];
		}
		tmp.second = s;
		alphabet.push_back(tmp);
	}
	fin.close();
	alphabet.pop_back();
	return alphabet;
}


string decode_lzss(vector<vector<int>> code)
{
	string decode;
	for (int counter = 0; counter < code.size(); counter++)
	{
		decode += decode.substr(decode.size() - code[counter][0], code[counter][1]);
		if (!code[counter][0])
			decode += code[counter][1];
	}
	return decode;
}


int zip(string fileName)
{
	system("chcp 1251");
	system("cls");
	std::string line;
	string str = "";
	//string fileName = "fu";
	std::ifstream in(fileName + ".txt"); // окрываем файл для чтения
	if (in.is_open())
	{
		while (getline(in, line))
		{
			str += line;
		}
	}
	in.close();     // закрываем файл

	vector <pair <char, double> > freq_table = frequency_analysis(str); // "Таблица" символ-вероятность 
	cout << "\nПолучившейся таблица вероятностей символов: \n";
	out_table(freq_table);
	vector <pair <char, double> > freq_desc = sort_vector_desc(freq_table);
	cout << "\nОтсортированная по убыванию таблица: \n";
	out_table(freq_desc);
	vector<double> sum_freq = sum_frequencies(freq_desc);
	cout << "\nКумулятивные вероятности: \n";
	out_vector(sum_freq);
	vector<pair<char, string> > sh_f_codes = to_sh_f(freq_desc, sum_freq);
	cout << "\nТаблица символ  - код: \n";
	out_codes_table(sh_f_codes);
	bool is_prefix = check_prefix(sh_f_codes);
	pair <vector <pair<char, string> >, string> tables_code_and_code;
	pair <vector <pair<char, string> >, string> tables_code_and_decode;
	if (is_prefix)
	{
		tables_code_and_code = encoding_to_code(str, sh_f_codes);
		cout << "\nИсходное сообщение: \n" << str << "\n\nЗакодированное сообщение Шеннона-Фано\n" << tables_code_and_code.second;

		vector<vector<int>> code = to_lzss(tables_code_and_code.second);
		cout << "\nЗакодированное сообщение lzss:\n";
		show_code(code);

		file_code_out(code, fileName);
		file_alphbet_out(tables_code_and_code.first, fileName);

	}
	else // Код не префиксный
	{
		return -1;
	}
	efficiency_coefficient(str, tables_code_and_code);
	system("pause");
	return 0;
}

int unzip(string fileName) {
	system("chcp 1251");
	system("cls");

	pair <vector <pair<char, string> >, string> tables_code_and_code;
	pair <vector <pair<char, string> >, string> tables_code_and_decode;

	tables_code_and_code.first = file_alphabet_in(fileName);


	cout << "\nДекодированное закодированное сообщение lzss:\n";
	string decode = decode_lzss(file_code_in(fileName));
	cout << "\t\t" << decode << "\n\n";
	/*
	* 	if (tables_code_and_code.second == decode)
		cout << "Исходное сообщение совпало c декодированным lzss!\n\n";
	else
		cout << "Исходное сообщение не совпало c декодированным lzss!\n\n";
	*/


	cout << "\n\nДекодинг кода в исходное сообщение:\n";
	tables_code_and_code.second = decode;
	tables_code_and_decode = decoding_to_decode(tables_code_and_code);
	cout << "Исходное сообщение: \n" << tables_code_and_decode.second << "\n\n";
	/*
	* 	if (tables_code_and_decode.second == str)
	{
		cout << "Исходная строка совпала с декодированной Шеннон-Фано!\n\n";
	}
	else
	{
		return -2;
	}
	*/

	return 0;
}


void zip_bmp(string fileName) {
    ifstream fi; //то же самое только легче
    ofstream fo;

    fi.open(fileName+".bmp", ios::binary | ios::in); //открыли бинарно
    fo.open(fileName+".txt", ios::binary | ios::out);

    char buff;
    if (fi.is_open() && fo.is_open())
    {
        while (fi.read(&buff, sizeof(char))) //пока читаются символы ищем
        {
            fo << buff;
        }
    }
    else
    {
        cout << "error open" << endl;
    }
    fi.close();
    fo.close();
}

void unzip_bmp(string fileName) {
    ifstream fi; //то же самое только легче
    ofstream fo;
    fi.open(fileName + ".txt", ios::binary | ios::in);
    fo.open(fileName + ".bmp", ios::binary | ios::out); //меняем обратно 
    char buff;
    if (fi.is_open() && fo.is_open())
    {
        while (fi.read(&buff, sizeof(char)))
        {
            fo << buff;
        }
    }
    else
    {
        cout << "error open" << endl;
    }
    fi.close();
    fo.close();

}

int main()
{
    system("chcp 1251");
    system("cls");
    string fileName, userChoice;

    do
    {
        cout << "Что будем делать?\n1 - кодировать\n2 - декодировать\nexit для выхода" << endl;
        cout << "Мой выбор: "; cin >> userChoice;
        if (userChoice == "1") {
            cout << "Введите имя файла: "; cin >> fileName;
            zip_bmp(fileName);
			zip(fileName);
            cout << "Успешно закодировано!" << endl;
        }
        else if (userChoice == "2") {
            cout << "Введите имя файла: "; cin >> fileName;
			unzip(fileName);
            unzip_bmp(fileName);
            cout << "Успешно декодировано!" << endl;
        }
    } while (userChoice != "exit");
    
   
    return 0;
}