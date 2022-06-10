// Задача 58: Задайте две матрицы. Напишите программу, которая будет
// находить произведение двух матриц.

// Произведение матриц возможно только при их соизмеримости,
// поэтому в данной задаче для генерации массива будет применяться
// пользовательский ввод их размерностей, содержимое же будет
// случайным, но с диапазоном значений от 0 до 9 для легкости проверки.

char dimension = 'K';

Console.WriteLine("Введете размерность матрицы А (K х L): ");
int k = DimensionInput();
int l = DimensionInput();

Console.WriteLine("Введете размерность матрицы B (M х N): ");
int m = DimensionInput();
int n = DimensionInput();

int[,] matrixA = CreateRndArray(k, l, 0, 10);
int[,] matrixB = CreateRndArray(m, n, 0, 10);

Console.WriteLine("Матрица А:");
ShowTwoDimArray(matrixA);
Console.WriteLine("Матрица В:");
ShowTwoDimArray(matrixB);

if (l != m)
    Console.WriteLine("Матрицы несоизмеримы, вычислить произведение невозможно.");
else
{
    Console.WriteLine("Произведение матриц равно:");
    ShowTwoDimArray(ProdOfMatrix(matrixA, matrixB));
}


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

int[,] CreateRndArray(int m, int n, int minVal, int maxVal)
{
    // Метод возвращает двумерный массив (M x N) случайных
    // целых чисел в диапазоне от minVal до maxVal.

    int[,] rndArr = new int[m, n];
    Random rndNum = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
            rndArr[i, j] = rndNum.Next(minVal, maxVal);
    }
    return rndArr;
}

void ShowTwoDimArray(int[,] array)
{
    // Метод выводит двумерный массив array.

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[,] ProdOfMatrix(int[,] matA, int[,] matB)
{
    // Метод возвращает матрицу, как результат умножения
    // матрицы А на матрицу В.

    int m = matA.GetLength(1);
    int[,] matrixP = new int[matA.GetLength(0), matB.GetLength(1)];
    for (int i = 0; i < matrixP.GetLength(0); i++)
    {
        for (int j = 0; j < matrixP.GetLength(1); j++)
        {
            for (int k = 0; k < m; k++)
                matrixP[i, j] += matA[i, k] * matB[k, j];
        }
    }
    return matrixP;
}