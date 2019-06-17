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
            Console.WriteLine("Введите размер массива");
            int n = ReadAnswer();
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(0, 100);
            int[] arr2 = new int[n];
            for (int i = 0; i < arr.Length; i++)
                arr2[i] = rnd.Next(0, 100);
            int resultForChange = 0;
            int resultForCompare = 0;
            SelectionSort(arr, out resultForChange, out resultForCompare);
            Console.WriteLine($"    Неупорядоченный массив \n");
            Console.WriteLine($"Сортировка простым выбором \n Ожидаемый резуьтат: {n * n - 1} \n Реальный результат: {resultForChange+resultForCompare}, число перестановок: {resultForChange}, число сранений {resultForCompare}");
            resultForChange = 0;
            resultForCompare = 0;
            MergeSort(arr2, 0, arr.Length - 1, ref resultForChange, ref resultForCompare);
            Console.WriteLine();
            Console.WriteLine($"Сортировка слиянием \n Ожидаемый резуьтат: {Math.Ceiling(Math.Log(n, 2)*n)} \n Реальный результат: число перестановок: {resultForChange}, число сранений {resultForCompare}");
            resultForChange = 0;
            resultForCompare = 0;
            SelectionSort(arr, out resultForChange, out resultForCompare);
            Console.WriteLine();
            Console.WriteLine($"    Упорядоченный по неубыванию массив \n");
            Console.WriteLine($"Сортировка простым выбором \n Ожидаемый резуьтат: {n * n - 1} \n Реальный результат: {resultForChange + resultForCompare}, число перестановок: {resultForChange}, число сранений {resultForCompare}");
            resultForChange = 0;
            resultForCompare = 0;
            MergeSort(arr2, 0, arr.Length - 1, ref resultForChange, ref resultForCompare );
            Console.WriteLine();
            Console.WriteLine($"Сортировка слиянием \n Ожидаемый резуьтат: {Math.Ceiling(Math.Log(n, 2) * n)} \n Реальный результат: число перестановок: {resultForChange}, число сранений {resultForCompare}");
            Array.Reverse(arr);
            Array.Reverse(arr2);
            resultForChange = 0;
            resultForCompare = 0;
            SelectionSort(arr, out resultForChange, out resultForCompare);
            Console.WriteLine();
            Console.WriteLine($"    Упорядоченный по невозрастанию массив \n");
            Console.WriteLine($"Сортировка простым выбором \n Ожидаемый резуьтат: {n * n - 1} \n Реальный результат: {resultForChange + resultForCompare}, число перестановок: {resultForChange}, число сранений {resultForCompare}");
            resultForChange = 0;
            resultForCompare = 0;
            MergeSort(arr2, 0, arr.Length - 1, ref resultForChange, ref resultForCompare);
            Console.WriteLine();
            Console.WriteLine($"Сортировка слиянием \n Ожидаемый резуьтат: {Math.Ceiling(Math.Log(n, 2) * n)} \n Реальный результат: число перестановок: {resultForChange}, число сранений {resultForCompare}");
           
        }

        static Random rnd = new Random();

        static void SelectionSort(int [] arr, out int countForChange, out int countForCompare) // метод простого выбора
        {
            countForChange = 0;
            countForCompare = 0;
            int min, n_min, j;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = arr[i]; n_min = i;
                for (j = i + 1; j < arr.Length; j++)
                {
                    countForCompare++;
                    if (arr[j] < min) // поиск минимального
                    {
                        countForCompare++;
                        min = arr[j];
                        n_min = j;
                    }
                }
                if(arr[i]!=arr[n_min])
                {
                    arr[n_min] = arr[i]; //обмен
                    countForChange++;
                    arr[i] = min;
                }
                
            }

        }


         static void MergeSort(int[] a, int firstElemIdx, int lastElemIdx, ref int countForChange, ref int countForCompare)
        {
            if (lastElemIdx <= firstElemIdx)
                return;
            int mid = firstElemIdx + (lastElemIdx - firstElemIdx) / 2;
            MergeSort(a, firstElemIdx, mid, ref countForChange, ref countForCompare ); // сортировка левого подмассива
            MergeSort(a, mid + 1, lastElemIdx, ref countForChange, ref countForCompare); // сортировка правого подмассива
            int[] buf = new int[a.Length]; // выделение памяти для вспомогательного массива
            Array.Copy(a, buf, a.Length);
            int i = firstElemIdx, j = mid + 1;
            for (int k = firstElemIdx; k <= lastElemIdx; k++)
            {
                Movement(ref countForCompare, ref countForChange, a, ref i, k, ref j, mid, buf, lastElemIdx); // слияние отсортированных частей в одним массив
            }
        }

        static void Movement(ref int countForCompare, ref int countForChange, int[]a, ref int i, int k, ref int j, int mid, int[] buf, int lastElemIdx) 
        {
            countForCompare++;
            if (i > mid) // если первая подпоследовательность закончилась
            {
                if (a[k] != buf[j])
                {
                    countForChange++;
                    a[k] = buf[j];
                }
                j++;
            }
            else if (j > lastElemIdx) // если вторая подпоследовательность закончилась
            {
                if (a[k] != buf[i])
                {
                    countForChange++;
                    a[k] = buf[i];
                }
                i++;
            }
            else if (buf[j] < buf[i]) // если элемент из второй последовательности меньше
            {
                if (a[k] != buf[j])
                {
                    countForChange++;
                    a[k] = buf[j];
                }
                j++;
            }
            else // если элемент из первой последовательности меньше
            {
                if (a[k] != buf[i])
                {
                    countForChange++;
                    a[k] = buf[i];
                }
                i++;
            }
        }

        static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        static int ReadAnswer()
        {
            int a=0;
            bool ok = false;
            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a > 0)  
                        ok = true;
                    else throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Пожалуйста, введите целое число от 0 до {int.MaxValue}.");
                    ok = false;
                }
            } while (!ok);
            return a;
        }
    }
}
