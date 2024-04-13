using ClassLibraryLabor10;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//теперь происходит поиск непосредственно самих элементов,а не ссылок
//лишние peek и firstordefault убраны
//теперь время поиска корректно
namespace Laba11
{
    internal class TestCollections
    {
        public Queue<Musicalinstrument> queue1;
        public Queue<string> queue2;
        public SortedSet<Musicalinstrument> sortedset1;
        public SortedSet<string> sortedset2;

        public TestCollections()
        {
            queue1 = new Queue<Musicalinstrument>();
            queue2 = new Queue<string>();
            sortedset1 = new SortedSet<Musicalinstrument>();
            sortedset2 = new SortedSet<string>();

            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                Guitar guitar = new Guitar();
                guitar.RandomInit();
                Musicalinstrument musicalinstrument = new Musicalinstrument(guitar.Name, guitar.id.number);
                string strRepresentation = musicalinstrument.ToString();

                queue1.Enqueue(musicalinstrument);
                queue2.Enqueue(strRepresentation);
                sortedset1.Add(musicalinstrument);
                sortedset2.Add(strRepresentation);
            }
        }

        public double MeasureSearchTimeCollection1(Musicalinstrument element)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long totalTicks = 0;

            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();
                bool found = false;
                foreach (var item in queue1)
                {
                    if (item.Name == element.Name && item.id.number == element.id.number)
                    {
                        found = true;
                        break;
                    }
                }
                stopwatch.Stop();
                totalTicks += stopwatch.ElapsedTicks;
            }

            return (double)totalTicks / 1000;
        }

        public double MeasureSearchTimeCollection2(string element)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long totalTicks = 0;

            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();
                bool found = queue2.Contains(element);
                stopwatch.Stop();
                totalTicks += stopwatch.ElapsedTicks;
            }

            return (double)totalTicks / 1000;
        }

        public double MeasureSearchTimeCollection3(Musicalinstrument element)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long totalTicks = 0;

            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();
                bool found = false;
                foreach (var item in sortedset1)
                {
                    if (item.Name == element.Name && item.id.number == element.id.number)
                    {
                        found = true;
                        break;
                    }
                }
                stopwatch.Stop();
                totalTicks += stopwatch.ElapsedTicks;
            }

            return (double)totalTicks / 1000;
        }

        public double MeasureSearchTimeCollection4(string element)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long totalTicks = 0;

            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();
                bool found = sortedset2.Contains(element);
                stopwatch.Stop();
                totalTicks += stopwatch.ElapsedTicks;
            }

            return (double)totalTicks / 1000;
        }

        public void Get1TimeQueue1()
        {
            Musicalinstrument[] array = queue1.ToArray();
            Musicalinstrument lastElement = array[array.Length - 1];
            Musicalinstrument firstElement = array[0];
            Musicalinstrument centralElement = array[array.Length / 2];

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в очереди 1:");
            Console.WriteLine($"Первый найден за {MeasureSearchTimeCollection1(firstElement)} тактов");
            Console.WriteLine($"Последний найден за {MeasureSearchTimeCollection1(lastElement)} тактов");
            Console.WriteLine($"Центральный найден за {MeasureSearchTimeCollection1(centralElement)} тактов");
        }

        public void Get1TimeQueue2()
        {
            string[] array = queue2.ToArray();
            string lastElement = array[array.Length - 1];
            string firstElement = array[0];
            string centralElement = array[array.Length / 2];

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в очереди 2:");
            Console.WriteLine($"Первый найден за {MeasureSearchTimeCollection2(firstElement)} тактов");
            Console.WriteLine($"Последний найден за {MeasureSearchTimeCollection2(lastElement)} тактов");
            Console.WriteLine($"Центральный найден за {MeasureSearchTimeCollection2(centralElement)} тактов");
        }

        public void Get1TimeSortedSet1()
        {
            Musicalinstrument[] array = sortedset1.ToArray();
            Musicalinstrument firstElement = array[0];
            Musicalinstrument lastElement = array[array.Length - 1];
            Musicalinstrument centralElement = array[array.Length / 2];

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в сортированном множестве 1:");
            Console.WriteLine($"Первый найден за {MeasureSearchTimeCollection3(firstElement)} тактов");
            Console.WriteLine($"Последний найден за {MeasureSearchTimeCollection3(lastElement)} тактов");
            Console.WriteLine($"Центральный найден за {MeasureSearchTimeCollection3(centralElement)} тактов");
        }

        public void Get1TimeSortedSet2()
        {
            string[] array = sortedset2.ToArray();
            string firstElement = array[0];
            string lastElement = array[array.Length - 1];
            string centralElement = array[array.Length / 2];

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в сортированном множестве 2:");
            Console.WriteLine($"Первый найден за {MeasureSearchTimeCollection4(firstElement)} тактов");
            Console.WriteLine($"Последний найден за {MeasureSearchTimeCollection4(lastElement)} тактов");
            Console.WriteLine($"Центральный найден за {MeasureSearchTimeCollection4(centralElement)} тактов");
        }

        public void SearchElementNotInCollection()
        {
            Musicalinstrument elementNotInCollection = new Musicalinstrument("элемент вне коллекции", 99999);

            bool foundInQueue1 = queue1.Contains(elementNotInCollection);
            bool foundInQueue2 = queue2.Contains(elementNotInCollection.ToString());
            bool foundInSortedSet1 = sortedset1.Contains(elementNotInCollection);
            bool foundInSortedSet2 = sortedset2.Contains(elementNotInCollection.ToString());

            Console.WriteLine("Поиск элемента, который не входит в коллекцию:");
            Console.WriteLine($"Элемент найден в очереди 1?: {foundInQueue1}");
            Console.WriteLine($"Элемент найден в очереди 2?: {foundInQueue2}");
            Console.WriteLine($"Элемент найден в сортированном множестве 1?: {foundInSortedSet1}");
            Console.WriteLine($"Элемент найден в сортированном множестве 2?: {foundInSortedSet2}");
        }
    }
}