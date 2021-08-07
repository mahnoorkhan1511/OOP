using System;
using System.IO;

namespace cinema_movies
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt = 0;
            while(opt != 2){
                opt = menu();
                if(opt == 1){
                    Console.Clear();
                    Console.WriteLine("Enter movie : ");
                    string movie = Console.ReadLine();
                    float discount = movieDiscount(movie);
                    if(discount == 0){
                        
                        Console.WriteLine("The entered movie is not available");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    
                    }else{

                        Console.WriteLine("The discounted price of " + movie + "is" + discount);
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }
                }
            }
        }
        static int menu(){
            int opt;
            Console.Clear();
            Console.WriteLine("Enter your respective option :");
            Console.WriteLine("1. User");
            Console.WriteLine("2. Exit");
            opt = int.Parse(Console.ReadLine());
            return opt;
        }
        
        static float movieDiscount(string name){
            float discount = 0;
            int lineCount = 0;
            string[] dataInFile;
            dataInFile = File.ReadAllLines("E://oop SUMMER/week 01/cinema movies/movies.txt");
            foreach(string str in dataInFile){
                lineCount ++;
                string movie = getStuff(0,str);
                string price = getStuff(1,str);
                if(movie == name && lineCount%2 == 0){
                    float Price = float.Parse(price);
                    discount = Convert.ToSingle(Price - (Price * 0.1)) ;
                }
                else if(movie == name && lineCount%2 != 0){
                    float Price = float.Parse(price);
                    discount = Price - (Price * (5/100)) ;
                }
            }
            return discount;
        }
        static string getStuff(int commas,string line){
            string data = "";
            char c = ' ';
            int commaCount = 0;
            for (int i = 0; i<line.Length ; i++){
                c = line[i];
                if(commaCount == commas && c != ','){
                    data = data + c;
                }
                if(c == ','){
                    commaCount ++;
                }
            }
            return data;
        }
    }
}
