using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("where are the changes?");
            int n = 128;
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(0, 100);
            int[] arr2 = new int[n];
            for (int i = 0; i < arr.Length; i++)
                arr2[i] = rnd.Next(0, 100);
            int result = 0;
            SelectionSort(arr, out result);
            Console.WriteLine($"Неупорядоченный массив \n Сортировка простым выбором \n Ожидаемый резуьтат: {n * n - 1} \n Реальный результат: {result}");
            result = 0;
            MergeSort(arr2, 0, arr.Length - 1, ref result);
            Console.WriteLine($"Неупорядоченный массив \n Сортировка слиянием \n Ожидаемый резуьтат: {Math.Log(n, 2)*n} \n Реальный результат: {result}");
            result = 0;
            SelectionSort(arr, out result);
            Console.WriteLine($"Упорядоченный по неубыванию массив \n Сортировка простым выбором \n Ожидаемый резуьтат: {n * n - 1} \n Реальный результат: {result}");
            result = 0;
            MergeSort(arr2, 0, arr.Length - 1, ref result);
            Console.WriteLine($"Упорядоченный по неубыванию \n Сортировка слиянием \n Ожидаемый резуьтат: {Math.Log(n, 2) * n} \n Реальный результат: {result}");
            Array.Reverse(arr);
            Array.Reverse(arr2);
            result = 0;
            SelectionSort(arr, out result);
            Console.WriteLine($"Упорядоченный по невозрастанию массив \n Сортировка простым выбором \n Ожидаемый резуьтат: {n * n - 1} \n Реальный результат: {result}");
            result = 0;
            MergeSort(arr2, 0, arr.Length - 1, ref result);
            Console.WriteLine($"Упорядоченный по невозрастанию \n Сортировка слиянием \n Ожидаемый резуьтат: {Math.Log(n, 2) * n} \n Реальный результат: {result}");
        }

        static Random rnd = new Random();

        static void SelectionSort(int [] arr, out int total) // метод простого выбора
        {
            int countForChange = 0;
            int countForCompare = 0;
            int countForHead = 0;
            int min, n_min, j;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = arr[i]; n_min = i;
                for (j = i + 1; j < arr.Length; j++)
                {
                    countForHead++;
                    if (arr[j] < min) // поиск минимального
                    {
                        countForCompare++;
                        min = arr[j];
                        n_min = j;
                    }
                }
                arr[n_min] = arr[i]; //обмен
                countForChange++;
                arr[i] = min;
            }
            total = countForHead + countForCompare + countForChange;
        }


         static void MergeSort(int[] a, int firstElemIdx, int lastElemIdx, ref int countForChange)
        {
            if (lastElemIdx <= firstElemIdx)
                return;
            int mid = firstElemIdx + (lastElemIdx - firstElemIdx) / 2;
            MergeSort(a, firstElemIdx, mid, ref countForChange);
            MergeSort(a, mid + 1, lastElemIdx, ref countForChange);
            int[] buf = new int[a.Length];
            Array.Copy(a, buf, a.Length);
            int i = firstElemIdx, j = mid + 1;
            for (int k = firstElemIdx; k <= lastElemIdx; k++)
            {
                countForChange++; 
                if (i > mid)
                {
                    a[k] = buf[j];
                    j++;
                }
                else if (j > lastElemIdx)
                {
                    a[k] = buf[i];
                    i++;
                }
                else if (buf[j] < buf[i])
                {
                    a[k] = buf[j];
                    j++;
                }
                else
                {
                    a[k] = buf[i];
                    i++;
                }
            }
        }
    }
}
