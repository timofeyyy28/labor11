using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLabor10;

namespace Laba11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Часть 1
            Queue queue = new Queue();
            for (int i = 0; i < 5; i++)
            {
                Musicalinstrument mi1 = new Musicalinstrument();
                queue.Enqueue(mi1);
                mi1.RandomInit();
            }
            for (int i = 0; i < 5; i++)
            {
                Guitar g1 = new Guitar();
                g1.RandomInit();
                queue.Enqueue(g1);
            }
            foreach (object mi1 in queue)
            {
                Console.WriteLine(mi1.ToString());
            }
            Console.WriteLine($"Count={queue.Count}");

            // Поиск элемента в очереди
            Console.WriteLine("Введите элемент для поиска");
            Musicalinstrument mi2 = new Musicalinstrument();
            mi2.Init();

            if (queue.Contains(mi2))
            {
                Console.WriteLine("Элемент найден");
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }


            Console.WriteLine("Удаление первого элемента из очереди");
            queue.Dequeue();
            Console.WriteLine("Первый элемент удален");
            Console.WriteLine($"Count={queue.Count}");


            Console.WriteLine("Очередь после удаления элемента:");
            foreach (object item in queue)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("Добавление элемента в конец очереди");
            Musicalinstrument mi3 = new Musicalinstrument();
            mi3.Init();
            queue.Enqueue(mi3);
            Console.WriteLine("Элемент успешно добавлен");


            Console.WriteLine("Очередь после добавления элемента:");
            foreach (object item in queue)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Count={queue.Count}");

            // Клонирование очереди с помощью ToArray
            Queue clonedQueue = new Queue(queue.ToArray());

            Console.WriteLine("Склонированная очередь:");
            foreach (object item in clonedQueue)
            {
                Console.WriteLine(item.ToString());
            }

            // Сортировка очереди   
            var array = queue.ToArray();
            Array.Sort(array);

            // Очищаем исходную очередь
            queue.Clear();


            foreach (var item in array)
            {
                queue.Enqueue(item);
            }

            Console.WriteLine("Отсортированная очередь:");
            foreach (object item in queue)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Часть 2");
            // Часть 2
            SortedSet<Musicalinstrument> sortedSet = new SortedSet<Musicalinstrument>();

            for (int i = 0; i < 5; i++)
            {
                Musicalinstrument mi1 = new Musicalinstrument();
                sortedSet.Add(mi1);
                mi1.RandomInit();
            }
            for (int i = 0; i < 5; i++)
            {
                Guitar g1 = new Guitar();
                sortedSet.Add(g1);
                g1.RandomInit();
            }


            foreach (var item in sortedSet)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Count={sortedSet.Count}");


            Console.WriteLine("Введите элемент для поиска:");
            Musicalinstrument mi4 = new Musicalinstrument();
            mi4.Init();

            if (sortedSet.Contains(mi4))
            {
                Console.WriteLine("Элемент найден");
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }

            // Удаление первого элемента из множества
            Console.WriteLine("Удаление первого элемента из множества");
            sortedSet.Remove(sortedSet.Min);
            // Удаление первого элемента из множества
            Console.WriteLine("Удаление последнего элемента из множества");
            sortedSet.Remove(sortedSet.Max);

            Console.WriteLine("Первый элемент удален");
            Console.WriteLine($"Count={sortedSet.Count}");


            Console.WriteLine("Множество после удаления элемента:");
            foreach (var item in sortedSet)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("Добавление элемента в множество");
            Musicalinstrument mi5 = new Musicalinstrument();
            mi5.Init();
            sortedSet.Add(mi5);
            Console.WriteLine("Элемент успешно добавлен");


            Console.WriteLine("Множество после добавления элемента:");
            foreach (var item in sortedSet)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Count={sortedSet.Count}");

            TestCollections testCollections = new TestCollections();
            testCollections.Get1TimeQueue1();
            Console.WriteLine("___________");
            testCollections.Get1TimeQueue2();
            Console.WriteLine("___________");
            testCollections.Get1TimeSortedSet1();
            Console.WriteLine("___________");
            testCollections.Get1TimeSortedSet2();
            Console.WriteLine("___________");
            testCollections.SearchElementNotInCollection();       
        }
    }
}

