import os

class product:
    ID = 0
    name = ""
    price = 0
    cat = ""
    brand = ""
    country = ""

p1 = product()
p2 = product()
p3 = product()
p4 = product()
p5 = product()

def main_interface():
    print("1.Add product ")
    print("2.View product")
    print("3.Total store worth")
    print("4.Exit")
    opt = int(input("enter your option : "))
    return opt

def addProd():
    global p1
    global p2
    global p3 
    global p4
    global p5
    inputCount = 0
    while inputCount<4:
        p1.ID = int(input("Enter the id of the product : "))
        p1.name = input("Enter the name of the product : ")
        p1.brand = input("Enter the brand name : ")
        p1.cat = input("Enter the category : ")
        p1.price = int(input("Enter the price of the product : "))
        p1.country = input("Enter the country : ")
        inputCount = inputCount + 1
        p2.ID = int(input("Enter the id of the product : "))
        p2.name = input("Enter the name of the product : ")
        p2.brand = input("Enter the brand name : ")
        p2.cat = input("Enter the category : ")
        p2.price = int(input("Enter the price of the product : "))
        p2.country = input("Enter the country : ")
        inputCount = inputCount + 1
        p3.ID = int(input("Enter the id of the product : "))
        p3.name = input("Enter the name of the product : ")
        p3.brand = input("Enter the brand name : ")
        p3.cat = input("Enter the category : ")
        p3.price = int(input("Enter the price of the product : "))
        p3.country = input("Enter the country : ")
        inputCount = inputCount + 1
        p4.ID = int(input("Enter the id of the product : "))
        p4.name = input("Enter the name of the product : ")
        p4.brand = input("Enter the brand name : ")
        p4.cat = input("Enter the category : ")
        p4.price = int(input("Enter the price of the product : "))
        p4.country = input("Enter the country : ")
        inputCount = inputCount + 1
        p5.ID = int(input("Enter the id of the product : "))
        p5.name = input("Enter the name of the product : ")
        p5.brand = input("Enter the brand name : ")
        p5.cat = input("Enter the category : ")
        p5.price = int(input("Enter the price of the product : "))
        p5.country = input("Enter the country : ")
        
def showRecord():
    print("ID","\t","Name","Brand","\t","Category","\t","Price","\t","Country")
    print(p1.ID,"\t",p1.name,"\t",p1.brand,"\t",p1.cat,"\t",p1.price,"\t",p1.country)
    print(p2.ID,"\t",p2.name,"\t",p2.brand,"\t",p2.cat,"\t",p2.price,"\t",p2.country)
    print(p3.ID,"\t",p3.name,"\t",p3.brand,"\t",p3.cat,"\t",p3.price,"\t",p3.country)
    print(p4.ID,"\t",p4.name,"\t",p4.brand,"\t",p4.cat,"\t",p4.price,"\t",p4.country)
    print(p5.ID,"\t",p5.name,"\t",p5.brand,"\t",p5.cat,"\t",p5.price,"\t",p5.country)

def worth():
    print("total worth of the store : ",p1.price+p2.price+p3.price+p4.price+p5.price)

def driver():
    opt = 0
    while opt != 4:
        os.system('cls')
        opt = main_interface()
        if opt==1:
            addProd()
        elif opt == 2:
            showRecord()
        elif opt == 3:
            worth()

driver()