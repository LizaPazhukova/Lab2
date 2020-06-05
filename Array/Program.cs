using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomArray<int> list = new CustomArray<int>(-10, 8)
            {
                [-10] = 1,
                [0] = 10,
                [8] = 20
            };

            CustomArray<int> list1 = new CustomArray<int>(0, 1)
            {
                [0] = 10
               // [1] = 1
            };
            list1.Add(5);
            list1.Add(6);
            CustomArray<string> list2 = new CustomArray<string>(0, 1);
            string insert = "Liza";
            // Act
            list2.Add(insert);


            //int[] arr = new int[100];

            //list.CopyTo(arr,0);
            //foreach(int i in arr)
            //{
            //    Console.WriteLine(i) ;
            //}
            //list.InsertByIndex(1, 5);
            //bool res = list.Remove(2);
            //Console.WriteLine(res);
            //list.InsertByIndex(2, 1);
            //list.DeleteElement(1);
            //bool f = list.Contains(2);
            //Console.WriteLine(f);
            //list.PushFront(1);
            //  list.Add(2);
            //var n = list.GetNth(0);
            //Console.WriteLine(n);
            //       list.InsertByIndex(3, 2);
            //   list.Display();
            //list.Clear();
            foreach (var d in list)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine(list.Count);

            foreach (var d in list1)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine(list1.Count);
            foreach (var d in list2)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine(list1.Count);
            Console.ReadKey();

            
        }

    }
}
