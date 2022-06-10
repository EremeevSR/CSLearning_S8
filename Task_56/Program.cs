// Задача 56: Задайте прямоугольный двумерный массив. Напишите
// программу, которая будет находить строку с наименьшей суммой элементов.

// При решении задачи для простоты проверки ограничимся 
// значениями целых чисел от 0 до 9. Размерность массива
// случайная от 1 до 9.

int m = new Random().Next(1, 10);
int n = new Random().Next(1, 10);

int[,] someArray = CreateRndTwoDimArray(m, n, 0, 10);
Console.WriteLine("Исходный массив:");
PrintTwoDimArray(someArray);
Console.WriteLine();

int[] arrOfSums = ArrayOfRowSum(someArray);
int indexOfMinSumStr = IndexMinValOfArray(arrOfSums);
Console.WriteLine("Строка с наименьшей суммой элементов:");
PrintRowOfArray(someArray, indexOfMinSumStr);


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

int IndexMinValOfArray(int[] arr)
{
    // Метод возвращает индекс наименьшего
    // значения. В случае равенства возвращается
    // индекс первого наименьшего.

    int minVal = arr[0];
    int minIndex = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < minVal)
        {
            minVal = arr[i];
            minIndex = i;
        }
    }
    return minIndex;
}

int[] ArrayOfRowSum(int[,] arr)
{
    // Метод возвращает массив сумм элементов
    // строк массива arr.

    int[] retArr = new int[arr.GetLength(0)];

    for (int i = 0; i < arr.GetLength(0); i++)
        retArr[i] = SumOfRow(arr, i);
    return retArr;
}

int SumOfRow(int[,] arr, int row)
{
    // Метод возвращает сумму элементов строки
    // row массива arr.

    int sum = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
        sum += arr[row, i];
    return sum;
}

void PrintRowOfArray(int[,] arr, int row)
{
    // Метод выводит строку row массива arr.

    for (int i = 0; i < arr.GetLength(1); i++)
        Console.Write($"{arr[row, i]}\t");
    Console.WriteLine();
}