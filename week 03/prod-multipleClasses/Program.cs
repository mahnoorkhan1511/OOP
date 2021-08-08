using System;
using System.Collections.Generic;

namespace prod_multipleClasses
{
    class product{
        public string name = "";
        public string category = "";
        public float price = 0;
        public int qty = 0;
        public int minQty = 0;
        public float tax = 0;
        public static List<product> prodDetails = new List<product>();
        public static bool isPresent(string name){
            for(int i = 0; i< prodDetails.Count ; i++){
                if(name == prodDetails[i].name){
                    return true;
                }
            }
            return false;
        }
        public static bool enoughQty(string name, int qty){
            for(int i = 0; i< prodDetails.Count ; i++){
                if(name == prodDetails[i].name){
                    if((prodDetails[i].qty - qty) >= prodDetails[i].minQty){
                        return true;
                    }
                }
            }
            return false;
        }
        public void addProduct(){
            Console.Clear();
            Console.WriteLine(" Add products in your store ..");
            Console.WriteLine("Enter name of the product ..");
            product p = new product();
            p.name = Console.ReadLine();
            Console.WriteLine("Enter the category of the product.. ");
            p.category = Console.ReadLine();
            Console.WriteLine("Enter price of the product");
            p.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the quantity of the product.. ");
            p.qty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the threshold quantity ..");
            p.minQty = int.Parse(Console.ReadLine());
            bool ok = isPresent(p.name);
            if( ok == false){
                prodDetails.Add(p);
                Console.WriteLine("Product added !");
            }
            else{
                Console.WriteLine("Product already exists ");
            }
                
        }
        public void viewProd(){
            Console.WriteLine("Name" + "\t" + "Category" + "\t" + "Price" + "\t" + "Quantity" + "\t" + "Threshold Quantity" + " Sales Tax");
           for(int i = 0; i<prodDetails.Count ; i++){
               Console.WriteLine(prodDetails[i].name + "\t" + prodDetails[i].category +"\t" + prodDetails[i].price + "\t" + prodDetails[i].qty + "\t" + prodDetails[i].minQty + "\t" + prodDetails[i].tax);
           } 
        }
        public void highest_price(){
            Console.Clear();
            Console.WriteLine("  Product with highest price ");
            Console.WriteLine("______________________________");
            Console.Write("\n");
            float largst = prodDetails[0].price;
            product tempProduct = prodDetails[0];
            for(int i = 0; i<prodDetails.Count ; i++){
                if( prodDetails[i].price > largst){
                    largst = prodDetails[i].price;
                    tempProduct = prodDetails[i];
                }
            }
            Console.WriteLine("Name"+"\t"+"Category"+"\t"+"Price"+"\t"+"Stock"+"\t"+"Threshold value");
            Console.WriteLine(tempProduct.name+"\t"+tempProduct.category+"\t"+tempProduct.price+"\t"+tempProduct.qty+"\t"+tempProduct.minQty);
        }
        public void orderProd(){
            Console.Clear(); 
            Console.WriteLine("  Products to be ordered");
            Console.WriteLine("_____________________________");
            int to_buy = 0;
            Console.WriteLine("Product"+"\t"+"Category"+"\t"+"Stock"+"\t"+"Threshold"+"\t"+"Time to order");
            for(int i = 0; i< prodDetails.Count ; i++){
                product y = prodDetails[i];
                if (y.qty<y.minQty){
                    to_buy = 1;
                }
                Console.WriteLine(y.name + "\t" + y.category + "\t" + y.qty + "\t" + y.minQty + "\t" + to_buy);
            }
                
        }
        public void viewTax(){
            Console.Clear();
            Console.WriteLine("      Sales Tax");
            Console.WriteLine("____________________________");
            Console.WriteLine("Product"+"\t"+"Category"+"\t"+"Price"+"\t"+"Sales tax");
            for (int i = 0; i<prodDetails.Count; i++){
                product y = prodDetails[i];
                Console.WriteLine(y.name+"\t"+y.category+"\t"+y.price+"\t"+y.tax);
            }
               
        }
    }
    class customer{
        
        public List<product> cart = new List<product>();
        public void addtoCart(){
            Console.Clear();
            Console.WriteLine("  Add product to cart ");
            Console.WriteLine("________________________");
            Console.Write("\n");
            product p;// the instance of the object will be created only and only if the entered name is present in the store and if the entered
            // quantity doest exceed the threshold quantuty


            Console.WriteLine("Enter the name of the product ..");
            string name = Console.ReadLine();
            bool isAvailable = product.isPresent(name);
            Console.WriteLine("Enter the quantity that you require .. ");
            int qty = int.Parse(Console.ReadLine());
            bool enough = product.enoughQty(name , qty);
            if( isAvailable && enough ){
                p = new product();
                p.name = name;
                p.qty = qty;
                for(int i = 0; i< product.prodDetails.Count; i++){
                    if(name == product.prodDetails[i].name){
                        p.price = product.prodDetails[i].price ;
                        p.category = product.prodDetails[i].category;
                
                        float tax = 0;
                        //y.qty = y.qty - quantity;
                        //product.prodDetails[index].qty = y.qty;
                        
                        if( p.category == "grocery"){
                            tax = Convert.ToSingle(p.price * 0.1); 
                        }
                        else if(p.category == "fruit") {
                            tax = Convert.ToSingle(p.price*0.05);
                        }
                        else{
                            tax = Convert.ToSingle(p.price*0.15);
                        }
                        tax = tax * qty;
                        p.tax = tax;
                        p.price = (p.price*qty) + tax;
                        cart.Add(p);
                        Console.WriteLine("The product has been entered into the cart successfully!");        
                    }
               
                }    
                
            }
            else{
                Console.WriteLine("The entered product doesnt exist in the store or the quantity entered "+"\n"+"has exceeded the threshold amount, please retry !");
            }
            

        }
        //changes to need to be made here
        public void buyProd(){
            Console.Clear();
            //int index = 0;
            //int isPresent = 0;
            Console.WriteLine("  Buy a Product ");
            Console.WriteLine("_____________________");
            Console.Write("\n");
            //Console.WriteLine("Enter the name of the product : ");            
            //string name = Console.ReadLine();
            Console.WriteLine("  Your Cart :");
            Console.WriteLine("----------------");
            Console.Write("\n");
            Console.WriteLine("Name" + "\t" + "Category" + "\t" + "Quantity" + "\t" + "Price" + "\t" + "Tax" );
            // printing the reciept
            float tPrice = 0;
            for(int i = 0; i < cart.Count ; i++){
                Console.WriteLine(cart[i].name + "\t" + cart[i].category + "\t" + cart[i].qty + "\t" + cart[i].price + "\t" + cart[i].tax );
                tPrice = tPrice +cart[i].price;
            }
            Console.WriteLine("The total amount payable is : "+ tPrice);
            Console.WriteLine("If you want to purchase the items in your cart, them enter yes, otherwise enter no!");
            string consent = Console.ReadLine();
            if( consent == "yes"){
                //removing the bought quantity of products from the stock of products and adding in the sales tax
                for(int i = 0; i < cart.Count ; i++){
                    for(int x = 0; x < product.prodDetails.Count ; x++){
                        if(cart[i].name == product.prodDetails[x].name ){
                            product.prodDetails[x].qty = product.prodDetails[x].qty - cart[i].qty;
                            product.prodDetails[x].tax = product.prodDetails[x].tax + cart[i].tax;
                        }
                    }
                }
            }
            else{
                Console.WriteLine("Order Failed !");
            }
            
        }
        public void printCart(){
            Console.WriteLine("Name" + "\t" + "Category" + "\t" + "Price" + "\t" + "Quantity"  );
            for(int i = 0; i<cart.Count ; i++){
               Console.WriteLine(cart[i].name + "\t" + cart[i].category +"\t" + cart[i].price + cart[i].qty );
           }
        }
        public void viewProd(){
            Console.WriteLine("Name" + "\t" + "Category" + "\t" + "Price" );
            for(int i = 0; i<product.prodDetails.Count ; i++){
               Console.WriteLine(product.prodDetails[i].name + "\t" + product.prodDetails[i].category +"\t" + product.prodDetails[i].price );
           } 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            product prod = new product();
            int mainOpt = 0;
            while( mainOpt != 3 ){
                mainOpt = p.mainMenu();
                if(mainOpt == 1){
                    int opt = 0;
                    while( opt != 6){
                        opt = p.adminMenu();
                        if( opt == 1){
                            
                            prod.addProduct();
                            Console.WriteLine("Press any key ..");
                            Console.ReadKey();
                        }
                        else if( opt == 2){
                            prod.viewProd();
                            Console.WriteLine("Press any key ..");
                            Console.ReadKey();
                        }
                        else if( opt == 3){
                            prod.highest_price();
                            Console.WriteLine("Press any key ..");
                            Console.ReadKey();
                        }
                        else if( opt == 4 ){
                            prod.orderProd();
                            Console.WriteLine("Press any key ..");
                            Console.ReadKey();
                        }
                        else if( opt == 5){
                            prod.viewTax();
                            Console.WriteLine("Press any key ..");
                            Console.ReadKey();
                        }
                    }
                }
                else if( mainOpt == 2){
                    int opt = 0;
                    while( opt != 4 ){
                        opt = p.custMenu();
                        customer c = new customer();
                        if(opt == 1){
                            c.viewProd();
                            Console.WriteLine("Press any key ..");
                            Console.ReadKey();
                        }
                        else if( opt == 2 ){
                            c.addtoCart();
                            Console.WriteLine("Press any key ..");
                            Console.ReadKey();
                        }
                        else if( opt == 3){
                            c.buyProd();
                            Console.WriteLine("Press any key ..");
                            Console.ReadKey();
                        }
                    }
                }
            } 
        }
        int mainMenu(){
            Console.Clear();
            Console.WriteLine("Confirm your identity :");
            Console.WriteLine(" 1. Admin ");
            Console.WriteLine(" 2. Customer ");
            Console.WriteLine(" 3. Exit ");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        int adminMenu(){
            Console.Clear();
            Console.WriteLine("*****************************************************");
            Console.WriteLine("               STORE MANAGEMENT SYSTEM               ");
            Console.WriteLine("*****************************************************");
            Console.Write("\n");
            Console.WriteLine("Enter your option : ");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Find product with highest unit price ");
            Console.WriteLine("4. Products to be ordered (less than threshold) ");
            Console.WriteLine("5. View sales tax of all products");
            Console.WriteLine("6. Exit");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        int custMenu(){
            Console.Clear();
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                   Welcome Customer               ");
            Console.WriteLine("*****************************************************");
            Console.Write("\n");
            Console.WriteLine("Enter your option : ");
            Console.WriteLine("1. View all products");
            Console.WriteLine("2. Add product in cart ");
            Console.WriteLine("3. Buy products in cart ");
            Console.WriteLine("4. Exit");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
    }
}
