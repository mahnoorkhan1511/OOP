using System;

namespace electronics
{
    class Electronics{
        public string brand,color;
        //quantity
        int qty;
        public Electronics(string brand, string color, int qty){
            this.brand = brand;
            this.color = color;
            this.qty = qty;
        }
        public string properties(){
            return "the  properties are : " + "\n" + "brand " + brand +", color " + color + ", quantity " + qty;
        }
    }
    class Computer : Electronics{
        string model;
        public Computer(string brand, string color, int qty,string model) : base (brand, color, qty){
            this.model = model;
        }
        public string viewComputer(){
            return "Computer : " + this.model + "\n" + properties();  
        }
    }
    class Laptop : Electronics{
        string model;
        public Laptop(string brand, string color, int qty,string model) : base (brand, color, qty){
            this.model = model;
        }
        public string viewLaptop(){
            return "Laptop : " + this.model + "\n" + properties();  
        }
    }
    class SmartPhone : Electronics{
        string model;
        public SmartPhone(string brand, string color, int qty,string model) : base (brand, color, qty){
            this.model = model;
        }
        public string viewSmartPhone(){
            return "SmartPhone : " + this.model + "\n" + properties();  
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer("hp", "silver" , 6 , "HP Envy 14-eb0021TX");;
            Laptop laptop = new Laptop("hp", "silver" , 6 , "HP Envy 14-eb0021TX");
            SmartPhone smartPhone  = new SmartPhone("Samsung" , "black", 12 , "a52");
            computer.viewComputer();
            laptop.viewLaptop();
            smartPhone.viewSmartPhone();
        }
    }
}
