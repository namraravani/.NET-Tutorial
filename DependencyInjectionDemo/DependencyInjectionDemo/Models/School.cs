﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Models
{
    public class School : IEducationalInstitutions
    {
        public void Teach(Person person)
        {
            Console.WriteLine("Study Well");
        }
    }
}
