using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Models
{
    public class Hospital
    {
        public void Cure(Person person)
        {
            Console.WriteLine("I am Getting Cured");
        }
    }
}
