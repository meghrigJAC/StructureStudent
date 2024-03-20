using System.Diagnostics;

namespace StructureStudent
{
    struct Student
    {
        public string Name;
        public short ID;
        public DateTime DateOfBirth;

        public Student (string studentName, short studentId, DateTime dob )
        {
            Name = studentName;
            ID = studentId;
            DateOfBirth = dob;
        }
        public string DisplayStudent()
        {
            return $"Name: {Name}, ID: {ID}, Date of Birth: {DateOfBirth.ToShortDateString()}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int numberOfStudents = GetNumber("Please enter number of Students ");
            Student student1;

            for (int i = 0; i < numberOfStudents; i++)
            {
                student1 = GetStudentInfo(i +1);
                students.Add(student1);
            }

            PrintStudentList(students);

            Student youngest = GetYoungestStudent(students);
            Student oldest = GetOldestStudent(students);

            Console.WriteLine($"The youngest Student is {youngest.DisplayStudent()}");
            Console.WriteLine($"The oldest Student is {oldest.DisplayStudent()}"); ;
        }

        public static void PrintStudentList(List<Student> students)
        {
            Console.WriteLine("Students List");

            foreach (Student student in students)
            {
                student.DisplayStudent();
            }
        }

       public static Student GetYoungestStudent(List<Student> students)
        {
            Student youngestStudent = students[0];

            for (int i=1;i< students.Count;i++)
            {
                if (students[i].DateOfBirth > youngestStudent.DateOfBirth)
                {
                    youngestStudent = students[i];
                }
            }

            return youngestStudent;
        }

        public static Student GetOldestStudent(List<Student> students)
        {
            Student oldestStudent = students[0];

            for (int i = 1; i < students.Count; i++)
            {
                if (students[i].DateOfBirth < oldestStudent.DateOfBirth)
                {
                    oldestStudent = students[i];
                }
            }

            return oldestStudent;
        }


        public static Student GetStudentInfo(int number)
        {
            
            Console.Write($"Please enter the name of student {number} ");
            String name = Console.ReadLine();
            short id = GetShortNumber($"Please enter the id of student {number} ");
            DateTime dob = GetDateOfBirth(number);

            Student student = new Student(name, id, dob);

            return student;
        }
        public static DateTime GetDateOfBirth(int number)
        {
            DateTime dob;

            Console.Write($"Please enter the Date of Birth of student {number} in (yyyy-mm-dd) format: ");
            bool valid = DateTime.TryParse(Console.ReadLine(), out dob);

            while (!valid )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Error invalid date: Please enter the Date of Birth of student {number} in (yyyy-mm-dd) format:");
                Console.ForegroundColor = ConsoleColor.White;
                valid = DateTime.TryParse(Console.ReadLine(), out dob);

            }

            return dob;
        }
        public static int GetNumber(string msg, int min = 0)
        {
            int number;

            Console.Write(msg);
            bool valid = int.TryParse(Console.ReadLine(), out number);

            while (!valid || number < min)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Error invalid number: {msg}");
                Console.ForegroundColor = ConsoleColor.White;
                valid = int.TryParse(Console.ReadLine(), out number);

            }

            return number;
        }
        public static short GetShortNumber(string msg, short min = 0)
        {
            short number;

            Console.Write(msg);
            bool valid = short.TryParse(Console.ReadLine(), out number);

            while (!valid || number < min)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Error invalid number: {msg}");
                Console.ForegroundColor = ConsoleColor.White;
                valid = short.TryParse(Console.ReadLine(), out number);

            }

            return number;
        }

    }
}