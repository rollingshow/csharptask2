using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string inputLine;
        string[] inputArray;
        int
            n,
            sqr_n;

        try
        {
            // Размер холста
            inputLine = Console.ReadLine();

            n = Convert.ToInt32(inputLine);
            sqr_n = n * n;

            // Подготовка массива 
            int[,] sudokuArray = new int[sqr_n, sqr_n];

            for (int i = 0; i < sqr_n; i++)
            {
                inputLine = Console.ReadLine();
                inputArray = inputLine.Split(" ");

                if (inputArray.Length != sqr_n)
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
                else
                {
                    for (int j = 0; j < sqr_n; j++)
                    {
                        sudokuArray[i, j] = Convert.ToInt32(inputArray[j]);
                    }
                }
            }

            // Создаём проверочный массив 1...SQR(N)
            int[] validationArray = Enumerable.Range(1, sqr_n).ToArray();

            // Проверка горизонталей
            for (int i = 0; i < sqr_n; i++)
            {
                int[] tempArray = (int[]) validationArray.Clone();
                for (int j = 0; j < sqr_n; j++)
                {
                    if (sudokuArray[i, j] < 0 || sudokuArray[i, j] > sqr_n)
                    {
                        Console.WriteLine("Incorrect");
                        return;
                    }
                    else
                    {
                        tempArray[sudokuArray[i, j] - 1] = 0;
                    }
                }

                if (tempArray.Sum() != 0)
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
            }

            // Проверка вертикалей
            for (int j = 0; j < sqr_n; j++)
            {
                int[] tempArray = (int[]) validationArray.Clone();
                for (int i = 0; i < sqr_n; i++)
                {
                    if (sudokuArray[i, j] < 0 || sudokuArray[i, j] > sqr_n)
                    {
                        Console.WriteLine("Incorrect");
                        return;
                    }
                    else
                    {
                        tempArray[sudokuArray[i, j] - 1] = 0;
                    }
                }

                if (tempArray.Sum() != 0)
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
            }

            // Проверка квадратов
            for (int iArr = 0; iArr < n; iArr++)
            {
                for (int jArr = 0; jArr < n; jArr++)
                {
                    int[] tempArray = (int[]) validationArray.Clone();
                    int[] tempQuad = new int[sqr_n];
                    int index = 0;
                    for (int i = n * iArr; i < n + n * iArr; i++)
                    {
                        for (int j = n * jArr; j < n + n * jArr; j++)
                        {
                            tempQuad[index++] = sudokuArray[i, j];
                        }
                    }

                    for (int i = 0; i < sqr_n; i++)
                    {
                        tempArray[tempQuad[i] - 1] = 0;
                    }

                    if (tempArray.Sum() != 0)
                    {
                        Console.WriteLine("Incorrect");
                        return;
                    }
                }
            }

            // Вывод
            Console.WriteLine("Correct");
        }
        catch
        {
            Console.WriteLine("Incorrect");
        }
    }
}

/* 
WRONG INPUT:

3
5 4 3 1 2 8 9 6 7
6 8 1 9 5 7 2 4 3
2 9 7 4 6 3 8 1 5
4 7 6 3 9 5 1 2 8
3 1 2 7 8 6 5 9 4
8 5 9 2 1 4 3 7 6
7 2 5 8 4 9 6 3 1
9 6 4 5 2 1 7 8 2
1 3 8 6 7 2 4 5 9 

VALID INPUT:

3
1 3 2 5 4 6 9 8 7
4 6 5 8 7 9 3 2 1
7 9 8 2 1 3 6 5 4
9 2 1 4 3 5 8 7 6
3 5 4 7 6 8 2 1 9
6 8 7 1 9 2 5 4 3
5 7 6 9 8 1 4 3 2
2 4 3 6 5 7 1 9 8
8 1 9 3 2 4 7 6 5

*/
