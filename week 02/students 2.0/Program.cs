using System;
using System.Collections.Generic;
namespace students_2._0
{
    class student{
        public string name = "";
        public string rollno = "";
        public float gpa = 0;
        public string isHostelite = "";
        public string department = "";
        public student(string name, string rollno, float gpa, string department, string isHostelite){
            this.name = name;
            this.rollno = rollno;
            this.gpa = gpa;
            this.isHostelite = isHostelite;
            this.department = department;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<student> stds = new List<student>();
            Program p = new Program();
            int opt = 0;
            while ( opt != 4){
                opt = p.mainMenu();
                
                if ( opt == 1){
                    if( opt == 1){
                        stds.Add(p.addStudent());
                        
                    }
                }
                else if( opt == 2){
                    p.viewStudents(stds);
                    Console.WriteLine("Enter any key..");
                    Console.ReadKey();
                }
                else if( opt == 3){
                    p.topStudent(stds);
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
            Console.Clear();
            Console.WriteLine("Add student!");
            Console.WriteLine("Enter name of the student ..");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the roll no. of student..");
            string rollno = Console.ReadLine();
            Console.WriteLine("Enter the GPA of the student..");
            float gpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the department of the student ..");
            string department = Console.ReadLine();
            Console.WriteLine("Is the student hostelite, enter yes or no..");
            string isHostelite = Console.ReadLine();
            student s = new student(name,rollno,gpa,department,isHostelite);
            return s;
        }
        void viewStudents(List<student> stds){
            Console.Clear();
            Console.WriteLine("All students ..");
            Console.Write("\n");
            Console.WriteLine("Name" + "\t" + "Roll no." + "\t" + "GPA" + "\t" + "Department" + "\t" + "is Hostelite");
            for (int idx = 0; idx<stds.Count ; idx++){
                Console.WriteLine(stds[idx].name + "\t" + stds[idx].rollno + "\t" + stds[idx].gpa + "\t" + stds[idx].department + "\t" + stds[idx].isHostelite);    
            }
        }
        void topStudent(List<student> stds){
            Console.Clear();
            Console.WriteLine("The student on the top is following : ");
            Console.WriteLine("Name" + "\t" + "Roll no." + "\t" + "GPA" + "\t" + "Department" + "\t" + "is Hostelite");
            int idx = 0;
            float largest = 0;
            for ( int i = 0; i< stds.Count ; i++){
                if(stds[i].gpa > largest){
                    largest = stds[i].gpa;
                    idx = i;
                }
            }
            Console.WriteLine(stds[idx].name + "\t" + stds[idx].rollno + "\t" + stds[idx].gpa + "\t" + stds[idx].department + "\t" + stds[idx].isHostelite);
        }
    }
}
