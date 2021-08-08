import os
class student:
    name = ""
    rollNo = ""
    gpa = 0.0
    isHostelite = ""
    department = ""
s1 = student()
s2 = student()
s3 = student()
def main_interface():
    print("1.Add student")
    print("2.Show record")
    print("3.List top three students")
    print("4.Exit")
    inp = int(input("Enter your respective option : "))
    return inp

def addStudent():
    global s1
    global s2
    global s3
    inputCount = 0
    while inputCount <2:
        s1.name = input("Enter the students name : ")
        s1.rollNo = input("Enter roll no. : ")
        s1.department = input("Enter the department : ")
        s1.gpa = float(input("Enter gpa : "))
        s1.isHostelite = input("Is he/she hostelite? : ")
        inputCount = inputCount + 1
        s2.name = input("Enter the students name : ")
        s2.rollNo = input("Enter roll no. : ")
        s2.department = input("Enter the department : ")
        s2.gpa = float(input("Enter gpa : "))
        s2.isHostelite = input("Is he/she hostelite? : ")
        inputCount = inputCount + 1
        s3.name = input("Enter the students name : ")
        s3.rollNo = input("Enter roll no. : ")
        s3.department = input("Enter the department : ")
        s3.gpa = float(input("Enter gpa : "))
        s3.isHostelite = input("Is he/she hostelite? : ")

def showRecord():
    global s1
    global s2
    global s3
    print("Name","\t","Roll No.","\t","Department","\t","GPA","\t","Hostelite")
    print(s1.name,"\t",s1.rollNo,"\t",s1.department,"\t",s1.gpa,"\t",s1.isHostelite)
    print(s2.name,"\t",s2.rollNo,"\t",s2.department,"\t",s2.gpa,"\t",s2.isHostelite)
    print(s3.name,"\t",s3.rollNo,"\t",s3.department,"\t",s3.gpa,"\t",s3.isHostelite)

def topMerit():
    print("The student with highest merit is :")
    print("Name","\t","Roll No.","\t","Department","\t","GPA","\t","Hostelite")
    if s1.merit>s2.merit and s1.merit>s3.merit:
        print(s1.name,"\t",s1.rollNo,"\t",s1.department,"\t",s1.gpa,"\t",s1.isHostelite)
    elif s2.merit>s1.merit and s2.merit>s3.merit:
        print(s1.name,"\t",s1.rollNo,"\t",s1.department,"\t",s1.gpa,"\t",s1.isHostelite)
    elif s3.merit>s1.merit and s3.merit>s2.merit:
        print(s3.name,"\t",s3.rollNo,"\t",s3.department,"\t",s3.gpa,"\t",s3.isHostelite)
    
def driver():
    
    opt = 0 
    while opt !=4:
        os.system('cls')
        opt = main_interface()
        if opt == 1:
            addStudent()
        elif opt == 2:
            showRecord()
        elif opt == 3:
            topMerit()

driver()