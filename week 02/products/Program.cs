using System;

namespace products
{
    class product{
        public string name = "";
        public int prodID = 0;
        public int price = 0;
        public string category = "";
        public string brandName = "";
        public string country = "";
    }
    class Program
    {
        static void Main(string[] args)
        {
            product p1 = new product();
            product p2 = new product();
            product p3 = new product();
            product p4 = new product();
            product p5 = new product();
            Program p = new Program();
            int opt = 0;
            while( opt != 4){
                opt = p.mainMenu();
                if( opt == 1){
                    int count = 0;
                    if(count == 0){
                        p1 = p.addProd();
                        count++;
                    }
                    if(count == 1){
                        p2 = p.addProd();
                        count ++;
                    }
                    if(count == 2){
                        p3 = p.addProd();
                        count ++;
                    }
                    if(count == 3){
                        p4 = p.addProd();
                        count ++;
                    }
                    if( count == 4){
                        p5 = p.addProd();
                        count ++;
                    }
                    if ( count > 4){
                        count = 0;
                        
                    }
                    count ++;
                }
                else if( opt == 2){
                    p.viewProd(p1,p2,p3,p4,p5);
                    Console.WriteLine("Enter any key..");
                    Console.ReadKey();
                }
                else if( opt == 3){
                    p.storeWorth(p1,p2,p3,p4,p5);
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
            product p = new product();
            Console.WriteLine("Enter the name of the product ..");
            p.name = Console.ReadLine();
            Console.WriteLine("Enter the product ID ..");
            p.prodID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price.. ");
            p.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the category of the product.. ");
            p.category = Console.ReadLine();
            Console.WriteLine("Enter the brand name ..");
            p.brandName = Console.ReadLine();
            Console.WriteLine("Enter the country..");
            p.country = Console.ReadLine();
            return p;
        }
        void viewProd(product p1, product p2, product p3, product p4, product p5){
            Console.Clear();
            Console.WriteLine("View Products ");
            Console.WriteLine("ID" + "\t" + "Name" + "\t" + "Category" + "\t" + "Price" + "\t" + "Brand name" + "\t" + "Country of origin");
            Console.WriteLine(p1.prodID + "\t" + p1.name + "\t" + p1.category + "\t" + p1.price + "\t" + p1.brandName + "\t" + p1.country);
            Console.WriteLine(p2.prodID + "\t" + p2.name + "\t" + p2.category + "\t" + p2.price + "\t" + p2.brandName + "\t" + p2.country);
            Console.WriteLine(p3.prodID + "\t" + p3.name + "\t" + p3.category + "\t" + p3.price + "\t" + p3.brandName + "\t" + p3.country);
            Console.WriteLine(p4.prodID + "\t" + p4.name + "\t" + p4.category + "\t" + p4.price + "\t" + p4.brandName + "\t" + p4.country);
            Console.WriteLine(p5.prodID + "\t" + p5.name + "\t" + p5.category + "\t" + p5.price + "\t" + p5.brandName + "\t" + p5.country);
        }
        void storeWorth(product p1, product p2, product p3, product p4, product p5){
            Console.Clear();
            Console.WriteLine("The worth of the store is ..");
            Console.WriteLine("Rs." + " " + (p1.price + p2.price + p3.price + p4.price + p5.price));
        }
    }
}

