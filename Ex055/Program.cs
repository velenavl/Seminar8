// Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. В случае, если это не возможно, программа должна вывести сообщение для пользователя.
Console.Write("Введите количество  строк: ");
bool IsNumberM = int.TryParse(Console.ReadLine(), out int m);
Console.WriteLine();

Console.Write("Введите количество столбцов: ");
bool IsNumberN = int.TryParse(Console.ReadLine(), out int n);
Console.WriteLine();

int[,] result = CreateRandomArray(m, n);
Print2DArray(result);
Console.WriteLine();
ReplaceRowToColumn(result);
Print2DArray(result);

void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

int[,] CreateRandomArray(int m, int n)
{
    int[,] array = new int[m, n];
    
    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = random.Next(0, 100);
        }
    }

    return array;

}


void ReplaceRowToColumn(int[,] array)
{
    int tmp;
    for (int i = 0; i < array.GetLength(0) - 1; i++)
    {
        for (int j = i + 1; j < array.GetLength(1); j++)
        {
           tmp = array[i, j];
           array[i, j] = array[j, i];
           array[j, i] = tmp; 
        }
    }
}