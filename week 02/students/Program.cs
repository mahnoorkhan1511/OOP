using System;

namespace students
{
    class student{
        public string name = "";
        public string rollno = "";
        public float gpa = 0;
        public string isHostelite = "";
        public string department = "";
    }
    class Program
    {
        static void Main(string[] args)
        {
            student s1 = new student();
            student s2 = new student();
            student s3 = new student();
            Program p = new Program();
            int opt = 0;
            while ( opt != 4){
                opt = p.mainMenu();
                if ( opt == 1){
                    if( opt == 1){
                        int count = 0;
                        if(count == 0){
                            s1 = p.addStudent();
                            count++;
                        }
                        if(count == 1){
                            s2 = p.addStudent();
                            count++;
                        }
                        if(count == 2){
                            s3 = p.addStudent();
                            count ++;
                        }
                        if ( count > 2){
                            count = 0;
                        }
                        count ++;
                    }
                }
                else if( opt == 2){
                    p.viewStudents(s1,s2,s3);
                    Console.WriteLine("Enter any key..");
                    Console.ReadKey();
                }
                else if( opt == 3){
                    p.topStudent(s1,s2,s3);
                    Console.WriteLine("Enter any key..");
                    Console.ReadKey();
                }
            }
        }
        int mainMenu(){
            Console.Clear();
            Console.WriteLine("Enter your option :");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Show all students");
            Console.WriteLine("3. Student with highest merit");
            Console.WriteLine("4. Exit");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        student addStudent(){
            Console.WriteLine("Add student!");
            student s = new student();
            Console.Clear();
            Console.WriteLine("Enter name of the student ..");
            s.name = Console.ReadLine();
            Console.WriteLine("Enter the roll no. of student..");
            s.rollno = Console.ReadLine();
            Console.WriteLine("Enter the GPA of the student..");
            s.gpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the department of the student ..");
            s.department = Console.ReadLine();
            Console.WriteLine("Is the student hostelite, enter yes or no..");
            s.isHostelite = Console.ReadLine();
            return s;
        }
        void viewStudents(student s1,student s2, student s3){
            Console.Clear();
            Console.WriteLine("All students ..");
            Console.Write("\n");
            Console.WriteLine("Name" + "\t" + "Roll no." + "\t" + "GPA" + "\t" + "Department" + "\t" + "is Hostelite");
            Console.WriteLine(s1.name + "\t" + s1.rollno + "\t" + s1.gpa + "\t" + s1.department + "\t" + s1.isHostelite);
            Console.WriteLine(s2.name + "\t" + s2.rollno + "\t" + s2.gpa + "\t" + s2.department + "\t" + s2.isHostelite);
            Console.WriteLine(s3.name + "\t" + s3.rollno + "\t" + s3.gpa + "\t" + s3.department + "\t" + s3.isHostelite);
        }
        void topStudent( student s1, student s2, student s3){
            Console.Clear();
            Console.WriteLine("The student on the top is following : ");
            Console.WriteLine("Name" + "\t" + "Roll no." + "\t" + "GPA" + "\t" + "Department" + "\t" + "is Hostelite");
            if( s1.gpa > s2.gpa && s1.gpa > s3.gpa){
                Console.WriteLine(s1.name + "\t" + s1.rollno + "\t" + s1.gpa + "\t" + s1.department + "\t" + s1.isHostelite);
            }
            else if( s2.gpa > s1.gpa && s2.gpa> s3.gpa){
                Console.WriteLine(s2.name + "\t" + s2.rollno + "\t" + s2.gpa + "\t" + s2.department + "\t" + s2.isHostelite);
            }
            else if( s3.gpa > s1.gpa && s3.gpa > s2.gpa){
                Console.WriteLine(s3.name + "\t" + s3.rollno + "\t" + s3.gpa + "\t" + s3.department + "\t" + s3.isHostelite);
            }
        }
    }
}
