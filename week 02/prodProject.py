import os

#main interface 
def main():
    opt = 0
    print("*****************************************************")
    print("               STORE MANAGEMENT SYSTEM               ")
    print("*****************************************************")
    print("\n")
    print("1.Add product.")
    print("2.View all products.")
    print("3.Find prodect with highest unit price.")
    print("4.Sell products.")
    print("5.Products to be ordered (less than threshold).")
    print("6.View Sales tax of all products.")
    print("7.Exit")
    opt = int(input("Enter your respective option : "))
    return opt

#declaring class for holding the information for a product
class product:
    
    name = ""
    cat = "" #category of the product
    price = 0
    qty = 0 #quantity
    minQty = 0 #minimum quantity
    tax = 0 #salesTax

#function to take input in the class
def takeInput():
    os.system('cls')
    p = product()
    print("        Add New Products")
    print("________________________________")
    print("\n")
    p.name = input("Enter the name of the product : ")
    p.cat = input("Enter the category of the product : ")
    p.price = int(input("Enter the price of the product : "))
    p.qty = int(input("Enter the quantity of the product : "))
    p.minQty = int(input("Enter the threshold quantity of the product : "))
    return p

#entering the values in the list "option 1"
def addProd():

    keepAdding = "yes"
    prod = []
    while keepAdding != "no":
        p = takeInput()
        prod.append(p)
        keepAdding = input("Do you want to keep on adding : ")
    return prod

#viewing products "option 2"
def viewProd(prod):
    os.system('cls')
    print("  View Product ")
    print("_________________")
    print("\n")
    print("Name","\t","Category","\t","Price","\t","Stock","\t","Threshold value")
    for i in prod:
        print(i.name,"\t",i.cat,"\t",i.price,"\t",i.qty,"\t",i.minQty)

#highest unit price "option 3"
def highest_price(prod):
    os.system('cls')
    print("  Product with highest price ")
    print("______________________________")
    print("\n")
    largst = prod[0].price
    tempProduct = prod[0]
    for product in prod:
        if product.price > largst:
            largst = product.price
            tempProduct = product
   
    print("Name","\t","Category","\t","Price","\t","Stock","\t","Threshold value")
    print(tempProduct.name,"\t",tempProduct.cat,"\t",tempProduct.price,"\t",tempProduct.qty,"\t",tempProduct.minQty)

#selling products "selling products"
def sellProd(prod):
    os.system('cls')
    index = 0
    isPresent = 0
    print("  Selling a Product ")
    print("_____________________")
    print("\n")
    name = input("Enter the name of the product : ")
    for i in range(0,len(prod)):
        y = prod[i]
        if y.name == name :
            index = i
            isPresent = 1
    
    y = prod[index]
    if isPresent == 1:
        quantity = int(input("Enter quantity of the product to be purchased : "))
        if quantity < y.qty:
            tax = 0
            y.qty = y.qty - quantity
            total_Price = quantity*y.price
            if y.cat == "grocery":
                tax = total_Price*0.1 
            elif y.cat == "fruit":
                tax = total_Price*0.05
            else:
                tax = total_Price*0.15
            y.tax = y.tax + tax
            print("Purchase successful ! ")        
        else:
            print("The entered quantity is greater than the available stock, purchase failed..")
    else :
        print("The entered product doesn't exit")
#products to order "option 5"
def orderProd(prod):
    os.system('cls') 
    print("  Products to be ordered")
    print("_____________________________")
    to_buy = 0
    print("Product","\t","Category","\t","Stock","\t","Threshold","\t","Time to order")
    for i in range(0,len(prod)):
        y = prod[i]
        if y.qty<y.minQty:
            to_buy = 1
        print(y.name,"\t",y.cat,"\t",y.qty,"\t",y.minQty,"\t",to_buy)

#displaying the sales tax "option 6"
def viewTax(prod):
    os.system('cls')
    print("      Sales Tax")
    print("____________________________")
    print("Product","\t","Category","\t","Price","\t","Sales tax")
    for i in range(0,len(prod)):
        y = prod[i]
        print(y.name,"\t",y.cat,"\t",y.price,"\t",y.tax)

#press key function
def pressKey():
    key = input("Enter any key to continue : ")

#drivers code
def drivers_Code():
    option = 0
    prod = []
    while option != 7:
        os.system('cls') 
        option = main()
        if option == 1:
            prod = addProd()
        elif option == 2:
            viewProd(prod)
            pressKey()
        elif option == 3:
            highest_price(prod)
            pressKey()
        elif option == 4:
            sellProd(prod)
            pressKey()
        elif option == 5:
            orderProd(prod)
            pressKey()
        elif option == 6:
            viewTax(prod)
            pressKey()
drivers_Code()
