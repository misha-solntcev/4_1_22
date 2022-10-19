﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Вариант 22
    Из заданной матрицы A(N, M) удалите строку и столбец, в которых находится
первый элемент, равный нулю. Полученную матрицу уплотните.
    Осуществить циклический сдвиг элементов квадратной матрицы размерности М * N 
вправо на k элементов таким образом: элементы 1 - й строки сдвигаются в последний
столбец сверху вниз, из него — в последнюю строку справа налево, из нее — в первый
столбец снизу вверх, из него — в первую строку; для остальных элементов —
аналогично. */

namespace _4_1_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                { 8, 1, 6, 4, 8 },
                { 4, 0, 5, 7, 8 },
                { 7, 8, 9, 0, 2 },
                { 8, 0, 3, 4, 5 },
                { 9, 0, 4, 0, 1 },
            };
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);

            // Определение индексов первого нулевого элемента.
            int indI = 0;
            int indJ = 0;
            for (int i = 0; i < n; i++)            
                for (int j = 0; j < m; j++)                
                    if (arr[i, j] == 0)
                    {
                        indI = i;
                        indJ = j;
                        goto Exit;
                    }            
            Exit:
            Console.WriteLine($"{indI}, {indJ}");            
            // Модификация массива.
            for (int i = indI; i < n-1; i++)            
                for (int j = 0; j < m; j++)                
                    arr[i, j] = arr[i + 1, j];
            for (int j = indJ; j < m - 1; j++)
                for (int i = 0; i < n; i++)
                    arr[i, j] = arr[i, j + 1];
            // Уменьшение размера массива.
            int k = n - 1;
            int l = m - 1;
            int[,] newArr = new int[k, l];
            for (int i = 0; i < k; i++)
                for (int j = 0; j < l; j++)
                    newArr[i,j] = arr[i, j];
            // Вывод измененного массива.
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    Console.Write($"{newArr[i, j]}, ");
                }
                Console.WriteLine();
            }                

            Console.ReadKey();
        }
    }
}
