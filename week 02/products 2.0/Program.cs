using System;
using System.Collections.Generic;

namespace products
{
    class product{
        public string name = "";
        public int prodID = 0;
        public int price = 0;
        public string category = "";
        public string brandName = "";
        public string country = "";
        public product(string name, int prodID, int price, string category, string brandName, string country){
            this.name = name;
            this.prodID = prodID;
            this.price = price;
            this.category = category;
            this.brandName = brandName;
            this.country = country;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<product> ptds = new List<product>();
            Program p = new Program();
            int opt = 0;
            while( opt != 4){
                opt = p.mainMenu();
                if( opt == 1){
                    
                    
                }
                else if( opt == 2){
                    p.viewProd(ptds);
                    Console.WriteLine("Enter any key..");
                    Console.ReadKey();
                }
                else if( opt == 3){
                    p.storeWorth(ptds);
                    Console.WriteLine("Enter any key..");
                    Console.ReadKey();
                }
            }
        }
        int mainMenu(){
            Console.Clear();
            Console.WriteLine(" Enter your option ..");
            Console.WriteLine("1. Add products ");
            Console.WriteLine("2. View all products ");
            Console.WriteLine("3. Store worth");
            Console.WriteLine("4. Exit");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        product addProd(){
            Console.WriteLine("Enter product ");
            
            Console.WriteLine("Enter the name of the product ..");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the product ID ..");
            int prodID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price.. ");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the category of the product.. ");
            string category = Console.ReadLine();
            Console.WriteLine("Enter the brand name ..");
            string brandName = Console.ReadLine();
            Console.WriteLine("Enter the country..");
            string country = Console.ReadLine();
            product p = new product(name,prodID,price,category,brandName,country);
            return p;
        }
        void viewProd(List<product> ptds){
            Console.Clear();
            Console.WriteLine("View Products ");
            Console.WriteLine("ID" + "\t" + "Name" + "\t" + "Category" + "\t" + "Price" + "\t" + "Brand name" + "\t" + "Country of origin");
            for(int i = 0; i < ptds.Count ; i++){
                Console.WriteLine(ptds[i].prodID + "\t" + ptds[i].name + "\t" + ptds[i].price + "\t" + ptds[i].brandName + "\t" + ptds[i].country);
            }
        }
        void storeWorth(List<product> ptds){
            Console.Clear();
            Console.WriteLine("The worth of the store is ..");
            int total = 0;
            for(int i = 0; i<ptds.Count ; i++){
                total = total + ptds[i].price;
            }
            Console.WriteLine("Rs." + " " + total);
        }
    }
}

