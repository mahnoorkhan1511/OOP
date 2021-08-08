import os

#decalring a class to store the record of the student 
class student:
    name = ""
    rollNo = ""
    gpa = 0.0
    isHostelite = ""
    department = ""

#the main interface    
def main_interface():
    print("1.Add student")
    print("2.Show record")
    print("3.List top three students")
    print("4.Exit")
    inp = int(input("Enter your respective option : "))
    return inp

#taking input of the students
def takeInput():

    s = student()
    s.name = input("Enter the students name : ")
    s.rollNo = input("Enter roll no. : ")
    s.department = input("Enter the department : ")
    s.gpa = float(input("Enter gpa : "))
    s.isHostelite = input("Is he/she hostelite? : ")
    return s

#adding students to the list
def addStudent():
    
    std = []
    keepAdding = "yes"
    while keepAdding != "no":
        s = takeInput()
        std.append(s)
        keepAdding = input("Do you want to keep on adding : ")
    return std

def showRecord(std):

    print("Name","\t","Roll No.","\t","Department","\t","GPA","\t","Hostelite")
    for i in range(0,len(std)):
        y = std[i]
        print(y.name,"\t",y.rollNo,"\t",y.department,"\t",y.gpa,"\t",y.isHostelite)
    
#student with the highest merit
def topMerit(std):
    index = 0
    print("The student with highest merit is :")
    print("Name","\t","Roll No.","\t","Department","\t","GPA","\t","Hostelite")
    largest = 0
    for i in range(0,len(std)):
        y = std[i]
        #finding the highest gpa and storing its respective index
        if y.gpa > largest:
            largest = y.gpa
            index = i
    y = std[index]
    print(y.name,"\t",y.rollNo,"\t",y.department,"\t",y.gpa,"\t",y.isHostelite)

#press key function
def pressKey():
    key = input("Enter any key to continue : ")

def driver():
    
    std = []
    opt = 0 
    while opt !=4:
        os.system('cls')
        opt = main_interface()
        if opt == 1:
            std = addStudent()
        elif opt == 2:
            showRecord(std)
            pressKey()
        elif opt == 3:
            topMerit(std)
            pressKey()
driver()