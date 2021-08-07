using System;
using System.Collections.Generic;
namespace prodProject
{
    //class for products
    class product{
        public string name = "";
        public string category = "";
        public int price = 0;
        public int qty = 0;
        public int minQty = 0;
        public float tax = 0;
        public product(string name, string category, int price, int qty, int minQty, float tax){
            this.name = name;
            this.category = category;
            this.price = price;
            this.qty = qty;
            this.minQty = minQty;
            this.tax = tax;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<product> prod = new List<product>();
            int opt = 0;
            Program p = new Program();
            while (opt != 7){
                p.showHeader(); 
                opt = p.showMenu();
                if (opt == 1){
                    prod.Add(p.addProduct());
                }
                else if (opt == 2){
                    p.viewProd(prod);
                    p.pressKey();
                }
                else if( opt == 3){
                    p.highest_price(prod);
                    p.pressKey();
                }
                else if(opt == 4){
                    prod = p.sellProd(prod);
                    p.pressKey();
                }
                else if (opt == 5){
                    p.orderProd(prod);
                    p.pressKey();
                }
                else if (opt == 6){
                    p.viewTax(prod);
                    p.pressKey(); 
                }
           
            }   
        
        }
        void showHeader(){
            Console.Clear();
            Console.WriteLine("*****************************************************");
            Console.WriteLine("               STORE MANAGEMENT SYSTEM               ");
            Console.WriteLine("*****************************************************");
            Console.Write("\n");
        }
        int showMenu(){
            Console.WriteLine("Enter your option : ");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Find product with highest unit price ");
            Console.WriteLine("4. Sell Product");
            Console.WriteLine("5. Products to be ordered (less than threshold) ");
            Console.WriteLine("6. View sales tax of all products");
            Console.WriteLine("7. Exit");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        product addProduct(){
            Console.Clear();
            Console.WriteLine("        Add New Products");
            Console.WriteLine("________________________________");
            Console.WriteLine("\n");
            Console.WriteLine("Enter the name of the product : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the category of the product : ");
            string category = Console.ReadLine();
            Console.WriteLine("Enter the price of the product : ");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the quantity of the product : ");
            int qty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the threshold quantity of the product : ");
            int minQty = int.Parse(Console.ReadLine());
            product p = new product(name, category, price, qty, minQty, 0);
            return p;
        }
        void viewProd(List<product> prod){
            Console.Clear();
            Console.WriteLine("  View Product ");
            Console.WriteLine("_________________");
            Console.WriteLine("\n");
            Console.WriteLine("Name"+"\t"+"Category"+"\t"+"Price"+"\t"+"Stock"+"\t"+"Threshold value");
            for(int i = 0; i<prod.Count ; i++){
                Console.WriteLine(prod[i].name+"\t"+prod[i].category+"\t"+prod[i].price+"\t"+prod[i].qty+"\t"+prod[i].minQty);
            }
        
        }
        void highest_price(List<product> prod){
            Console.Clear();
            Console.WriteLine("  Product with highest price ");
            Console.WriteLine("______________________________");
            Console.Write("\n");
            int largst = prod[0].price;
            product tempProduct = prod[0];
            for(int i = 0; i<prod.Count ; i++){
                if( prod[i].price > largst){
                    largst = prod[i].price;
                    tempProduct = prod[i];
                }
            }
            Console.WriteLine("Name"+"\t"+"Category"+"\t"+"Price"+"\t"+"Stock"+"\t"+"Threshold value");
            Console.WriteLine(tempProduct.name+"\t"+tempProduct.category+"\t"+tempProduct.price+"\t"+tempProduct.qty+"\t"+tempProduct.minQty);
        }
    
        List<product> sellProd(List<product> prod){
            Console.Clear();
            int index = 0;
            int isPresent = 0;
            Console.WriteLine("  Selling a Product ");
            Console.WriteLine("_____________________");
            Console.Write("\n");
            Console.WriteLine("Enter the name of the product : ");            
            string name = Console.ReadLine();
            for(int i = 0; i<prod.Count; i++){
                product p = prod[i];
                if( p.name == name ){
                    index = i;
                    isPresent = 1;
                }
            }
            product y = prod[index];
            if (isPresent == 1)
            {
                Console.WriteLine("Enter quantity of the product to be purchased : ");
                int quantity = int.Parse(Console.ReadLine());
                if(quantity <= y.qty){
                    float tax = 0;
                    y.qty = y.qty - quantity;
                    prod[index].qty = y.qty;
                    int total_Price = quantity*y.price;
                    if( y.category == "grocery"){
                        tax = Convert.ToSingle(total_Price * 0.1); 
                    }
                    else if(y.category == "fruit") {
                        tax = Convert.ToSingle(total_Price*0.05);
                    }
                    else{
                        tax = Convert.ToSingle(total_Price*0.15);
                    }
                    y.tax = y.tax + tax;
                    prod[index].tax = y.tax;
                    Console.WriteLine("Purchase successful ! ");
                }        
                else{
                    Console.WriteLine("The entered quantity is greater than the available stock, purchase failed..");
                }
            }
            else{
                Console.WriteLine("The entered product doesn't exit");
            }
            return prod;
        }
        void orderProd(List<product> prod){
            Console.Clear(); 
            Console.WriteLine("  Products to be ordered");
            Console.WriteLine("_____________________________");
            int to_buy = 0;
            Console.WriteLine("Product"+"\t"+"Category"+"\t"+"Stock"+"\t"+"Threshold"+"\t"+"Time to order");
            for(int i = 0; i< prod.Count ; i++){
                product y = prod[i];
                if (y.qty<y.minQty){
                    to_buy = 1;
                }
                Console.WriteLine(y.name + "\t" + y.category + "\t" + y.qty + "\t" + y.minQty + "\t" + to_buy);
            }
                
        }
        void viewTax(List<product> prod){
            Console.Clear();
            Console.WriteLine("      Sales Tax");
            Console.WriteLine("____________________________");
            Console.WriteLine("Product"+"\t"+"Category"+"\t"+"Price"+"\t"+"Sales tax");
            for (int i = 0; i<prod.Count; i++){
                product y = prod[i];
                Console.WriteLine(y.name+"\t"+y.category+"\t"+y.price+"\t"+y.tax);
            }
               
        }
        void pressKey(){
            Console.WriteLine("Enter any key..");
            Console.ReadKey();
        }
        
    }
}
