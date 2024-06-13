using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Lab7
{
    internal class Program
    {
        static List<Student> Students;

        static void PrintStudents()
        {
            foreach (var student in Students)
            {
                Console.WriteLine(student.Info());
                Console.WriteLine();    
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Students = new List<Student>();
            FileStream fs = new FileStream("Lab7.students", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            try
            {
                Console.WriteLine("Читаємо дані з файлу...\n");
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    Student student1 = new Student();
                    for (int i = 0; i < 9; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                student1.Name = br.ReadString();
                                break;
                            case 2:
                                student1.Surname = br.ReadString();
                                break;
                            case 3:
                                student1.University = br.ReadString();
                                break;
                            case 4:
                                student1.Age = br.ReadInt32();
                                break;
                            case 5:
                                student1.Semester = br.ReadDouble();
                                break;
                            case 6:
                                student1.Scholarship = br.ReadDouble();
                                break;
                            case 7:
                                student1.HasHostel = br.ReadBoolean();
                                break;
                            case 8:
                                student1.HasScholarship = br.ReadBoolean();
                                break;
                        }
                    }
                    Students.Add(student1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally
            {
                br.Close();
            }
            Console.WriteLine($"Несортований перелік Студентів: {Students.Count}");
            PrintStudents();
            Students.Sort();
            Console.WriteLine($"Сортований перелік Студентів: {Students.Count}");
            PrintStudents();
            Student student = new Student("Дмитро", "Трухін", "ФІІТА", 18, 2, 0, true, false);
            Students.Add(student);
            Students.Sort();
            Console.WriteLine($"Перелік Студентів: {Students.Count}");
            PrintStudents();
            Console.WriteLine("Видаляємо останнє значення");
            Students.RemoveAt(Students.Count - 1);
            Console.WriteLine($"Перелік Студентів: {Students.Count}");
            PrintStudents();
            Console.ReadKey();
        }
    }
}
