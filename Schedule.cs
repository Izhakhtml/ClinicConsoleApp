using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicConsoleApp
{
    class Schedule
    {
        public int[,] diary;
        public Schedule() { }
        public void TwoDimensionalArray()
        {
            Random random = new Random();
            for (int i = 0; i < this.diary.GetLength(0); i++)
            {
                for (int j = 0; j < this.diary.GetLength(1); j++)
                {
                    this.diary[i, j] = random.Next(0, 10);
                    this.diary[i, 6] = 0;
                    Console.Write(this.diary[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void TwoDimensionalArrayLowerFive()
        {
            Random random = new Random();
            for (int i = 0; i < this.diary.GetLength(0); i++)
            {
                for (int j = 0; j < this.diary.GetLength(1); j++)
                {
                    this.diary[i, j] = random.Next(0, 10);
                    this.diary[i, 6] = 0;
                    if (this.diary[i, j] < 5)
                    {
                        Console.Write(this.diary[i, j]);
                    }
                    else
                    {
                        Console.Write("bussy");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
