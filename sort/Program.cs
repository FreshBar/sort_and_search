﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    class Program
    {
        static void swap(int[] Array, int i, int j)
        {
            int tmp = Array[i];
            Array[i] = Array[j];
            Array[j] = tmp;
        }
        static void bubbleSort(int[] Array)
        {
            bool replace;
            do
            {
                replace = false;
                for (int i = 0; i < Array.Length - 1; i++)
                {

                    if (Array[i] > Array[i + 1])
                    {
                        swap(Array, i, i + 1);
                        replace = true;
                    }

                }
            } while (replace == true);
            
           
        }
        static void quickSort(int[] Array, int left, int right)
        {
            //Console.WriteLine("Начало вызова");
            int i, last;
            if (left >= right)
            {
                return;
            }
            swap(Array, left, (left + right) / 2);
            last = left;
            for (i = left + 1; i <= right; i++)
            {
                if (Array[i] < Array[left])
                {
                    //Console.WriteLine("Переставляем " + Array[last+1] + " и " + Array[i]);
                    swap(Array, ++last, i);
                }
            }
            swap(Array, left, last);
            quickSort(Array, left, last - 1);
            quickSort(Array, last + 1, right);
        }
        static int simpleSearch(int[] Array, int num)
        {
            for(int i = 0; i < Array.Length; i++)
            {
                if(num == Array[i])
                {
                    return i;
                }

            }
            return -1;            
        }
        static int binarySearch(int[] Array, int num)
        {
            int low = 0, high = Array.Length-1;
            
            while(low <= high)
            {
                int mid = (low + high) / 2;
                if( Array[mid] == num)
                {
                    return mid;
                }
                else if(Array[mid] > num)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

            }

            return -1; 
        }
        

        static void fill_Array(int[] Array, int choice)
        {
            Random rnd = new Random();
            if (choice == 1)
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    Array[i] = Convert.ToInt32(Console.ReadLine());
                }
                
            }
            else if (choice == 2)
            {

                for (int i = 0; i < Array.Length; i++)
                {
                    Array[i] = rnd.Next();
                }
                
            }

        }
        static void Main(string[] args)
        {

            string check = "y";
            do
            {
                while (true)
                {

                    Console.Write("Сравнить сортировки-1\nСравнить поиски-2\n");
                    int menu = Convert.ToInt32(Console.ReadLine());
                    
                    if (menu == 1)
                    {
                        Console.Write("Введите количество элементов:");  
                        int N = Convert.ToInt32(Console.ReadLine());
                        int[] Array = new int[N];
                        int[] Array1 = new int[N];
                        int[] Array2 = new int[N];
                        while (true)
                        {
                            Console.Write("Вручную-1\nСгенерировать-2\n");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if(choice == 1 || choice == 2)
                            {
                                fill_Array(Array, choice);
                                break;
                            }
                           
                            else
                            {
                                Console.WriteLine("Выбран несуществующий пункт!");
                            }
                        }
                        Array.CopyTo(Array1, 0);
                        Array.CopyTo(Array2, 0);
                        Stopwatch sWatch = new Stopwatch();
                        sWatch.Start();
                        quickSort(Array1, 0, Array1.Length - 1);
                        sWatch.Stop();
                       /* for (int i = 0; i < Array1.Length; i++)
                        {
                            Console.WriteLine(Array1[i]);
                        }*/
                        Console.WriteLine("Скорость выполнения алгоритма быстрой сортировки: " + sWatch.Elapsed.ToString());
                        Console.WriteLine("Трудоемкость алгоритма быстрой сортировки: " + N*((Math.Log10(N)) / Math.Log10(2)));
                        sWatch.Reset();
                        sWatch.Start();
                        bubbleSort(Array2);
                        sWatch.Stop();
                        Console.WriteLine("Скорость выполнения алгоритма пузырьковой сортировки: " + sWatch.Elapsed.ToString());
                        Console.WriteLine("Трудоемкость алгоритма пузырьковой сортировки: " + N*N);
                        break;
                    }
                    else if (menu == 2)
                    {
                        Console.Write("Введите количество элементов:");
                        int N = Convert.ToInt32(Console.ReadLine());
                        int[] Array = new int[N];

                        while (true)
                        {
                            Console.Write("Вручную-1\nСгенерировать-2\n");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 1 || choice == 2)
                            {
                                fill_Array(Array, choice);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Выбран несуществующий пункт!");

                            }
                            continue;
                        }

                        Console.Write("Введите число:");
                        int num = Convert.ToInt32(Console.ReadLine());
                        quickSort(Array, 0, Array.Length - 1);
                        Stopwatch sWatch = new Stopwatch();
                        sWatch.Start();
                        int result = simpleSearch(Array, num);
                        sWatch.Stop();
                        if (result == -1)
                        {
                            Console.WriteLine("Число не найдено!");
                        }
                        Console.WriteLine("Скорость выполнения алгоритма линейного поиска: " + sWatch.Elapsed.ToString());
                        Console.WriteLine("Трудоемкость алгоритма линейного поиска: " + N);
                        sWatch.Reset();
                        sWatch.Start();
                        binarySearch(Array, num);
                        sWatch.Stop();
                        Console.WriteLine("Скорость выполнения алгоритма бинарного поиска: " + sWatch.Elapsed.ToString());
                        Console.WriteLine("Трудоемкость алгоритма бинарного поиска: " + (Math.Log10(N))/Math.Log10(2));

                    }

                    else
                    {
                        Console.WriteLine("Выбран несуществующий пункт!");
                        continue;
                    }
                    break;
                }
                    /*            bubbleSort(Array);
                                Console.WriteLine("После сортировки");
                                for (int i = 0; i < Array.Length; i++)
                                {
                                    Console.WriteLine(Array[i]);
                                }
                                Console.Write("В позиции: ");
                                Console.WriteLine(binarySearch(Array, 69));*/
                    Console.WriteLine("\nХотите продолжить? (y/n)");
                    check = Convert.ToString(Console.ReadLine());

                    
                }
            while (check == "y");
            }
        }
}
