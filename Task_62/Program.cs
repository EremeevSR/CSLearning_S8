// Задача 62: Заполните спирально массив 4 на 4.

// Конкретную задачу было решено решить в общем виде
// для любого двумерного массива. Частный случай для
// массива 4х4, таким образом, тоже входит в решение,
// а сам алгоритм является более гибким.
// Задача решалась "в лоб", поэтому, скорее всего, не
// является оптимальным по тому или иному критерию.

char dimension = 'M';

Console.WriteLine("Введите разменость массива (M x N):");
int m = DimensionInput();
int n = DimensionInput();
Console.WriteLine();

int[,] array = new int[m, n];

Console.WriteLine("Сформирован массив: ");
Console.WriteLine();

FillArrayLikeSpiral(array);
PrintTwoDimArray(array);


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

void FillArrayLikeSpiral(int[,] arr)
{
    // Метод спирально заполняет массив arr, начиная с первого
    // элемента, двигаясь от края до середины по часовой стрелке.

    int elements = arr.GetLength(0) * arr.GetLength(1);
    int direction = 0;
    int value = 1;
    int currentI = 0;
    int currentJ = 0;

    while (elements > 0)
    {
        if (direction == 0) // Движение вправо
        {
            int counter = 0;
            for (int j = currentJ; j < arr.GetLength(1); j++)
            {
                if (arr[currentI, j] == 0)
                {
                    arr[currentI, j] = value++;
                    counter++;
                    elements--;
                }
                else
                    break;
            }
            currentJ = currentJ + counter - 1;
            direction = 1;
            currentI++;
        }
        if (direction == 1) // Движение вниз
        {
            int counter = 0;
            for (int i = currentI; i < arr.GetLength(0); i++)
            {
                if (arr[i, currentJ] == 0)
                {
                    arr[i, currentJ] = value++;
                    elements--;
                    counter++;
                }
                else
                    break;
            }
            currentI = currentI + counter - 1;
            direction = 2;
            currentJ--;
        }
        if (direction == 2) // Движение влево
        {
            int counter = 0;
            for (int j = currentJ; j >= 0; j--)
            {
                if (arr[currentI, j] == 0)
                {
                    arr[currentI, j] = value++;
                    counter++;
                    elements--;
                }
                else
                    break;
            }
            currentJ = currentJ - counter + 1;
            direction = 3;
            currentI--;
        }
        if (direction == 3) // Движение вверх
        {
            int counter = 0;
            for (int i = currentI; i >= 0; i--)
            {
                if (arr[i, currentJ] == 0)
                {
                    arr[i, currentJ] = value++;
                    elements--;
                    counter++;
                }
                else
                    break;
            }
            currentI = currentI - counter + 1;
            direction = 0;
            currentJ++;
        }
    }

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