using ConsoleApp1;
using Microsoft.VisualBasic.FileIO;
using System.Reflection;

//List<Human> list = new List<Human>();
//list.Add(new Worker("Denis", 25, "Male", "Kto-to", 100000, 7));
//list.Add(new Director("NeDenis", "Afanasievich", 23, "Male", 100000, 5));
//list.Add(new Schoolboy("Zhora", 9, "Female", 3));
//list.Add(new Student("Sasuke", 30, "Male", "Programmer"));

//for (int i = 0; i < list.Count; i++)
//    list[i].Print();

//////////////////////////////////////////////////////////////////////////////////////////////////

//List<Employee> list = new List<Employee>();

//list.Add(new Worker("Chel1", 43, "Male", "Kto-to", 70000, 1));
//list.Add(new Director("Chel2", "Kto-tovich", 34, "Female", 90000, 2));
//list.Add(new Worker("Denis", 25, "Male", "Kto-to", 100000, 7));
//list.Add(new Director("NeDenis", "Afanasievich", 23, "Male", 100000, 5));

//Employee.Print_Salary(list);

//////////////////////////////////////////////////////////////////////////////////////////////////

List<Learner> list = new List<Learner>();
list.Add(new Schoolboy()
{
    Name = "Denis",
    Age = 11,
    Gender = "Male",
    Clas = 5,
    Marks = new int?[] { 3, 5, 4, 6, 5 }
});
list.Add(new Student()
{
    Name = "NeDenis",
    Age = 21,
    Gender = "Male",
    Specialization = "Programmer",
    Marks = new int?[] { 3, 5, 5, 2, 2, 4, 3 }
});
list.Add(new Schoolboy()
{
    Name = "Kto-to",
    Age = 13,
    Gender = "Male",
    Clas = 7,
    Marks = new int?[] { 3, 5, 4, 6, 5, 4, 3 }

});
list.Add(new Student()
{
    Name = "Chel",
    Age = 19,
    Gender = "Female",
    Specialization = "Builder",
    Marks = new int?[] { 3, 5, 5, 2, }
});
GeneralizedClass<Student>.Print(list);