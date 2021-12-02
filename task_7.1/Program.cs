using System;

namespace task_7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double[,] sides = new double[3, 2]; //массив из длин сторон треугольников
                bool mistake = false;   //отрицательное число или не удалось конвертировать в число?
                Console.WriteLine("Вас приветствует программа сравнения площадей треугольников по трем сторонам.");
                for (int j = 0; j < 2; j++) //перебираем треугольники
                {
                    for (int i = 0; i < 3; i++) //перебираем стороны
                    {
                        if (mistake == false)   
                        {
                            Console.WriteLine("Треугольник {0}. Введите сторону {1}.", j + 1, i + 1);
                            try
                            {
                                sides[i, j] = Convert.ToDouble(Console.ReadLine()); //считываем длину
                                if (sides[i, j] < 0)    //проверка на отрицательное число
                                {
                                    mistake = true;
                                    Console.WriteLine("Введено отрицательное число.");
                                    Console.WriteLine("Программа завершена из-за ошибки.");
                                    Console.WriteLine("");
                                }
                            }
                            catch   //если не удалось конвертировать
                            {
                                mistake = true;
                                Console.WriteLine("Не удалось прочитать число.");
                                Console.WriteLine("Программа завершена из-за ошибки.");
                                Console.WriteLine("");
                            }
                        }
                    }
                }
                //далее сравниваем площади и проверяем существует ли треугольник
                if (SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]) > SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]) && SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]) !=-1 && SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]) !=-1)
                {
                    Console.WriteLine("Площадь первого треугольника больше площади второго треугольника (S1 = {0} > S2 = {1}).", Math.Round(SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]),3), Math.Round(SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]),3));
                }
                else if (SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]) < SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]) && SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]) != -1 && SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]) != -1)
                {
                    Console.WriteLine("Площадь первого треугольника меньше площади второго треугольника (S1 = {0} < S2 = {1}).", Math.Round(SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]), 3), Math.Round(SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]), 3));
                }
                else if (SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]) == SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]) && SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]) != -1 && SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]) != -1)
                {
                    Console.WriteLine("Площади треугольников равны (S1 = S2 = {0}).", Math.Round(SquareCount(sides[0, 0], sides[1, 0], sides[2, 0])),3);
                }
                else if (SquareCount(sides[0, 0], sides[1, 0], sides[2, 0]) == -1 || SquareCount(sides[0, 1], sides[1, 1], sides[2, 1]) == -1)
                {
                    Console.WriteLine("Один или оба треугольников не существуют.");
                }
                Console.WriteLine("");
            }
        }
        static double SquareCount(double a, double b, double c) //метод расчета площади треугольника по трем сторонам, если треугольник не существует, выводит -1
        {
            double p = (a + b + c) / 2;
            if (p >= a && p >= b && p >= c)
            {
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                return s;
            }
            else return -1;
        }
    }
}