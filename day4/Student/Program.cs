using System;
using System.Collections.Generic;

namespace GrandmenuStudent
{
    enum Subject
    {
        ISiT,
        SA,
        Graph3D,
        AEVM,
        MO,
        Web
    }

    interface Inter
    {
        void AddGrade();
        void ViewGrades();
        void RemoveGrade();
    }

    class Grade
    {
        public Subject Subject { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public Grade(Subject subject, int score)
        {
            Subject = subject;
            Score = score;
            Date = DateTime.Now;
        }
    }

    class Base
    {
        protected List<Grade> grades = new List<Grade>();
    }

    class Menu : Base, Inter
    {
        public void AddGrade()
        {
            Console.WriteLine("Выберите предмет (0 - ISiT, 1 - SA, 2 - GRAPH3D, 3 - AEVM, 4 - MO, 5 - WEB): ");
            if (int.TryParse(Console.ReadLine(), out int subjectIndex) && Enum.IsDefined(typeof(Subject), subjectIndex))
            {
                Subject subject = (Subject)subjectIndex;
                Console.Write("Введите оценку: ");
                if (int.TryParse(Console.ReadLine(), out int score) && score >= 0 && score <= 5)
                {
                    grades.Add(new Grade(subject, score));
                    Console.WriteLine("Оценка добавлена");
                }
                else
                {
                    Console.WriteLine("Некорректная оценка");
                }
            }
            else
            {
                Console.WriteLine("Некорректный предмет");
            }
        }

        public void ViewGrades()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("Нет оценок");
                return;
            }
            Console.WriteLine("Список оценок:");
            foreach (var grade in grades)
            {
                Console.WriteLine($"Предмет: {grade.Subject}, Оценка: {grade.Score}, Дата: {grade.Date}");
            }
        }

        public void RemoveGrade()
        {
            Console.Write("Введите номер оценки: ");
            if (int.TryParse(Console.ReadLine(), out int gradeIndex) && gradeIndex > 0 && gradeIndex <= grades.Count)
            {
                grades.RemoveAt(gradeIndex - 1);
                Console.WriteLine("Оценка удалена");
            }
            else
            {
                Console.WriteLine("Некорректный номер оценки");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Inter gradeMenu = new Menu();

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить оценку");
                Console.WriteLine("2. Показать оценки");
                Console.WriteLine("3. Удалить оценку");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите пункт: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": gradeMenu.AddGrade(); break;
                    case "2": gradeMenu.ViewGrades(); break;
                    case "3": gradeMenu.RemoveGrade(); break;
                    case "4": return;
                    default: Console.WriteLine("Ошибка"); break;
                }
            }
        }
    }
}
