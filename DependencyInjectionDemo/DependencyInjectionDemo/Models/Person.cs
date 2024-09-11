using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Models
{
    public class Person
    {
        private Home _home;
        private IEducationalInstitutions _school;
        private Hospital _hospital;


        public IEducationalInstitutions school
        {
            set { _school = value; }
        }

        public Person(Home home)
        {
            _home = home;
            _school = new School();
            _hospital = new Hospital();
        }

        public void TakeRefuge()
        {
            _home.ProvideShelter(this);
        }

        public void Study()
        {
            _school.Teach(this);
        }

        public void GetTreatment(Hospital hospital)
        {
            hospital.Cure(this);
        }
    }
}
