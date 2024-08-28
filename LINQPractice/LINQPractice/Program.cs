using System;
using Dumpify;
namespace LINQPractice
{
    // Define the Books class
    public class Books
    {
        public int bookId { get; set; }
        public string title { get; set; }


        public Books(int bookId, string title)
        {
            this.bookId = bookId;
            this.title = title;
        }
    }

    public class Employee
    {
        public int EmpId { get; set; }

        public string    EmpName { get; set; }

        public int EmpSalary { get; set; }
    }





    class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<int> arr = [1, 2, 3, 4, 5, 6];
            IEnumerable<List<int>> Collection = [[1, 2, 3], [4, 5, 6]];

            //record Person(int id, string name, int age);

            IEnumerable<Books> List =
            [
                new(1,"Namra"),
                new(2,"Hasti"),
                new(1,"Yenish"),
                
            ];


            //arr.Where(x => x < 2).Dump();
            //arr.Take(3).Dump();
            //arr.Select((x,i) => $"{i}.{x}").Dump();
            //Collection.SelectMany(x => x).Dump();
            arr.All(x => x >2).Dump();
            arr.Where(x => x >1 ).Count().Dump();
            arr.Aggregate(10, (x, y) => x + y,x => (float)x / 2).Dump();
            arr.Distinct().Dump();
            List.DistinctBy(x => x.bookId).Dump();


            List<Employee> listEmployee = new List<Employee>
            {
                new Employee{EmpId = 1,EmpName="Namra",EmpSalary=10000 },
                new Employee{EmpId = 2,EmpName="Hasti",EmpSalary=20000 },
                new Employee{EmpId = 3,EmpName="Jatan",EmpSalary=10000 }
            };

            IEnumerable<Employee> result = listEmployee.Where(x => x.EmpSalary >= 10000).Dump();



        }   
    }
}
