using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.Demo
{
    internal interface ICab
    {
        string Name { get; }    
        int Currentlocation { get; }
        bool IsFree {  get; }
        void Assign(string name, string address);

    }

    internal class Cab : ICab
    {
        public Cab(string name,int currentlocation,bool isfree)
        {
            _name = name;
            _location = currentlocation;
            _free = isfree;
        }

        private readonly string _name;
        private readonly int _location;
        private readonly bool _free;

        public string Name => _name;

        public int Currentlocation => _location;

        public bool IsFree => _free;

        public void Assign(string name, string address) => Console.WriteLine($"Cab {Name}, assigned to passenger : {name},{address}"); 
    }
}
