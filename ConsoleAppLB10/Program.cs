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
            //Task3();
            //Task4();
            Task5();
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

        public static void Task4() 
        {
            List<Person> people = new List<Person>() 
            {
                new Person("Жмышенко", DateTime.Parse("15.02.1985"), "Специалист", 100, "ООО Мэгаюлюль"),
                new Person("Валакас", DateTime.Parse("17.02.1985"), "Грузчик", 100, "ООО Мэгаюлюль"),
                new Person("Каруман", DateTime.Parse("25.03.1975"), "Начальник", 100, "Пожилая ветка сакуры"),
                new Person("Александр", DateTime.Parse("05.10.1985"), "Специалист", 100, "Пожилая ветка сакуры"),
                new Person("Якобсон", DateTime.Parse("15.11.1985"), "Специалист", 100, "Пожилая ветка сакуры"),

            };

            List<ShortPerson> res = GetShortPersonByYearAndCompany(people, 1985, "Пожилая ветка сакуры");
            //Console.WriteLine(res);
            foreach (var person in res)
            {
                Console.WriteLine(person);
            }
            

        }
        public static void Task5() 
        {
            List<Person2> people = new List<Person2>()
            {
                new Person2("Жмышенко", 1985, "Специалист", 3000, new Company("ООО Мэгаюлюль", 2000)),
                new Person2("Валакас", 1985, "Грузчик", 2500, new Company("ООО Мэгаюлюль", 2000)),
                new Person2("Каруман", 1975, "Начальник", 7000,new Company("Пожилая ветка сакуры", 2010)),
                new Person2("Александр", 1985, "Специалист", 5500, new Company("Пожилая ветка сакуры", 2010)),
                new Person2("Якобсон", 1985, "Специалист", 5500,new Company("Пожилая ветка сакуры", 2010)),

            };

            var res = from p in people group p by p.Company.Name into g select new {Company = g.Key, TotalSallary = g.Sum(p => p.Selary) };

            foreach (var item in res) 
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine(res);



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

        public static List<ShortPerson> GetShortPersonByYearAndCompany(List<Person> people, int year, string company)
        {
           return people.Where(p => p.BirthDate.Year == year && p.Company == company).Select(p=> new ShortPerson(p.Name, p.BirthDate, p.Company)).ToList();
        }

      public  class Person 
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public string Position { get; set; }
            public decimal Selary { get; set; }
            public string Company { get; set; }

            public Person (string name, DateTime birthDate, string position, decimal selary, string company) 
            {
                Name = name;
                BirthDate = birthDate;
                Position = position;
                Selary = selary;
                Company = company;
            }
        }

        public class Company 
        {
            public string Name { get; set; }
            public int FoundedYear { get; set; }

            public Company(string name, int year) 
            {
                Name = name;
                FoundedYear = year;

            }

            public override string ToString()
            {
                return $"{Name} (основана в {FoundedYear})";
            }
        }
        
        public class Person2
        {
            public string Name { get; set; }
            public int BirthYear { get; set; }
            public string Position { get; set; }
            public decimal Selary { get; set; }
            public Company Company { get; set; }

            public Person2(string name, int birthDate, string position, decimal selary, Company company)
            {
                Name = name;
                BirthYear = birthDate;
                Position = position;
                Selary = selary;
                Company = company;
            }
        }

        public class ShortPerson 
        {
            public string Name {  set; get; }
            public DateTime BirthDate { set; get; }
            public string Company {  set; get; }

            public ShortPerson(string name, DateTime birthDate, string company) 
            {
                Name = name;
                BirthDate = birthDate;
                Company = company;
            }

            public override string ToString()
            {
                return $"{Name}, дата рождения: {BirthDate:dd.MM.yyyy}, компания: {Company}";
            }
        }

    }
}
