using System;

namespace HomeWork10
{
    class Program
    {
        static void Main(string[] args)
        {          
            Console.WriteLine("Номера заданий:" +
                "\n1 - Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, " +
                "так чтобы в одной группе все числа в группе друг на друга не делились? " +
                "Найдите M при заданном N и получите одно из разбиений на группы" +
                "\n2 - 4 друга должны посетить 12 пабов, в котором выпить по британской пинте пенного напитка. " +
                "До каждого бара идти примерно 15-20 минут, каждый пьет пинту за 15 минут. " +
                "У первого друга лимит выпитого 1.1 литра, у второго 1.5, у третьего 2.2 литра, у 4 - 3.3 литра, это их максимум. " +
                "Необходимо выяснить, до скольки баров смогут дойти каждый из друзей(Пройденное расстояние (в барах)), пока не упадет. " +
                "И сколько всего времени будет потрачено на выпивку.");

            int task = Input("Введите номер задания: ");
            Console.Clear();
            switch (task)
            {
                case 1:
                    int number = Input("Введите число: ");
                    int row = 0, numberCopy = number;

                    while (numberCopy != 0)
                    {
                        numberCopy /= 2;
                        row++;
                    }

                    int[,] matrix = new int[row, number];
                    int[] array = new int[row];
                    bool flag = true;

                    for (int i = 0; i < row; i++)
                    {
                        matrix[i, 0] = (int)Math.Pow(2, i);
                        array[i] = 1;
                    }

                    for (int i = 3; i <= number; i++)
                    { 
                        for (int j = 1; j < row; j++)
                        {
                            int variable = (int)Math.Pow(2, j);
                            if (i % variable != 0 && i > matrix[j, 0])
                            {
                                for (int k = 0; k < array[j]; k++)
                                {
                                    if (i % matrix[j, k] == 0)
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                if (flag == true)
                                {
                                    matrix[j, array[j]++] = i;
                                    break;
                                }
                                flag = true;
                            }
                        }
                    }

                    Console.WriteLine($"Для N = {number}, M получается = {row}");
                    PrintMatrix(matrix);
                    break;

                case 2:
                    Random distanceTime = new Random();
                    double pinta = 0.568, limit = 0;
                    int pab = 12, timePinta = 15, timeDrink = 0, maxLimit = 0;
                    double[] frend = { 1.1, 1.5, 2.2, 3.3 };
                    int[] distance = new int[4];

                    for(int i = 0; i < frend.Length; i++)
                    {
                        while(limit < frend[i])
                        {
                            limit += pinta;
                            distance[i]++;
                        }
                        if (distance[i] > distance[maxLimit])
                        {
                            maxLimit = i;
                        }
                        limit = 0;
                    }

                    for (int i = 0; i < distance[maxLimit]; i++)
                    {
                        if (i > pab)
                            break;
                        timeDrink += distanceTime.Next(15, 21) + timePinta;
                    }

                    PrintDistance(distance, pab);
                    Console.WriteLine();
                    Console.WriteLine("Время потраченное на выпивку = {0} мин.", timeDrink);
                    break;

            }           

            void PrintMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.Write("Группа {0}: ", i + 1);
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 0)
                            break;
                        Console.Write("{0} ", matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            void PrintDistance(int[] array, int pab)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (array[i] < pab && array[i] > 4 || array[i] == 0)
                        Console.WriteLine($"{i + 1} друг посетит {array[i]} баров.");
                    else if (array[i] <= 4 && array[i] > 1)
                        Console.WriteLine($"{i + 1} друг посетит {array[i]} барa.");
                    else if (array[i] == 1)
                        Console.WriteLine($"{i + 1} друг посетит {array[i]} бар.");
                    else
                        Console.WriteLine($"{i + 1} друг посетит все бары.");
                }
            }

            int Input(string str)
            {
                Console.Write(str);
                return int.Parse(Console.ReadLine());
            }

            Console.ReadKey();
        }
    }
}
