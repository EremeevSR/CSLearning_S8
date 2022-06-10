// Задача 60: Сформируйте трёхмерный массив из неповторяющихся
// двузначных чисел. Напишите программу, которая будет построчно выводить
// массив, добавляя индексы каждого элемента.

// При заполнении трехмерного массива двузначными числами будем
// использовать переменную, инициализированную значением 10 и 
// инкрементируемую в процессе заполнения массива. При этом
// количество элементов массива не может превышать 90.
// Размерность будет вводить пользователь.

char dimension = 'L';

Console.WriteLine("Введете размерность трехмерного массива (L x M x N):");

int l = DimensionInput();
int m = DimensionInput();
int n = DimensionInput();

int[,,] threeDimArr = CreateThreeDimArray(l, m, n);

if (l * m * n > 90)
    Console.WriteLine("Такой массив не может быть сгенерирован.");
else
    PrintThreeDimArray(threeDimArr);

bool IsNatural(int number)
{
    // Метод определяет, является ли число number натуральным.

    if (number >= 1) return true;
    else return false;
}

int DimensionInput()
{
    // Метод ввода количества строк М и столбцов N двумерного массива.

    Console.Write($"{dimension} - ");
    int result = int.Parse(Console.ReadLine());
    while (!IsNatural(result))
    {
        Console.Write($"Число должно быть больше нуля. Повторите ввод:\n{dimension} - ");
        result = int.Parse(Console.ReadLine());
    }
    dimension++;
    return result;
}

int[,,] CreateThreeDimArray(int l, int m, int n)
{
    // Метод возвращает трехмерный массив, заполненный
    // значениями от 10.

    int val = 10;
    int[,,] arr = new int[l, m, n];
    for (int k = 0; k < arr.GetLength(2); k++)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j, k] = val++;
            }
        }
    }
    return arr;
}

void PrintThreeDimArray(int[,,] arr)
{
    // Метод выводит трехмерный массив построчно.
    // Была предпринята попытка как-то визуализировать
    // его трехмерность.

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int k = arr.GetLength(2) - 1; k >= 0; k--)
        {
            for (int l = 0; l < k; l++)
                Console.Write("\t");
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j, k]} ({i},{j},{k})   ");
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine();
    }
}