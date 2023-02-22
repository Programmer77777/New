using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace homework2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------task1---------");
            var array = new int[8] { -143, 533, 745, -54, 5, 99, 86, 8 };
            PrintArr(FilterByPredicate(array, x => x % 2 ==0));
            //---------task1-------- -
            //-143 533 745 5 99

            Console.WriteLine("---------task2---------");
            var arr = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            PrintArr(SwapArrays(arr));
            /*---------task2-------- -
             * 5 6 7 8 1 2 3 4*/

            Console.WriteLine("---------task3---------");
            var matr = new int[4, 4];
            var create = CreateMatrix(matr);
            PrintMatr(create);
            Console.WriteLine();
            PrintMatr(SwapRowsInTheMatrix(create));

            Console.WriteLine("---------task4---------");
            var matr2 = new int[4, 5];
            var create2 = CreateMatrix(matr2);
            PrintMatr(create2);
            Console.WriteLine($"Значение наибольшей суммы и номер строки с наибольшей суммой - {FindMaxRow(create2)}");
            //4 - 23 - 88 57 60
            //90 - 59 - 11 - 52 8
            //97 66 70 - 37 - 65
            //- 46 - 99 79 - 90 - 34
            //Значение наибольшей суммы и номер строки с наибольшей суммой - (107, 2)

            Console.WriteLine("---------task5---------");
            var jaggedArray = new double[5][];
            jaggedArray[0] = new double[5];
            jaggedArray[1] = new double[4];
            jaggedArray[2] = new double[1];
            jaggedArray[3] = new double[7];
            jaggedArray[4] = new double[3];
            var J_array =  CreatingJaggedArr(jaggedArray);
            Console.WriteLine($"Максимальное значение среди всех средних значений строк массива = {FindMaxInJaggedArray(J_array)}");
            //---------task5-------- -
            //83 - 72 - 92 4 93
            //- 35 - 40 35 28
            //84
            //78 17 68 - 7 - 73 - 3 - 85
            //82 32 55
            //Максимальное значение среди всех средних значений строк массива = 16,4
        }

        public static int[] FilterByPredicate(int[] arr, Predicate<int> predicate)
        {
            if (arr.Length == 0)
                return null;

            var filteredArray = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (predicate(arr[i]) == false)
                    filteredArray.Add(arr[i]);
            }

            //var count = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (predicate(arr[i]) == false)
            //        count++;
            //}

            //var filteredArray = new int[count];
            //var ind = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (predicate(arr[i]) == false)
            //    {
            //        filteredArray[ind] = arr[i];
            //        ind++;
            //    }
            //}
            return filteredArray.ToArray();
        }

        public static int[] SwapArrays(int[] arr)
        {
            if (arr.Length % 2 != 0)
                throw new AggregateException("Нечётная длина массива");
            if (arr.Length == 0)
                return null;
            var endArray = new int[arr.Length];
            var mid = arr.Length / 2;
            (var arr_1, var arr_2) = (arr[..mid], arr[mid..]);
            endArray = arr_2.Concat(arr_1).ToArray();
            return endArray;
        }


        public static int[,] SwapRowsInTheMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        var rows = arr[i, arr.GetLength(1)-j-1];
                        arr[i, arr.GetLength(1) - j - 1] = arr[i, j];
                        arr[i, j] = rows;
                        //(arr[i, arr.GetLength(1) - j - 1], arr[i, j]) = (arr[i, j], arr[i, arr.GetLength(1) - j - 1]);
                        if (j == (arr.GetLength(1) - 1))
                            break;
                    }
                }
            }
            return arr;
        }

        public static (int, int) FindMaxRow(int[,] matr)
        {
            (var sum, var maxSum,var row) = (0, 0, 0);
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    sum += matr[i, j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    row = i;
                    sum = 0;
                }
            }

            return (maxSum, row);
        }

        public static double FindMaxInJaggedArray(double[][] J_array)
        {
            (var everage, var max, var sum, var count) = (0.0, double.MinValue, 0.0, 0.0);
            for (int i = 0; i < J_array.Length; i++)
            {
                for (int j = 0; j < J_array[i].Length; j++)
                {
                    sum += J_array[i][j];
                    count++;
                }
                everage = sum / count;
                if (everage > max)
                    max = everage;
                (everage, sum, count) = (0, 0, 0);
            }
            return max;
        }


        public static double[][] CreatingJaggedArr(double[][] array)
        {
            var Random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = Random.Next(-100, 100);
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]} ");
                }
                Console.WriteLine();
            }

            return array;
        }

        public static int[,] CreateMatrix(int[,] matrix)
        {
            var r = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var number = r.Next(-100, 100);
                    matrix[i, j] = number;
                }
            }
            return matrix;
        }


        public static void PrintArr(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public static void PrintMatr(int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                    Console.Write($"{matr[i, j]} ");
                Console.WriteLine();
            }
        }

    }

}

    