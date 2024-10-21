using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Student
{
    class Group
    {
        private NameGroup namegroup;
        private int courseNumber;
        private bool passedSession;
        public List<Student> students;
        private Specialization specialization;

        enum NameGroup
        {
            P28,
            P26,
            P27,
            P25

        }
        enum Specialization
        {
            Math,
            ComputerScience,
            PE,
            Economy,
            WebDesign,
            GameDesign
        }

        public Group()
        {
            Inizialization();
        }

        public void Inizialization()
        {
            namegroup = GetRandomGroupName();
            specialization = GetRandomSpecialization();
            courseNumber = GetRandomCourseNumber();

            students = new List<Student>();
        }

        private NameGroup GetRandomGroupName()
        {
            Random rand = new Random();
            Array values = Enum.GetValues(typeof(NameGroup));
            return (NameGroup)values.GetValue(rand.Next(values.Length));
        }
        private Specialization GetRandomSpecialization()
        {
            Random rand = new Random();
            Array values = Enum.GetValues(typeof(Specialization));
            return (Specialization)values.GetValue(rand.Next(values.Length));
        }

        private int GetRandomCourseNumber()
        {
            Random rand = new Random();
            return rand.Next(1, 5);
        }

        public Group(Group other)
        {
            namegroup = other.namegroup;
            specialization = other.specialization;
            courseNumber = other.courseNumber;
            passedSession = other.passedSession;
            students = new List<Student>();
        }


        public List<Student> GetStudents()
        {
            return students;
        }

        public void CountMarks()
        {
            foreach (var student in students)
            {
                double resultmarks = ((student.GetExams().Sum() / 2) + (student.homeworks.Sum() / 13) + (student.courseWorks.Sum() / 4)) / 3;

                if (resultmarks <= 6)
                {
                    Console.WriteLine($" {student.surname} {student.name} не набрал нужный бал :((");
                    passedSession = false;
                }
                else
                {
                    Console.WriteLine($" {student.surname} {student.name} набрал нужный бал!!!");
                    passedSession = true;
                }
            }
        }

        public void ShowAllStudents()
        {
            if (students.Count > 0)
            {
                Console.WriteLine("Информация о группе:");
                PrintGroup();
                Console.WriteLine();
            }

            var sortedStudents = students.OrderBy(s => s.surname).ToList();


            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"Фамилия: {student.surname}");
                Console.WriteLine($"Имя: {student.name}");
                Console.WriteLine($"Отчество: {student.papaname}");
                Console.WriteLine($"Адрес: {student.adress}");
                Console.WriteLine($"Телефон: {student.number}");

                Console.Write("Домашние задания: ");
                foreach (int mark in student.homeworks)
                {
                    Console.Write(mark + " ");
                }
                Console.WriteLine();

                Console.Write("Курсовые работы: ");
                foreach (int mark in student.courseWorks)
                {
                    Console.Write(mark + " ");
                }
                Console.WriteLine();

                Console.Write("Экзамены: ");
                foreach (int mark in student.exams)
                {
                    Console.Write(mark + " ");
                }
                Console.WriteLine();

                Console.WriteLine();
            }

            Console.WriteLine("Остальная информация:");
            CountMarks();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void EditGroup(int newCourseNumber)
        {
            courseNumber = newCourseNumber;
            Console.WriteLine($"Номер курса обновлен на {courseNumber}.");
        }

        public void PerevodStudent(Group targetGroup, Student student)
        {
            if (students.Contains(student))
            {
                students.Remove(student);
                targetGroup.AddStudent(student);
            }
        }

        public void FailedStudents()
        {
            List<Student> failedStudents = new List<Student>();

            foreach (var student in students)
            {
                double averageMark = ((student.exams.Sum() / (double)student.exams.Count));

                if (averageMark < 6)
                {
                    failedStudents.Add(student);
                }
            }

            foreach (var failedStudent in failedStudents)
            {
                students.Remove(failedStudent);
                Console.WriteLine($"Студент {failedStudent.surname} {failedStudent.name} {failedStudent.papaname} был удален за низкий средний балл за экзамены.");
            }

            Console.WriteLine($"Количество отчисленных студентов: {failedStudents.Count}");
        }

        public void RemoveWorstStudent()
        {
            Student worstStudent = null;
            double worstAverage = double.MaxValue;

            foreach (var student in students)
            {
                double averageMark = ((student.exams.Sum() / (double)student.exams.Count) + (student.homeworks.Sum() / (double)student.homeworks.Count) + (student.courseWorks.Sum() / (double)student.courseWorks.Count)) / 3;

                if (averageMark < worstAverage)
                {
                    worstAverage = averageMark;
                    worstStudent = student;
                }
            }

            if (worstStudent != null)
            {
                students.Remove(worstStudent);
                Console.WriteLine($"Студент {worstStudent.surname} {worstStudent.name} {worstStudent.papaname} был удален из группы за самый низкий средний балл.");
            }
        }

        public void PrintGroup()
        {
            Console.WriteLine($"Имя группы: {namegroup}");
            Console.WriteLine($"Специализация: {specialization}");
            Console.WriteLine($"Номер курса: {courseNumber}");
        }

        public static bool operator ==(Group group1, Group group2)
        {
            return group1.students.Count == group2.students.Count;
        }

        public static bool operator !=(Group group1, Group group2)
        {
            return !(group1 == group2);
        }

    }

}
