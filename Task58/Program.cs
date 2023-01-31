/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18 */

int GetUserData(string massage)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine(massage);
    int UserData = int.Parse(Console.ReadLine()!);
    Console.ResetColor();
    return UserData;
}

void printInColor(string data, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.Write(data);
    Console.ResetColor();
}

int[,] GetRandomArray(int col, int row, int start, int end)
{
    int[,] array = new int[col, row];
    for (int i = 0; i < col; i++)
    {
        for (int j = 0; j < row; j++)
        {
            array[i, j] = new Random().Next(start, end + 1);
        }
    }
    return array;
}

void Print2DArray(int[,] array)
{
    Console.Write(" \t");
    for (int j = 0; j < array.GetLength(1); j++)
    {
        printInColor(j + "\t", ConsoleColor.DarkGreen);
    }
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        printInColor(i + "\t", ConsoleColor.DarkGreen);
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

int[,] GetProizvedenie2Array(int[,] array1, int[,] array2)
{
    int[,] resultArray = new int[array1.GetLength(0), array2.GetLength(1)];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int n = 0; n < array1.GetLength(0); n++)
            {
                resultArray[i, j] = resultArray[i, j] + array1[i, n] * array2[n, j];
            }
        }
    }
    return resultArray;
}

int col1 = GetUserData("Ввидите число строк первого массива: ");
int row1 = GetUserData("Ввидите число столбцов первого массива: ");
int col2 = GetUserData("Ввидите число строк второго массива: ");
int row2 = GetUserData("Ввидите число столбцов второго массива: ");

int[,] array1 = GetRandomArray(col1, row1, 0, 10);
int[,] array2 = GetRandomArray(col2, row2, 0, 10);
Print2DArray(array1);
Console.WriteLine();
Print2DArray(array2);

// проверка на возможность умножения
if (array1.GetLength(0) != array2.GetLength(1))
{
    Console.WriteLine("Перемножение невозможно!");
}
else 
{
    int[,] resultArray = GetProizvedenie2Array(array1, array2);
    Console.WriteLine();
    Print2DArray(resultArray);
}
