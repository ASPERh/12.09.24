using System;

namespace HW.Student
{
    class Program
    {
        static void Main()
        {
            Group group1 = new Group();
            Group group2 = new Group();
            Group group3 = new Group();

            Student Stud1 = new Student("Дима", "Шевелеёв", "Алексеевич", "Новосельского 41", 3807340555555);
            Student Stud2 = new Student("Илья", "Нестеров", "Александрович", "Новосельского 41", 3807347255555);
            Student Stud3 = new Student("Данил", "Грачов", "Васильич", "Новосельского 32", 3807348455555);
            Student Stud4 = new Student("Вадим", "Некрасов", "Анатоливич", "Новосельского 2", 3807348455555);
            Student Stud5 = new Student("Валентин", "Горбачев", "Виталивич", "Новосельского 12", 3807348455555);
            Student Stud6 = new Student("Влад", "Радан", "Элденрингович", "Новосельского 61", 3807348455555);

            Stud1.GenericHomeworks();
            Stud1.GenericCoursWorks();
            Stud1.GenericExams();

            Stud2.GenericHomeworks();
            Stud2.GenericCoursWorks();
            Stud2.GenericExams();

            Stud3.GenericHomeworks();
            Stud3.GenericCoursWorks();
            Stud3.GenericExams();

            Stud4.GenericHomeworks();
            Stud4.GenericCoursWorks();
            Stud4.GenericExams();

            Stud5.GenericHomeworks();
            Stud5.GenericCoursWorks();
            Stud5.GenericExams();

            Stud6.GenericHomeworks();
            Stud6.GenericCoursWorks();
            Stud6.GenericExams();

            group1.AddStudent(Stud1);
            group1.AddStudent(Stud2);
            group2.AddStudent(Stud3);
            group2.AddStudent(Stud4);
            group3.AddStudent(Stud5);
            group3.AddStudent(Stud6);

            group1.ShowAllStudents();
            group2.ShowAllStudents();
            group3.ShowAllStudents();

            Console.WriteLine("Введите новый номер курса для группы 1 (от 1 до 4):");
            if (int.TryParse(Console.ReadLine(), out int newCourseNumber1) && newCourseNumber1 >= 1 && newCourseNumber1 <= 4)
            {
                group1.EditGroup(newCourseNumber1);
            }
            else
            {
                Console.WriteLine("Некорректный ввод номера курса.");
            }

            Console.WriteLine("\nОбновленная информация о группе 1:");
            group1.ShowAllStudents();

            Group newGroup = new Group();
            group1.PerevodStudent(newGroup, Stud1);
            group3.PerevodStudent(newGroup, Stud5);
            newGroup.PrintGroup();

            foreach (var student in group1.GetStudents())
            {
                Console.WriteLine($"\n{student.GetSurname()} {student.GetName()} {(student ? "сдал" : "не сдал")}");
            }
            foreach (var student in group2.GetStudents())
            {
                Console.WriteLine($"\n{student.GetSurname()} {student.GetName()} {(student ? "сдал" : "не сдал")}");
            }
            foreach (var student in group3.GetStudents())
            {
                Console.WriteLine($"\n {student.GetSurname()} {student.GetName()} {(student ? "сдал" : "не сдал")}");
            }

            if (Stud5 == Stud4)
            {
                Console.WriteLine("\nУ студентов Валентин и Вадим одинаковые номера");
            }
            else
            {
                Console.WriteLine("\nУ студентов Валентин и Вадим не одинаковые номера");
            }

            if (Stud1 != Stud2)
            {
                Console.WriteLine("\nУ студентов Дима и Илья не одинаковые номера");
            }

            if (Stud1 > Stud2)
            {
                Console.WriteLine("\nДима имеет лучший средний балл, чем Илья");
            }
            else if (Stud1 < Stud2)
            {
                Console.WriteLine("\nИлья имеет лучший средний балл, чем Дима");
            }
            else
            {
                Console.WriteLine("\nУ студентов одинаковые средние баллы");
            }

            if (group1 == group2)
            {
                Console.WriteLine("\nГруппы 1 и 2 равны по количеству студентов.");
            }
            else
            {
                Console.WriteLine("\nГруппы 1 и 2 не равны по количеству студентов.");
            }



            Console.WriteLine("\nУдаление студентов с низким средним баллом и самого худшего студента:");
            group1.FailedStudents();
            group1.RemoveWorstStudent();
        }
    }
}