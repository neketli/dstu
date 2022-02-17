using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kod
{
    class Program
    {
        static void Main(string[] args)
        {
            Coder coder = new Coder();
            Decoder decoder = new Decoder();
            Console.WriteLine("Введите код (из 0 и 1)");
            string str = "";

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (str.Length > 0)
                        {
                            str = str.Remove(str.Length - 1, 1);
                            Console.Write(key.KeyChar + " " + key.KeyChar);
                        }
                        break;
                    default:
                        if ((key.KeyChar <= 49) && (key.KeyChar >= 48))
                        {
                            Console.Write(key.KeyChar);
                            str += key.KeyChar;
                        }
                        break;
                }
            }
            while (key.KeyChar != 13);
            Console.WriteLine("\n---------------------------");

            string code = coder.Encode(str);
            Console.WriteLine($"Закодирванная строка: {code}");

            Console.WriteLine("\n---------------------------");

            Random random = new Random();

            Console.WriteLine("Введём строку или оставим на псевдорандом?(y - введём, n - random)");

            do
            {
                str = Console.ReadLine();
            } while (str.ToLower() != "y" && str.ToLower() != "n");

            if (str == "y")
            {
                Console.WriteLine("Введите закодированную строку: ");
                do
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Backspace:
                            if (str.Length > 0)
                            {
                                str = str.Remove(str.Length - 1, 1);
                                Console.Write(key.KeyChar + " " + key.KeyChar);
                            }
                            break;
                        default:
                            if ((key.KeyChar == 49) || (key.KeyChar == 48))
                            {
                                Console.Write(key.KeyChar);
                                str += key.KeyChar;
                            }
                            break;
                    }
                }
                while (key.KeyChar != 13);
            }
            else
            {
                int rnd = random.Next(0, coder.BitCount);
                str = code.Remove(rnd, 1)
                    .Insert(rnd, random.Next(0, 1).ToString());
                Console.WriteLine($"Переданная строка: {str}");
            }



            string decode = decoder.Decode(str, coder.BitCount);

            Console.WriteLine($"\nДекодированная строка: {decode}");

            Console.ReadKey();
        }
    }
}
