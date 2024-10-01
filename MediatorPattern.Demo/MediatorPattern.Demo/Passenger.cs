using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.Demo
{
    internal interface IPassenger
    {
        string Name { get; }
        string Address { get; }

        int location { get; }

        void AcKnowledge(string name);
    }

    internal class Passenger : IPassenger
    {
        public Passenger(string name,string address, int location)
        {
            name = _name;
            address = _address;
            location = _location;
        }
        private readonly string _name;
        private readonly string _address;
        private readonly int _location;
        public string Name => _name;

        public string Address => _address;

        public int location => _location;

        public void AcKnowledge(string name) => Console.WriteLine($"Passenger {Name}, Cab : {name}");
    }
}
