using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genestart
{
    class Program
    {
        public static Random random = new Random();
        static int max = 100;
        static int good = 10;
        static int leng = 10;
        static int dol = 5;
        static int[,] unit1 = new int[max, leng + 1]; 
        static int[,] unit2 = new int[max, leng + 1];

        public static int age = 0;

        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 25);
            Renew();
            Console.ReadKey(true);
            while (true)
            {
                age++;
                Reset();
                Testing();
                copy();
                Print();
               if(age % 10 == 0)
               {
                    Console.Write("계속하려면 아무키나 누르세요.");
                    Console.ReadKey(true);
               }
                Console.Clear();
            }
        }

        static void Renew()
        {
            for(int i=0; i< max; i++)
            {
                unit1[i, 0] = 0;
                unit2[i, 0] = 0;
                for(int j=1; j<=leng; j++)
                {
                    unit1[i, j] = random.Next(0, 10); //0부터 9까지의 랜덤
                }
            }
        }

        static void Testing()
        {
            int ch;
            int index1 = 0, index2 = 0;

            for(int i = 0; i < max; i++)
            {
                ch = random.Next(0, 100);
                index1 = random.Next(0, good);
                index2 = random.Next(0, good);
                for(int j = 1; j <= leng; j++)
                {
                    dol = random.Next(1, 101);
                    if(dol <= 5)
                    {
                        unit2[i, j] = random.Next(0, 10);
                    }
                    else
                    {
                        int check = random.Next(0, 2);
                        if (check == 0)
                        {
                            unit2[i, j] = unit1[index1, j];
                        }
                        else
                        {
                            unit2[i, j] = unit1[index2, j];
                        }
                    }
                    if(unit2[i,j] == j - 1)
                    {
                        unit2[i, 0]++;
                    }
                }
            }
        }

        static void copy()
        {
            int[,] goods = new int[good, leng + 1];
            for(int i = 0; i < good; i++){
                goods[i, 0] = 0;
            }

            for(int i =0; i< max; i++)
            {
                for(int j = 0; j< good; j++)
                {
                    if(goods[j, 0] < unit2[i, 0])
                    {
                        for(int k = 1; k<= leng; k++)
                        {
                            goods[j, k] = unit2[i, k];
                            if (goods[j, k] == k - 1) goods[j, 0]++;
                        }
                        break;

                    }
                }
            }

            int ch;
            int index1=0, index2 = 0;

            for(int i = 0; i< max; i++)
            {
                for (int j = 1; j <= leng; j++)
                {
                    index1 = random.Next(0, good);
                    index2 = random.Next(0, good);
                    dol = random.Next(0, 100);
                    if (dol < 5)
                    {
                        unit1[i, j] = random.Next(0, 10);
                    }
                    else
                    {
                        ch = random.Next(0, 2);
                        if(ch == 0)
                        {
                            unit1[i, j] = goods[index2, j];
                        }
                        else
                        {
                            unit1[i, j] = goods[index1, j];
                        }
                    }
                    if(unit1[i, j] == j - 1)
                    {
                        unit1[i, 0]++;
                    }
                }
            }

        }

        static void Print()
        {
            for(int i = 0; i<max; i += 5)
            {
                for(int j = i; j<i+5; j++)
                {
                    for(int k = 1; k<= leng; k++)
                    {
                        Console.Write(unit2[i, k]);
                    }
                    Console.Write(" [ {0} ]    ",unit2[i, 0]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("제 {0} 세대 ", age);
        }

        static void Reset()
        {
            for (int i = 0; i < max; i++)
            {
                unit1[i, 0] = 0;
                unit2[i, 0] = 0;
            }
        }

    }
}
