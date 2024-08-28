using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    public class Student
    {
        private int _StdId;
        private string _Name;
        private string _Fname;

        public int StdId
        {
            set {
                if(value < 0)
                    Console.WriteLine("Id can't be Zero");
                else
                _StdId = value; 
            }
            get {
                return this._StdId;
            }

        }

        public string Name
        {
            set {
                _Name = value;
            }
            get {
                return this._Name;
            }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.StdId = 23;
            Console.WriteLine(s.StdId);
        }
    }

}
