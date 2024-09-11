using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Models
{
    public class Home
    {
        public void ProvideShelter(Person person)
        {
            Console.WriteLine("Hello I am in shelter");
        }
    }
}
