using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kod
{
    class Decoder
    {
        public string Decode(string str, int bitCount)
        {
            string currStr = str;
            
            string[] checkMatrix = new string[bitCount];

            switch (bitCount)
            {
                case 4:
                    checkMatrix[3] = str;
                    checkMatrix[3] = checkMatrix[3].Replace('1', '0');

                    for (int i = 7; i < str.Length; i += 16)
                        checkMatrix[3] = checkMatrix[3].Insert(i, "11111111");

                    if (checkMatrix[3].Length > str.Length)
                        checkMatrix[3] = checkMatrix[3].Remove(checkMatrix[3].Length - (checkMatrix[3].Length - str.Length));

                    goto case 3;

                case 3:
                    checkMatrix[2] = str;
                    checkMatrix[2] = checkMatrix[2].Replace('1', '0');

                    for (int i = 3; i < str.Length; i += 8)
                        checkMatrix[2] = checkMatrix[2].Insert(i, "1111");

                    if (checkMatrix[2].Length > str.Length)
                        checkMatrix[2] = checkMatrix[2].Remove(checkMatrix[2].Length - (checkMatrix[2].Length - str.Length));

                    goto case 2;

                case 2:
                    for (int i = 0; i < str.Length / 2; i++)
                        checkMatrix[1] += "0";
                    for (int i = 1; i < str.Length; i += 4)
                        checkMatrix[1] = checkMatrix[1].Insert(i, "11");

                    if (checkMatrix[1].Length > str.Length)
                        checkMatrix[1] = checkMatrix[1].Remove(checkMatrix[1].Length - (checkMatrix[1].Length - str.Length));
                    else if (checkMatrix[1].Length < str.Length)
                        checkMatrix[1] += "0";

                    goto case 1;

                case 1:
                    for (int i = 0; i < str.Length / 2; i++)
                        checkMatrix[0] += "0";
                    for (int i = 0; i < str.Length; i += 2)
                        checkMatrix[0] = checkMatrix[0].Insert(i, "1");
                    break;
                default:
                    break;
            }

            int[] currArray = str.Select(el => int.Parse(el.ToString())).ToArray(); //массив из целых чисел
            int[,] syndromeMatrix = new int[bitCount, currArray.Length];

            Console.WriteLine("\n#\nМатрица синдромов\n#");
            for (int i = 0; i < bitCount; i++)
            {
                int j = 0;
                foreach (var item in checkMatrix[i].Select(ch => int.Parse(ch.ToString())).ToArray())
                {
                    syndromeMatrix[i, j] = item;
                    Console.Write(item + " ");
                    j++;
                }
                Console.WriteLine();

            }

            string[] r = new string[bitCount]; //для хранения контрольных бит
            int[] bits = new int[bitCount];

            Console.WriteLine("\n#\nКонтрольные биты\n#");

            for (int i = 0; i < bitCount; i++)
            {
                int summ = 0;
                for (int j = 0; j < str.Length; j++)
                    summ += currArray[j] * syndromeMatrix[i, j];
                if (summ > 1)
                    r[i] = Convert.ToString(summ % 2);
                else
                    r[i] = Convert.ToString(summ);
                Console.WriteLine($"r{i} = {r[i]} ");
                bits[i] = Convert.ToInt32(r[i]);
            }

            Console.WriteLine();

            int position = 0;
            for (int i = 0; i < bitCount; i++)
            {
                if (bits[i] != 0) position += (int)Math.Pow(2, i);
            }


            
            if (position != 0)
            {
                Console.WriteLine($"Ошибка на {position} позиции");

                if (currStr[position - 1] == '1')
                    currStr = currStr.Remove(position - 1, 1).Insert(position - 1, "0");

                else
                    currStr = currStr.Remove(position - 1, 1).Insert(position - 1, "1");

                Console.WriteLine($"\nПринято\n{str}");
                Console.WriteLine($"Исправлено\n{currStr}");
            }
            else
                Console.WriteLine("Ошибок не обнаружено!");

            for (int i = 0; i < bitCount; i++)
            {
                currStr = currStr.Remove((int)Math.Pow(2, i)-1-i, 1);
            }

            return currStr;
        }
    }
}
