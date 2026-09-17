using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleAppLB10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            Task3();
        }

        public static void Task1() 
        {
            //LINQ с массивом. Фильтрация
            //Вариант 9. Создать новвый массив из всех чисел кратных 7. Определить, есть ли в массиве хотябы одно чило, кратоное 5
            Console.WriteLine("--- Начало Задания 1 ---");
            Random rnd = new Random();
            int[] array = new int[30];


            for (int i = 0; i < array.Length; i++) 
            {
                array[i] = rnd.Next(-50, 51);
            }

            Console.WriteLine("Исходный массив");
            ShowArray(array);

            var result1 = from x in array where x % 7 == 0 select x;
            var result2 = array.Where(x => x % 7 == 0);

           int[] res = result1.ToArray();
           int[] res2 =  result2.ToArray();

            Console.WriteLine("Массив после фильтрации(Query syntax)");
            ShowArray(res);

            Console.WriteLine("Массив после фильтрации(Method syntax)");
            ShowArray(res2);

            
            bool has1 = (from n in array where n % 5 == 0 select n).Any();
            bool has2 = array.Any(n  => n % 5 == 0);

            Console.WriteLine($"Есть число, кратное 5 (query syntax): {has1}");
            Console.WriteLine($"Есть число, кратное 5 (method syntax): {has2}");

            Console.WriteLine("--- Конец Задания 1 ---");
        }

        public static void Task2()
            
        
        {   //LINQ с массивом. Группировака и агрегатый операции
            //Вариант  9. Вычислить произведение минимального и максимального чисел. Сгруппировать четные и нечетные числа, оприделить среднее значения для каждой группы.
            Console.WriteLine("--- Начало Задания 2 ---");
            Random rnd = new Random();
            int[] array = new int[30];


            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-50, 51);
            }

            Console.WriteLine("Исходный массив");
            ShowArray(array);

            //Method syntax
            int max = array.Max();
            int min = array.Min();
            //Query syntax
            int max2 = (from n in array select n).Max();
            int min2 = (from n in array select n).Min();

            Console.WriteLine($"Произведение минимально {min} и максимального {max} = {max * min}");

            //Method syntax
            var groups = array.GroupBy(x => x%2 == 0 ? "четные":"нечетные");
            //Query syntax
            // var groups2 = from x in array group x by (x % 2 == 0 ? "четные" : "нечетные");

            foreach (var group in groups) 
            {
   
                Console.WriteLine($"{group.Key}");
                double groupAVG = group.Average();
                Console.WriteLine($"Среднее {groupAVG}");

                //Вывод группы 
                int[] arrayGroup = group.ToArray();
                ShowArray(arrayGroup);

            }

            Console.WriteLine("--- Конец Задания 2 ---");

        }

        public static void Task3() 
        {
            //LINQ с несколькими массивами
            //Вариант 9. 2 массива. Создайте новый массив - разность четных чисел из первого и положительных из второго

            Console.WriteLine("--- Начало Задания 3 ---");
            Random rnd = new Random();
            int[] array = new int[30];
            int[] array2 = new int[30];


            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-50, 51);
                array2[i] = rnd.Next(-50, 51);
            }

            Console.WriteLine("Исходный массив1");
            ShowArray(array);
            Console.WriteLine("Исходный массив2");
            ShowArray(array2);

            var even = array.Where(x => x % 2 == 0);
            var pos = array2.Where(x => x > 0);

            var res = even.Except(pos);

            int[] resArray = res.ToArray();
            Console.WriteLine("Результат разности массивов");
            ShowArray(resArray);
            Console.WriteLine("--- Конец Задания 3 ---");



        }
        public static void ShowArray(int[] array) 
        {
            int i = 0;
            foreach (int item in array) 
            {
                i++;

                if (i == array.Length)
                {
                    Console.Write($"{item}\n");
                }
                else
                {
                    Console.Write($"{item}|");
                }
            }
        }
    }
}
