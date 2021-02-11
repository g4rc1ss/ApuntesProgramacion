using System;

namespace CursosAndEstudioCsharp._06_POO._12_BodiedMembers
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName { get; set; }
        public string Age { get; set; }


        //public string FullName
        //{
        //    get
        //    {
        //        return $"{Name} {Surname}";
        //    }
        //}

        //public string FullName => $"{Name} {Surname}";


        //public override string ToString()
        //{
        //    return $"{FullName}, {Age}";
        //}

        public override string ToString()
        {
            return $"{FullName}, {Age}";
        }

        private int age;
        public int Age2
        {
            get => age;
            set => age = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
        }

        //Constructores
        //public Student(string name, string surname, int age)
        //{
        //    Name = name;
        //    Surname = surname;
        //    Age2 = age;
        //}

        public Student(string name, string surname, int age)
        {
            (Name, Surname, Age2) = (name, surname, age);
        }
    }
}
