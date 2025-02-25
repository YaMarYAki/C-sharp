using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Начало обработки оценок...");

        List<Student> students = new List<Student>
        {
            new Student("Маркидонов", new List<int> { 5, 4, 3, 5 }),
            new Student("Федорков", new List<int> { 2, 3, 3, 4 })
        };

        await Task.Run(() => ProcessGrades(students));

        Console.WriteLine("Обработка завершена.");
    }

    static void ProcessGrades(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Обрабатываем оценки для {student.LastName}...");
            Thread.Sleep(10000);
            double average = student.Grades.Count > 0 ? (double)student.Grades.Sum() / student.Grades.Count : 0;
            Console.WriteLine($"Средняя оценка {student.LastName}: {average:F2}");
        }
    }
}

class Student
{
    public string LastName { get; }
    public List<int> Grades { get; }

    public Student(string lastName, List<int> grades)
    {
        LastName = lastName;
        Grades = grades;
    }
}
