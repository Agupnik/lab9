using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quick_Sort
{
    class Program
    {
        //QuickSortStart
        public static void Quick_Sort(int[] arr, int left, int right)
        {
            //проверяем, есть ли что сортировать
            if (left < right)
            {
                //выбор индекса опорного элемента
                int pivot = Partition(arr, left, right);

                //если индекс опрного элемента больше 1, то сортируем левую часть
                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                //если индекс + 1 меньше, чем большая граница подмасива, то сортируем правую часть
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        public static int Partition(int[] arr, int left, int right)
        {
            //выбираем опроный элемент
            //int pivot = arr[right];
            Random rnd = new Random();
            int pivot = arr[rnd.Next(left, right)];
            while (true)
            {

                //поиск индекса элемента, который больше опорного слева
                while (arr[left] < pivot)
                {
                    left++;
                }
                //поиск индекса элемента, который меньше опорного справа
                while (arr[right] > pivot)
                {
                    right--;
                }

                //если найденый индекс левого элемента меньше правого, то 
                //делаем замену элементов под этими индексами
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    //Возвращаем индекс опорного элемента
                    return right;
                }
            }
        }
        //QuickSortEnd
        //CountingSortStart
        static void CountSort(int[] array)
        {
            int length = array.Length;

            //Create a new "output" array
            int[] output = new int[length];

            //Create a new "counting" array 
            //which stores the count of each unique number
            int[] count = new int[150000];

            //считаем появление каждого элемента
            for (int i = 0; i < length; ++i)
            {
                ++count[array[i]];
            }

            //Change count[i] so that count[i] now contains the   
            //actual start position of this character in the output array.
            for (int i = 1; i <= 150000 - 1; ++i)
            {
                count[i] += count[i - 1];
            }

            //Build the output array.
            //To make this sorting algorithm stable, 
            //we are operating in reverse order. 
            for (int i = length - 1; i >= 0; i--)
            {
                output[count[array[i]] - 1] = array[i];
                --count[array[i]];
            }

            //Copy the output array to the final array.
            for (int i = 0; i < length; ++i)
            {
                array[i] = output[i];
            }
        }
        //CountingSortEnd
        //InsertionSortStart
        public static void InsertionSort(int[] arr)
        {
            int j, temp;//ініціалізація допоміжних елементів та елементів ітерації
            //початок алгоритму
            for (int i = 1; i <= arr.Length - 1; i++)
            {
                //тимчасовий елемент, який використовується для заміни
                temp = arr[i];
                //присвоєння значення для елементу ітерації
                j = i - 1;
                //процес заміни елементів
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }
        //InsertionSortEnd
        static void Main(string[] args)
        {
            //TestCode
            ////int[] arr = new int[] { 2, 5, 4, 11, 0, 18, 22, 67, 51, 6, 7};
            //int[] arr = new int[] { 2, 2, 4, 11, 1, 1, 22, 67, 2, 1, 2 };
            ////int[] arr = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 15, 14, 13, 12, 11 };


            //Console.WriteLine("Original array : ");
            //foreach (var item in arr)
            //{
            //    Console.Write(" " + item);
            //}
            //Console.WriteLine();

            ////Quick_Sort(arr, 0, arr.Length - 1);
            //CountSort(arr);

            //Console.WriteLine();
            //Console.WriteLine("Sorted array : ");

            //foreach (var item in arr)
            //{
            //    Console.Write(" " + item);
            //}
            //Console.WriteLine()
            //TestCodeEnd

            //KeyBoardInput
            //Console.WriteLine("Введите колличество мешочков из золотом:");
            //int bags = int.Parse(Console.ReadLine());
            //int[] arr = new int[bags];
            //Console.WriteLine("Введите колличество золота в каждом мешочке:");
            //for (int i = 0; i < bags; i++)
            //{
            //    Console.Write($"{i+1}: ");
            //    arr[i] = int.Parse(Console.ReadLine());

            //}
            //KeyBoardInputEnd

            //DemoCode
            /*string Path = @"QueueTest.txt";
            int[] array = { 0 };
            array = File.ReadAllText(Path).Split().Select(int.Parse).ToArray();*/
            int[] arr = new int[] { 2, 5, 4, 11, 256, 18, 22, 67, 51, 6, 7 };
            Console.WriteLine("У леприкона есть такие мешочки с таким колличеством золота:");
            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Мастер просит дать ему список из количеством сокровищ. Леприкон все посортировал, и получил следующий список:");
            Quick_Sort(arr, 0, arr.Length - 1);
            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Пока мастер думал, леприкон взял у соседей часть сокровищ в мешочках, и добавил ко своим:");
            int[] arr2 = new int[arr.Length + 5];
            for (int i = 0; i < arr.Length; i++)
            {
                arr2[i] = arr[i];
            }
            for (int i = arr.Length; i < arr2.Length; i++)
            {
                arr2[i] = 2 * i;
            }
            foreach (int n in arr2)
            {
                Console.Write(n + " ");
            }
            InsertionSort(arr2);
            Console.WriteLine();
            Console.WriteLine("Новый список: ");
            foreach (int n in arr2)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Соседям тоже такая идея понравилась, и они принесли свои сокровища леприкону, чтобы он разложил их по сундукам:");
            int[] arr3 = new int[arr2.Length + 50];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr3[i] = arr2[i];
            }

            for (int i = arr2.Length; i < arr3.Length; i++)
            {
                if(i > 15 && i <= 30)
                {
                    arr3[i] = 3;
                }
                if (i > 30 && i <= 45)
                {
                    arr3[i] = 70;
                }
                if (i > 45)
                {
                    arr3[i] = 80;
                }
            }
            foreach (int n in arr3)
            {
                Console.Write(n + " ");
            }
            CountSort(arr3);
            Console.WriteLine();
            Console.WriteLine("Новый список: ");
            foreach (int n in arr3)
            {
                Console.Write(n + " ");
            }
            //DemoCodeEnd
        }
    }
}