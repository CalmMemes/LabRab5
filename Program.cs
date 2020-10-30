using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRab5
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input2.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int N = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("*** Input matrix ***");

            int[,] mas = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                String str_all = Console.ReadLine();
                string[] str_elem = str_all.Split(' ');
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = Convert.ToInt32(str_elem[j]);
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }

            int min;
            int count = 0;
            float sp, s = 0;
            

            Console.WriteLine("*** Минимальные элементы для каждого столбца ***");
            for (int j = 0; j < M; j++)
            {
                min = 1001;
                for (int i = 0; i < N; i++)
                {
                    if (mas[i, j] < min)
                        min = mas[i, j];
                    if (mas[i, j] % 2 == 0)
                    {
                        s += mas[i, j];
                        count++;
                    }

                }
                Console.Write(min + " ");
            }
            sp = s / count;
            Console.WriteLine();
            Console.WriteLine("*** Modifed matrix ***");

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (mas[i, j] < sp)
                        Console.Write("x ");
                    else
                        if (mas[i, j] % 2 == 1)
                        Console.Write("y ");
                    else Console.Write(mas[i, j] + " ");
                   
                }
                Console.WriteLine();
            }
            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }
}
