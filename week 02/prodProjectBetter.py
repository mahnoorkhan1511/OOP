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
    tax = 0
    def __init__(self,pname,pcat,pprice,pqty,pminQty):
        self.name = pname
        self.cat = pcat
        self.price = pprice
        self.qty = pqty
        self.minQty = pminQty
        print("object created")
    
    #functions to calculate tax
    def tax_calculator(self,total_Price):
        tax = 0
        if self.cat == "fruit":
            tax = self.price*0.05
        elif self.cat == "grocery":
            tax = self.price*0.1
        else:
            tax = self.price*0.15
        return tax


#function to take input in the class
def takeInput():
    os.system('cls')
    print("        Add New Products")
    print("________________________________")
    print("\n")
    pname = input("Enter the name of the product : ")
    pcat = input("Enter the category of the product : ")
    pprice = int(input("Enter the price of the product : "))
    pqty = int(input("Enter the quantity of the product : "))
    pminQty = int(input("Enter the threshold quantity of the product : "))
    p = product(pname,pcat,pprice,pqty,pminQty)
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
    temp_prod = prod[0]
    for obj in prod:
        if obj.name == name :
            isPresent = 1
            temp_prod = obj
    
    if isPresent == 1:
        quantity = int(input("Enter quantity of the product to be purchased : "))
        if quantity < temp_prod.qty:
            tax = 0
            temp_prod.qty = temp_prod.qty - quantity
            total_Price = quantity*temp_prod.price
            #calculating the tax
            tax = temp_prod.tax_calculator(total_Price)
            temp_prod.tax = tax
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
    temp_prod = prod[0]
    for obj in prod:
        if temp_prod.qty<temp_prod.minQty:
            to_buy = 1
        print(temp_prod.name,"\t",temp_prod.cat,"\t",temp_prod.qty,"\t",temp_prod.minQty,"\t",to_buy)

#displaying the sales tax "option 6"
def viewTax(prod):
    os.system('cls')
    print("      Sales Tax")
    print("____________________________")
    print("Product","\t","Category","\t","Price","\t","Sales tax")
    for obj in prod:
    
        print(obj.name,"\t",obj.cat,"\t",obj.price,"\t",obj.tax)

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
