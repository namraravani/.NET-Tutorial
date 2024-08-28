using CollectionPractice;
using System;
using System.Collections;
namespace TwoDimensionalArayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2-D array Implementation
            //    int[,] RectangleArray = new int[4, 5];
            //    int a = 0;


            //    foreach (int i in RectangleArray)
            //    {
            //        Console.Write(i + " ");
            //    }
            //    Console.WriteLine("\n");


            //    for (int i = 0; i < RectangleArray.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < RectangleArray.GetLength(1); j++)
            //        {
            //            a += 5;
            //            RectangleArray[i, j] = a;
            //        }
            //    }


            //    for (int i = 0; i < RectangleArray.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < RectangleArray.GetLength(1); j++)
            //        {
            //            Console.Write(RectangleArray[i, j] + " ");
            //        }
            //    }
            //    Console.ReadKey();


            // List Implementation in c#
            //List<int > number = new List<int>();

            //number.Add(1);
            //number.Add(2);
            //number.Add(3);




            //foreach (int i in number)
            //{
            //    Console.WriteLine(i);
            //}

            // List Advance Implementation in c# using custom DataType
            //Student s1 = new Student(1,"Namra","Namra Ravani");




            //List<Student> StudentList = new List<Student>();
            //StudentList.Add(s1);

            //foreach (Student student in StudentList) {
            //    Console.WriteLine("Hello my Id is {0} and my name is namra {1} and my first name is {2}",student.Id,student.Name,student.FirstName);
            //}


            //ArrayList array = new ArrayList();

            //array.Add(s1);
            //array.Add(1);

            //Hashtable ht1 = new Hashtable();

            //ht1.Add(1, "Namra");
            //ht1.Add(2, "Namra Ravani");
            //ht1.Add(3, "Namra N");
            //ht1.Add(4, "Namra R");


            //foreach (DictionaryEntry item in ht1)
            //{
            //    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            //}

            //var fileInfo = new SortedDictionary<string, string>();
            //fileInfo.Add("txt","notepad.exe");
            //fileInfo.Add("exe","Hello.exe");
            //fileInfo.Add("cs", "Name.cs");


            //foreach (var item in fileInfo) {
            //    Console.WriteLine(item.Key + item.Value);
            //}

            //Console.WriteLine("This is the Implementation of Sorted List");

            //var fileInfoSortedList = new SortedList<int, string>();
            //fileInfoSortedList.Add(1,"Namra");
            //fileInfoSortedList.Add(2,"Namra R");    
            //fileInfoSortedList.Add(3,"Namra Ra");

            //foreach (var entry in fileInfoSortedList)
            //{
            //    Console.WriteLine(entry.Key + entry.Value);
            //}


            List<int> set = new List<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            set.Add(6);
            set.Add(2);


            HashSet<int> newHash = new HashSet<int>(set);

            foreach (int i in newHash) {
                Console.WriteLine(i);
            }








        }   
    }
}