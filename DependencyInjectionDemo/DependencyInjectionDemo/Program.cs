using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Home home = new Home();
            Person person = new Person(home);
            person.TakeRefuge();
            person.school = new College();
            person.Study();
            person.GetTreatment(new Hospital());
        }
    }

}
