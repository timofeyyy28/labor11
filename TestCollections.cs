using ClassLibraryLabor10;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
                try
                {
                    Guitar guitar = new Guitar();
                    guitar.RandomInit();
                    Musicalinstrument musicalinstrument = new Musicalinstrument(guitar.Name, guitar.id.number);

                    queue1.Enqueue(musicalinstrument);
                    queue2.Enqueue(musicalinstrument.ToString());
                    sortedset1.Add(musicalinstrument);
                    sortedset2.Add(musicalinstrument.ToString());
                }
                catch (Exception e)
                {
                    i--;
                }
            }
        }

        public double MeasureSearchTimeCollection1(Musicalinstrument element)
        {
            Stopwatch stopwatch = new Stopwatch();
            long totalTicks = 0;

            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();
                this.queue1.Contains(element);
                stopwatch.Stop();
                totalTicks += stopwatch.ElapsedTicks;
            }

            return (double)totalTicks / 1000;
        }

        public double MeasureSearchTimeCollection2(string element)
        {
            Stopwatch stopwatch = new Stopwatch();
            long totalTicks = 0;

            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();
                this.queue2.Contains(element);
                stopwatch.Stop();
                totalTicks += stopwatch.ElapsedTicks;
            }

            return (double)totalTicks / 1000;
        }

        public double MeasureSearchTimeCollection3(Musicalinstrument element)
        {
            Stopwatch stopwatch = new Stopwatch();
            long totalTicks = 0;

            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();
                this.sortedset1.Contains(element);
                stopwatch.Stop();
                totalTicks += stopwatch.ElapsedTicks;
            }

            return (double)totalTicks / 1000;
        }

        public double MeasureSearchTimeCollection4(string element)
        {
            Stopwatch stopwatch = new Stopwatch();
            long totalTicks = 0;

            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Restart();
                this.sortedset2.Contains(element);
                stopwatch.Stop();
                totalTicks += stopwatch.ElapsedTicks;
            }

            return (double)totalTicks / 1000;
        }
        public void Get1TimeQueue1()
        {
            //получение первого элемента (последнего добавленного элемента)
            Musicalinstrument firstElement = queue1.Peek();

            //получение последнего элемента (первого добавленного элемента)
            Musicalinstrument lastElement = queue1.ToArray()[0];

            //получение центрального элемента
            Musicalinstrument centralElement = queue1.ToArray()[queue1.Count / 2];

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в очереди 1:");
            Console.WriteLine($"Первый найден за {MeasureSearchTimeCollection1(firstElement)} тактов");
            Console.WriteLine($"Последний найден за {MeasureSearchTimeCollection1(lastElement)} тактов");
            Console.WriteLine($"Центральный найден за {MeasureSearchTimeCollection1(centralElement)} тактов");
        }

        public void Get1TimeQueue2()
        {
            //получение первого элемента (последнего добавленного элемента)
            string firstElement = queue2.Peek();

            //получение последнего элемента (первого добавленного элемента)
            string lastElement = queue2.ToArray()[0];

            //получение центрального элемента
            string centralElement = queue2.ToArray()[queue2.Count / 2];

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в очереди 2:");
            Console.WriteLine($"Первый найден за {MeasureSearchTimeCollection2(firstElement)} тактов");
            Console.WriteLine($"Последний найден за {MeasureSearchTimeCollection2(lastElement)} тактов");
            Console.WriteLine($"Центральный найден за {MeasureSearchTimeCollection2(centralElement)} тактов");
        }

        public void Get1TimeSortedSet1()
        {
            //получение первого элемента (наименьшего элемента в отсортированном множестве)
            Musicalinstrument firstElement = sortedset1.Min;

            //получение последнего элемента (наибольшего элемента в отсортированном множестве)
            Musicalinstrument lastElement = sortedset1.Max;

            //получение центрального элемента
            int count = sortedset1.Count;
            Musicalinstrument centralElement = sortedset1.Skip(count / 2).FirstOrDefault();

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в сортированном множестве 1:");
            Console.WriteLine($"Первый найден за {MeasureSearchTimeCollection3(firstElement)} тактов");
            Console.WriteLine($"Последний найден за {MeasureSearchTimeCollection3(lastElement)} тактов");
            Console.WriteLine($"Центральный найден за {MeasureSearchTimeCollection3(centralElement)} тактов");
        }

        public void Get1TimeSortedSet2()
        {
            //получение первого элемента (наименьшего элемента в отсортированном множестве)
            string firstElement = sortedset2.Min;

            //получение последнего элемента (наибольшего элемента в отсортированном множестве)
            string lastElement = sortedset2.Max;

            //получение центрального элемента
            int count = sortedset2.Count;
            string centralElement = sortedset2.Skip(count / 2).FirstOrDefault();

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в сортированном множестве 2:");
            Console.WriteLine($"Первый найден за {MeasureSearchTimeCollection4(firstElement)} тактов");
            Console.WriteLine($"Последний найден за {MeasureSearchTimeCollection4(lastElement)} тактов");
            Console.WriteLine($"Центральный найден за {MeasureSearchTimeCollection4(centralElement)} тактов");
            
        }
        public void SearchElementNotInCollection()
        {
            //создание элемента, который не входит в коллекцию
            Musicalinstrument elementNotInCollection = new Musicalinstrument("элемент вне коллекции", 99999);

            //поиск элемента, который не входит в коллекцию
            bool foundInQueue1 = this.queue1.Contains(elementNotInCollection);
            bool foundInQueue2 = this.queue2.Contains(elementNotInCollection.ToString());
            bool foundInSortedSet1 = this.sortedset1.Contains(elementNotInCollection);
            bool foundInSortedSet2 = this.sortedset2.Contains(elementNotInCollection.ToString());

            Console.WriteLine("Поиск элемента, который не входит в коллекцию:");
            Console.WriteLine($"Элемент найден в очереди 1?: {foundInQueue1}");
            Console.WriteLine($"Элемент найден в очереди 2?: {foundInQueue2}");
            Console.WriteLine($"Элемент найден в сортированном множестве 1?: {foundInSortedSet1}");
            Console.WriteLine($"Элемент найден в сортированном множестве 2?: {foundInSortedSet2}");
        }
    }
}
