using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionPractice
{
    public class Student
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }

        public Student(int id , string name, string firstName)
        {
            this.Id = id;
            this.Name = name;
            this.FirstName = firstName;
        }
    }                                 
}
