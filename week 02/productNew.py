import os
#class to hold the data of the product
class product:
    ID = 0
    name = ""
    price = 0
    cat = ""
    brand = ""
    country = ""

#function containing the main interface
def main_interface():
    print("1.Add product ")
    print("2.View product")
    print("3.Total store worth")
    print("4.Exit")
    opt = int(input("enter your option : "))
    return opt

#taking input in the class
def takeInput():
    
    p = product()
    p.ID = int(input("Enter the id of the product : "))
    p.name = input("Enter the name of the product : ")
    p.brand = input("Enter the brand name : ")
    p.cat = input("Enter the category : ")
    p.price = int(input("Enter the price of the product : "))
    p.country = input("Enter the country : ")
    return p

#adding the product
def addProd():
    prod = []
    keepAdding = "yes"
    while keepAdding != "no":
        p = takeInput()
        prod.append(p)
        keepAdding = input("Do you want to keep on adding : ")
    return prod
#printing the record        
def showRecord( prod ):
    print("ID","\t","Name","\t","Brand","\t","Category","\t","Price","\t","Country")
    for i in range(0,len(prod)):
        y = prod[i]
        print(y.ID,"\t",y.name,"\t",y.brand,"\t",y.cat,"\t",y.price,"\t",y.country)

#press key function
def pressKey():
    key = input("Enter any key to continue : ")

#calculating the worth of the song
def worth(prod):
    saved = 0
    for i in range(0,len(prod)):
        y = prod[i]
        saved = saved + y.price
    print("The worth of the store is : ",saved)

#driver code running the entire code
def driver():
    prod = []
    opt = 0
    while opt != 4:
        os.system('cls')
        opt = main_interface()
        if opt==1:
            prod = addProd()
        elif opt == 2:
            showRecord(prod)
            pressKey()
        elif opt == 3:
            worth(prod)
            pressKey()

driver()