using System;

namespace person
{
    class Person{
        public string name = "";
        public Person(string name){
            this.name = name;
        }        
    }
    class Student:Person{
        public Student(string name ) : base(name)
        {

        }
        public string getName(){
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string study(){
            return name + ", the student studies ..";
        }
    }
    class Teacher:Person{
        public Teacher(string name ) : base(name)
        {

        }
        public string getName(){
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string explain(){
            return name + ", the teacher explains ..";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Drake");
            Teacher t = new Teacher("Namjoon");
            t.explain();
            s.study();
        }
    }
}
