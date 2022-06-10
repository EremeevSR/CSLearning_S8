// Задача 54: Задайте двумерный массив. Напишите программу, которая
// упорядочит по убыванию элементы каждой строки двумерного массива.

// При решении задачи ограничимся созданием массива случайных чисел
// в диапазоне от 0 до 99 и случайной размерности.
// Сортировку строк выполним простешним пузырьковым методом.

int m = new Random().Next(3, 10);
int n = new Random().Next(3, 10);

int[,] someArray = CreateRndTwoDimArray(m, n, 0, 100);
Console.WriteLine("Исходный массив:");
PrintTwoDimArray(someArray);
Console.WriteLine();

SortRawsOfArray(someArray);
Console.WriteLine("Обработанный массив:");
PrintTwoDimArray(someArray);


int[,] CreateRndTwoDimArray(int m, int n, int minVal, int maxVal)
{
    // Метод возвращает целочисленный двухмерный массив целочисленных 
    // значений от minVal до maxVal размерностью [m x n].

    Random rndNum = new Random();
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
            result[i, j] = rndNum.Next(minVal, maxVal);
    }
    return result;
}

void PrintTwoDimArray(int[,] arr)
{
    // Метод выводит на экран двумерный массив arr.

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
            Console.Write($"{arr[i, j]}\t");
        Console.WriteLine();
    }
}

void SortRawsOfArray(int[,] arr)
{
    // Метод сортирует строки массива arr
    // пузырьком в порядке убывания.

    if (arr.GetLength(1) == 1) return;
    int sortings;
    int temp;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        do
        {
            sortings = 0;
            for (int j = 0; j < arr.GetLength(1) - 1; j++)
            {
                temp = arr[i, j];
                if (arr[i, j] < arr[i, j + 1])
                {
                    arr[i, j] = arr[i, j + 1];
                    arr[i, j + 1] = temp;
                    sortings++;
                }
            }
        }
        while (sortings > 0);
    }
}