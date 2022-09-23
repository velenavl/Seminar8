// Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.
Console.Write("Введите количество строк: ");
int row = Convert.ToInt32(Console.ReadLine());

Console.Write("Введите количество столбцов: ");
int col = Convert.ToInt32(Console.ReadLine());

int[,] array = new int[row, col];
FillArrayRandomValues(array, 10, 99);
Print2DArray(array);

System.Console.WriteLine("-------------------------");

(int row, int col) tuple = GetRowColWithMin(array);
int[,] cutedArray = removeRowAndColByIndexes(array, tuple.row, tuple.col);
Print2DArray(cutedArray);

(int row, int col) GetRowColWithMin(int[,] array)
{
    int min = array[0, 0];
    int r = 0;
    int c = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < min)
            {
                min = array[i, j];
                r = i;
                c = j;
            }
        }
    }
    return (row: r, col: c);
}

int[,] removeRowAndColByIndexes(int[,] array, int row, int col)
{
    int[,] result = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (i == col)
        {
            continue;
        }
        
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j == col)
            {
                continue;
            }

            if (i > row)
            {
                if (j > col)
                {
                    result[i - 1, j - 1] = array[i, j];
                }
                else
                {
                    result[i-1, j] = array[i, j];
                }
            }
            else if (j > col)
            {
                if (i > row)
                {
                    result[i - 1, j - 1] = array[i, j];
                }
            }
            else
            {
                result[i, j] = array[i, j];
            }
        }
    }
    return result;
}

void FillArrayRandomValues(int[,] array, int minValue, int maxValue)
{
    Random random = new Random();
     for (int row = 0; row <= array.GetUpperBound(0); row++)
     {
       for (int col = 0; col <= array.GetUpperBound(1); col++)
       {
        array[row, col] = random.Next(minValue, maxValue);
       } 
     }
}

void Print2DArray(int[,] array)
{
    for (int row = 0; row <= array.GetUpperBound(0); row++)
    {
        for (int col = 0; col <= array.GetUpperBound(1); col++)
        {
        System.Console.Write($"{array[row, col]}\t"); 
        }
        System.Console.WriteLine();
    }
}


// Console.WriteLine();
// int[,] result = CreateRandomArray(m, n);
// Print2DArray(result);

// Console.WriteLine();

// int[] minArray = FindMin(result);
// PrintArray(minArray);

// int[] FindMin(int[,] array)
// {
//     int min = array[0,0];
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             if(min );
//         }
//     }
// }

// void Print2DArray(int[,] array)
// {
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             Console.Write($"{array[i, j]} ");
//         }
//         Console.WriteLine();
//     }
// }

// int[,] CreateRandomArray(int m, int n)
// {
//     int[,] array = new int[m, n];

//     Random random = new Random();
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             array[i, j] = random.Next(0, 10);
//         }
//     }
//     return array;
// }

// void PrintArray(int[] array)
// {
//     if (array.Length == 0)
//     {
//         Console.WriteLine("Что-то пошло не так");
//         return;
//     }
//     Console.Write("[");

//     for (int i = 0; i < array.Length - 1; i++)
//     {
//         Console.Write($"{array[i]},");
//     }

//     Console.Write(array[array.Length - 1]);
//     Console.Write("]");
// }
