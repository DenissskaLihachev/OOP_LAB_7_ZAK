using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public abstract class  Human
    {
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }
        public abstract string Gender { get; set; }
        public abstract void Print();
    }
    ///////////////////////////////////////
    public abstract class Employee : Human
    {
        private string name;
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public override int Age
        {
            get { return age; }
            set { if (value > 18) age = value; }
        }

        private string gender;
        public override string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private int salary;
        public int Salary
        {
            get { return salary; }
            set { if (value >= 0) salary = value; }
        }

        private int experience;
        public int Experience
        {
            get { return experience; }
            set { if (value >= 0) experience = value; }
        }

        public abstract int Calc_Salary();

        public override void Print()
        {
            Console.WriteLine($"Имя - [{name}] | Возраст - [{age}] | Пол - [{gender}] | Стаж - [{experience}] | Оклад - [{salary}]");
        }

        static public void Print_Salary(List<Employee> employees)
        {
            foreach (var employee in employees)
                Console.WriteLine($"Имя - [{ employee.Name}] | Возвраст - [{employee.Age}] | Пол - [{employee.Gender}] | Стаж - [{employee.Experience}] | Зарплата - [{employee.Calc_Salary()}]");
            Console.WriteLine();
        }
    }
    public class Director : Employee
    {
        public Director()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Patronymic = "Undefined";
            Salary = 0;
            Experience = 0;
        }
        public Director(string name, string patronymic, int age, string gender, int salary, int experience)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Patronymic = patronymic;
            Salary = salary;
            Experience = experience;
        }

        private string patronymic;
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Отчество - [{patronymic}] | Возраст - [{Age}] | Пол - [{Gender}] | Стаж - [{Experience}] | Оклад - [{Salary}]");
        }
        public override int Calc_Salary()
        {
            double period_of_service = this.Experience > 20 ? 0.20 : this.Experience * 0.01;
            return (int)Math.Round(period_of_service * this.Salary + this.Salary);
        }
    }
    public class Worker : Employee
    {
        public Worker()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Post = "undefined";
            Salary = 0;
            Experience = 0;
        }
        public Worker(string name, int age, string gender, string post, int salary, int experience)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Post = post;
            Salary = salary;
            Experience = experience;
        }

        private string post;
        public string Post
        {
            get { return post; }
            set { post = value; }
        }
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Возраст - [{Age}] | Пол - [{Gender}] | Должность - [{Post}] | Стаж - [{Experience}] | Оклад - [{Salary}]");
        }
        public override int Calc_Salary()
        {
            double period_of_service;
            if (this.Experience < 5)
                period_of_service = this.Experience * 0.01;
            else if (this.Experience == 5)
                period_of_service = 0.05;
            else if (this.Experience > 5 && this.Experience < 10)
                period_of_service = this.Experience * 0.01 + 0.05;
            else
                period_of_service = 0.1;
            return (int)Math.Round(period_of_service * this.Salary + this.Salary);
        }
    }
    ///////////////////////////////////////
    public abstract class Learner : Human
    {
        private string name;
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public override int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string gender;
        public override string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public override void Print()
        {
            Console.WriteLine($"Имя - [{name}] | Возраст - [{age}] | Пол - [{gender}]");
        }
    }
    public class Schoolboy : Learner
    {
        public Schoolboy()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Clas = 0;
        }
        public Schoolboy(string name, int age, string gender, int clas)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Clas = clas;
        }
        //public override int Age       //stack overflow???
        //{
        //    get { return Age; }
        //    set { Age = value; }
        //}

        private int?[] marks = new int?[11];
        public int?[] Marks
        {
            get => marks;
            set
            {
                int j = 0;
                for (int i = 0; i < marks.Length; i++)
                {
                    if (value.Length <= i) marks[j] = null;
                    else if (value[i] < 6 && value[i] > 0) { marks[j] = value[i]; j++; }
                    else continue;
                }
            }
        }
        private int cur_class;
        public int Cur_Class
        {
            get
            {
                for (int i = 0; i < marks.Length; i++)
                    if (marks[i] != null)
                        cur_class = i + 1;
                return ++cur_class;
            }
        }
        private int next_mark;
        public int Next_Mark
        {
            get
            {
                next_mark = GeneralizedClass<Schoolboy>.Forecast(marks);
                return next_mark;
            }
        }


        private int clas;
        public int Clas
        {
            get { return clas; }
            set { if(value >= 0 && value < 11) clas = value; }
        }
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Возраст - [{Age}] | Пол - [{Gender}] | Класс - [{Clas}]");
        }
        public override string ToString()
        {
            string marks = "";
            for (int i = 0; i < this.Marks.Length; i++)
                marks += this.Marks[i] + " ";
            return "Имя - [" + this.Name + "] | Возвраст - [" + this.Age + "] | Пол - [" + Gender + "] | Класс - [" + Clas + "] | Оценки - [" + marks + "] Прогноз оценики - [" + this.Next_Mark + "] Текущий класс - [" + this.Cur_Class + "]\n";
        }
    }
    public class Student : Learner
    {
        public Student()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Specialization = "Undefined";
        }
        public Student(string name, int age, string gender, string specialization)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Specialization = specialization;
        }

        private int?[] marks = new int?[8];
        public int?[] Marks
        {
            get => marks;
            set
            {
                for (int i = 0; i < marks.Length; i++)
                {
                    if (value.Length <= i) marks[i] = null;
                    else marks[i] = value[i];
                }
            }
        }
        private int next_mark;
        public int Next_Mark
        {
            get
            {
                ///////tut///////
                next_mark = GeneralizedClass<Student>.Forecast(marks);
                return next_mark;
            }
        }
        private int cur_semestr;
        public int Cur_Semestr
        {
            get
            {
                for (int i = 0; i < marks.Length; i++)
                    if (marks[i] != null)
                    {
                        if ((i + 1) % 2 == 0)
                            cur_semestr = (i) / 2;
                        else
                            cur_semestr = (i + 1) / 2;
                    }
                return ++cur_semestr;
            }
        }

        private string specialization;
        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Возраст - [{Age}] | Пол - [{Gender}] | Специальность - [{Specialization}]");
        }
        public override string ToString()
        {
            string marks = "";
            for (int i = 0; i < this.Marks.Length; i++)
                marks += this.Marks[i] + " ";
            return "Имя - [" + this.Name + "] Возвраст - [" + this.Age + "] | Пол - [" + Gender + "] | Специальность - [" + this.Specialization + "] Оценки - [" + marks + "] Прогноз оценки - [" + this.Next_Mark + "] Текущий курс - [" + this.Cur_Semestr + "]\n";
        }
    }

    public static class GeneralizedClass<T> where T : Learner
    {
        
        //Возврат элемент из массива данных (если индекс элемента неправильный, то вернуть null).
        //Вывести данные всех элементов массива (используйте метод Вывод).
        //Сделать Прогноз для каждого элемента массива.
        

        public static Learner Get(List<Learner> learners, int index)
        {
            if (index < learners.Count)
                return learners[index];
            else
                return null;
        }
        public static void Print(List<Learner> learners)
        {
            learners.ForEach(x => Console.WriteLine(x.ToString()));
        }
        public static int Forecast(int?[] marks)
        {
            int summ = 0;
            int count = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] == null) break;
                summ += (int)marks[i];
                count = i + 1;
            }
            return (int)summ / count;
        }
    }
}
