using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kod
{
    class Coder
    {

        int bitCount;
        public int BitCount { get => bitCount; set => bitCount = value; }

        int[] bits;
        public int[] Bits { get; set; }

        public string Encode(string value)
        {
            string str = value;
            string strCode = "";
            string strOut = str;
            
            strCode = str; // для вывода
            str = str.Insert(0, "0").Insert(1, "0"); // вставка нулей в 0, 2^0
            strOut = strOut.Insert(0, "X").Insert(1, "X");
            bitCount = 2;

            for (int i = 4, j = 3; i < str.Length; i = (int)Math.Pow(2, j), j++)
            {
                bitCount++;
                str = str.Insert(i - 1, "0");
                strOut = strOut.Insert(i - 1, "X");
            }
            Console.WriteLine($"Избыточность в количестве {bitCount} контрольных бит");
            //Console.WriteLine(str);
            Console.WriteLine(strOut+"\n");

            string[] checkMatrix = new string[bitCount];
            Console.WriteLine("#\nПроверочная матрица\n#");



            if (bitCount >= 1)
            {
                for (int i = 0; i < str.Length / 2; i++)
                    checkMatrix[0] += "0";
                for (int i = 0; i < str.Length; i += 2)
                    checkMatrix[0] = checkMatrix[0].Insert(i, "1");
                Console.WriteLine(checkMatrix[0]);
            }

            if (bitCount >= 2)
            {
                for (int i = 0; i < str.Length / 2; i++)
                    checkMatrix[1] += "0";
                for (int i = 1; i < str.Length; i += 4)
                    checkMatrix[1] = checkMatrix[1].Insert(i, "11");

                if (checkMatrix[1].Length > str.Length)
                    checkMatrix[1] = checkMatrix[1].Remove(checkMatrix[1].Length - (checkMatrix[1].Length - str.Length));
                else if (checkMatrix[1].Length < str.Length)
                    checkMatrix[1] += "0";

                Console.WriteLine(checkMatrix[1]);
            }

            if (bitCount >= 3)
            {
                checkMatrix[2] = str;
                checkMatrix[2] = checkMatrix[2].Replace('1', '0');

                for (int i = 3; i < str.Length; i += 8)
                    checkMatrix[2] = checkMatrix[2].Insert(i, "1111");

                if (checkMatrix[2].Length > str.Length)
                    checkMatrix[2] = checkMatrix[2].Remove(checkMatrix[2].Length - (checkMatrix[2].Length - str.Length));

                Console.WriteLine(checkMatrix[2]);
            }

            if (bitCount >= 4)
            {
                checkMatrix[3] = str;
                checkMatrix[3] = checkMatrix[3].Replace('1', '0');

                for (int i = 7; i < str.Length; i += 16)
                    checkMatrix[3] = checkMatrix[3].Insert(i, "11111111");

                if (checkMatrix[3].Length > str.Length)
                    checkMatrix[3] = checkMatrix[3].Remove(checkMatrix[3].Length - (checkMatrix[3].Length - str.Length));

                Console.WriteLine(checkMatrix[3]);
            }



            int[] currArray = str.Select(el => int.Parse(el.ToString())).ToArray(); //массив из целых чисел
            int[,] verifMatrix = new int[bitCount,currArray.Length];

            for (int i = 0; i < bitCount; i++)
            {
                int j = 0;
                foreach (var item in checkMatrix[i].Select(ch => int.Parse(ch.ToString())).ToArray())
                {
                    verifMatrix[i,j] = item;
                    j++;
                }
                
            }
 

            string[] r = new string[bitCount]; //для хранения контрольных бит
            bits = new int[bitCount];

            Console.WriteLine("\n#\nКонтрольные биты\n#");

            for (int i = 0; i < bitCount; i++)
            {
                int summ = 0;
                for (int j = 0; j < str.Length; j++)
                    summ += currArray[j] * verifMatrix[i,j];
                if (summ > 1)
                    r[i] = Convert.ToString(summ % 2);
                else
                    r[i] = Convert.ToString(summ);
                Console.WriteLine($"r{i} = {r[i]} ");
                bits[i] = Convert.ToInt32(r[i]);
            }

            Console.WriteLine();
            
            for (int i = 1, j = 1, k = 0; i < strCode.Length; i = (int)Math.Pow(2, j), j++, k++)
            {
                strCode = strCode.Insert(i - 1, r[k]);
            }

            return strCode;

        }
    }
}
