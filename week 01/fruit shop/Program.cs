using System;
using System.IO;
namespace fruit_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt = 0;
            while (opt != 3){
                opt = menu();
                

                //user
                if(opt == 1){
                    Console.Clear();
                    Console.WriteLine("Enter the fruit : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Quantity : ");
                    int kg = int.Parse(Console.ReadLine());
                    string statement = checkFruit(name,kg);
                    Console.WriteLine(statement);
                    Console.WriteLine("Press any key...");
	                Console.ReadKey();
                }


                //admin
                else if( opt == 2){
                    Console.Clear();
                    Console.WriteLine("Enter the fruit you want to add : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter its price per kg : ");
                    int price = int.Parse(Console.ReadLine());
                    string statement = addFruit(name,price);
                    Console.WriteLine(statement);
                    Console.WriteLine("Press any key...");
	                Console.ReadKey();
                }
            }
        }
        static int menu(){
            Console.Clear();
            Console.WriteLine(" Enter your option ");
            Console.WriteLine("1. User");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Exit");
            int opt;
            opt = int.Parse(Console.ReadLine());
            return opt;
        }
        static string checkFruit(string name, int kg){
            string statement;
            bool isThere;
            isThere = inFile(name);
            if (isThere == true){
                int price;
                price = totalPrice(name, kg);
                statement = "The total price payable is " + price.ToString();
            }
            else{
                statement = "The entered fruit is not available";
            }

            return statement;
        }
        static bool inFile(string name){
            //find the fruit if yes return true
            string[] dataInFile;
            dataInFile = File.ReadAllLines("E://oop SUMMER/week 01/fruit shop/fruits.txt");
            foreach(string str in dataInFile){
                string fruit = "";
                char c = ' ';
                int commaCount = 0;
                for (int i = 0; i<str.Length ; i++){
                    c = str[i];
                    if(commaCount == 0 && c != ','){
                        fruit = fruit + c;
                    }
                    if(c == ','){
                        commaCount ++;
                    }
                }
                if(fruit == name){
                    return true;
                }
            }
            return false;
        }
        static int totalPrice(string name, int kg){
            int price = 0;
            //read from file
            string[] dataInFile;
            dataInFile = File.ReadAllLines("E://oop SUMMER/week 01/fruit shop/fruits.txt");
            foreach(string str in dataInFile){
                string fruit = "";
                string value = "";
                char c;
                int commaCount = 0;
                for (int i = 0; i<str.Length ; i++){
                    c = str[i];
                    if(commaCount == 0 && c != ','){
                        fruit = fruit + c;
                    }
                    else if( c == ','){
                        commaCount ++;
                    }
                    else if( commaCount == 1 && c != ','){
                        value = value + c;
                    }
                    
                }
                if(name == fruit){
                    price = kg * int.Parse(value);
                }
                
            }
            // find the name of the fruit and then its respective price
            // multiply it with the number of kgs entered
            return price;
        }
        static string addFruit(string name, int price){
            bool isThere;
            isThere = inFile(name);
            if(isThere == false){
                string[] data = {name + "," + price.ToString()};
                File.AppendAllLines("E://oop SUMMER/week 01/fruit shop/fruits.txt" , data);
                return "the entered fruit is added";
            }
            else{
                return "the entered fruit already exists ";
            }    
        }
    }
}
