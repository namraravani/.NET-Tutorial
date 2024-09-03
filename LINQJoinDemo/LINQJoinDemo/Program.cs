namespace LINQJoinDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>() {
                new Student() { Id = 1,Name = "A",AddressId = 1},
                new Student() { Id = 2,Name = "B",AddressId = 2},
                new Student() { Id = 3,Name = "C",AddressId = 3},
                new Student() { Id = 4,Name = "D",AddressId = 4},
                new Student() { Id = 5,Name = "E",AddressId = 5},
                new Student() { Id = 6,Name = "F",AddressId = 6},
                new Student() { Id = 7,Name = "G",AddressId = 7},
                };

            var addresses = new List<Address>() {
                new Address() { Id = 1, AddressLine = "Line 1" },
                new Address() { Id = 2, AddressLine = "Line 2" },
                new Address() { Id = 3, AddressLine = "Line 3" },
                new Address() { Id = 4, AddressLine = "Line 4" },
                new Address() { Id = 5, AddressLine = "Line 5" },
                new Address() { Id = 6, AddressLine = "Line 6" },
                new Address() { Id = 7, AddressLine = "Line 7" },
                new Address() { Id = 8, AddressLine = "Line 8" },
                new Address() { Id = 9, AddressLine = "Line 9" },
            };

            var marks = new List<Marks>()
            {
                new Marks(){Id=1,StudentId=1,TMarks = 30},
                new Marks(){Id=2,StudentId=2,TMarks = 60},
                new Marks(){Id=3,StudentId=3,TMarks = 90},
            };

            //var ms = students.Join(addresses, std => std.AddressId, address => address.Id,
            //    (std, address) => new { StudentName = std.Name, Line = address.AddressLine }).ToList();

            //var qs = (from student in students
            //          join address in addresses
            //          on student.AddressId equals address.Id
            //          select new
            //          {
            //              StudentName = student.Name,
            //              Line = address.AddressLine
            //          }).ToList();


            var ms1 = students.Join(addresses, std => std.AddressId, address => address.Id,
                (std, address) => new { StudentName = std.Name, Line = address.AddressLine }).ToList();

            var qs = (from student in students
                      join address in addresses
                      
                      on student.AddressId equals address.Id
                      join mark in marks
                      on student.Id equals mark.StudentId

                      select new
                      {
                          StudentName = student.Name,
                          Line = address.AddressLine,
                          Marks = mark.TMarks,
                      }).ToList();

            foreach (var student in qs)
            {
                Console.WriteLine("Name :- " + student.StudentName + "  AddressLine :- " + student.Line + "  Total Marks :- " + student.Marks) ;
            }
        }
    }

}
