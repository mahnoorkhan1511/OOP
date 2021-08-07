using System;
using System.Collections.Generic;
using System.IO;
namespace Appointment_Diary
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int opt = 0;
            while(opt != 3){
                opt = mainMenu();
                
                //for doctor
                if( opt == 1 ){
                    Console.Clear();
                    Console.WriteLine("Verify your self!" + "\n" + "Enter pin:");
                    int pin = int.Parse(Console.ReadLine());
                    bool okay = verification(pin,1010);
                    if(okay){
                        int option = 0;
                        while (option != 7 ){
                            option = docMenu();
                            if(option == 1){
                                viewAppointments();
                                Console.WriteLine("Enter any key ..");
                                Console.ReadKey();
                            }
                            else if(option == 2){
                                createAppointment();
                                Console.WriteLine("Enter any key ..");
                                Console.ReadKey();
                            }
                            else if(option == 3){
                                Console.Clear();
                                Console.WriteLine(" APPOINTMENT CANCELLATION ");
                                Console.WriteLine("__________________________");
                                Console.Write("\n");
                                Console.WriteLine("Enter date of appointment : ");
                                Console.Write("Date : ");
                                int date = int.Parse(Console.ReadLine());
                                Console.Write("Month : ");
                                int month = int.Parse(Console.ReadLine());
                                Console.Write("Year : ");
                                int year = int.Parse(Console.ReadLine());
                                string Date = date + "/" + month + "/" + year;
                                cancelAppointment(Date);
                                Console.WriteLine("Enter any key ..");
                                Console.ReadKey();

                            }
                            else if( option == 4){
                                Console.Clear();
                                Console.WriteLine("  Enter Money ");
                                Console.WriteLine("________________");
                                Console.Write("\n");
                                Console.WriteLine("Enter date for which you want to enter in the money ");
                                Console.Write("Date : ");
                                int date = int.Parse(Console.ReadLine());
                                Console.Write("Month : ");
                                int month = int.Parse(Console.ReadLine());
                                Console.Write("Year : ");
                                int year = int.Parse(Console.ReadLine());
                                string Date = date + "/" + month + "/" + year;
                                bool isValid = verifyExistance(Date);
                                if( isValid == true ){
                                    Console.WriteLine("Enter money earned : ");
                                    int money = int.Parse(Console.ReadLine());
                                    enterMoney(Date,money);
                                    Console.WriteLine("Enter any key ..");
                                    Console.ReadKey();
                                }else{
                                    Console.WriteLine(" The entered date is invalid !");
                                    Console.WriteLine("Enter any key ..");
                                    Console.ReadKey();
                                }
                            }
                            else if(option == 5){
                                sortMoney();
                            }
                        }
                    }
                }
                //for patient
                else if( opt == 2 ){
                    int option = 0;
                    while( option != 5){
                        option = patMenu();
                        if(option == 1){
                            Console.Clear();
                            Console.WriteLine("  APPOINTMENT STATUS  ");
                            Console.WriteLine("______________________");
                            Console.Write("\n");
                            Console.WriteLine("Enter date of your appointment : ");
                            Console.Write("Date : ");
                            int date = int.Parse(Console.ReadLine());
                            Console.Write("Month : ");
                            int month = int.Parse(Console.ReadLine());
                            Console.Write("Year : ");
                            int year = int.Parse(Console.ReadLine());
                            string Date = date + "/" + month + "/" + year;
                            bool isThere = verifyExistance(Date);
                            if( isThere ){
                                Console.WriteLine("Your Appointment is Active !");
                                Console.WriteLine("Enter any key ..");
                                Console.ReadKey();
                            }else{
                                Console.WriteLine("Your appointment has been cancelled !");
                                Console.WriteLine("Enter any key ..");
                                Console.ReadKey();
                            }
                        }
                        else if( option == 2 ){
                            Console.Clear();
                            Console.WriteLine("  TREATMENTS  ");
                            Console.WriteLine("______________");
                            Console.Write("\n");
                            Console.WriteLine(" Name of Treatments ");
                            Console.WriteLine("- Consultation");
                            Console.WriteLine("- Scalling");
                            Console.WriteLine("- Extraction");
                            Console.WriteLine("- Orthodontic Treatment");
                            Console.WriteLine("- Root Canal");
                            Console.WriteLine("- Dentures");
                            Console.WriteLine("Enter any key ..");
                            Console.ReadKey();
                        }
                        else if( option == 3 ){
                            Console.Clear();
                            createAppointment();
                            Console.WriteLine("Enter any key ..");
                            Console.ReadKey();
                        }
                        else if( option == 4 ){
                            Console.Clear();
                            Console.WriteLine(" APPOINTMENT CANCELLATION ");
                            Console.WriteLine("__________________________");
                            Console.Write("\n");
                            Console.WriteLine("Enter date of appointment : ");
                            Console.Write("Date : ");
                            int date = int.Parse(Console.ReadLine());
                            Console.Write("Month : ");
                            int month = int.Parse(Console.ReadLine());
                            Console.Write("Year : ");
                            int year = int.Parse(Console.ReadLine());
                            string Date = date + "/" + month + "/" + year;
                            cancelAppointment(Date);
                            Console.WriteLine("Enter any key ..");
                            Console.ReadKey();
                        }
                    }
                }
            
            
            }
        }
        static int mainMenu(){
            int opt = 0;
            Console.Clear();
            Console.WriteLine("  THE APPOINTMENT DIARY ");
            Console.WriteLine("__________________________");
            Console.Write("\n");
            Console.WriteLine("Select your Identity: ");
            Console.WriteLine("1. Doctor");
            Console.WriteLine("2. Patient");
            Console.WriteLine("3. Exit");
            opt = int.Parse(Console.ReadLine());
            return opt;
        }
        static bool verification(int enteredPin, int truePin){
            if(enteredPin == truePin){
                return true;
            }
            return false;
        }
        static int docMenu(){
            Console.Clear();
            Console.WriteLine("  WELCOME DOCTOR! ");
            Console.WriteLine("____________________");
            Console.Write("\n");
            Console.WriteLine("Select your option :");
            Console.WriteLine("1. View Appointments ");
            Console.WriteLine("2. Create Appointment");
            Console.WriteLine("3. Cancel Appointment");
            Console.WriteLine("4. Today's income ");
            Console.WriteLine("5. Sorted Monthly income");
            Console.WriteLine("6. Go back to main menu");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        static int patMenu(){
            Console.Clear();
            Console.WriteLine("  WELCOME PATIENT! ");
            Console.WriteLine("____________________");
            Console.Write("\n");
            Console.WriteLine("Select your option:");
            Console.WriteLine("1. View your appointment status");
            Console.WriteLine("2. List of Treatments");
            Console.WriteLine("3. Create Appointment");
            Console.WriteLine("4. Cancel Appointment ");
            Console.WriteLine("5. Go back to main menu");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        static void createAppointment(){
            Console.Clear();
            Console.WriteLine("  Create Appointment");
            Console.WriteLine("_______________________");
            Console.Write("\n");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter date/month/year");
            Console.Write("date: ");
            int date = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Month: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            string dates = date.ToString() + "/" +month.ToString() + "/" + year.ToString();
            //add validation
            bool isThere = verifyExistance(dates);
            if(isThere == false){
                //save it
                string[] info = {name+","+dates+","+"0"};
                File.AppendAllLines("E:/oop SUMMER/week 01/Appointment Diary/diary.txt",info); 
                Console.WriteLine("Appointment created!");
            }else{
                Console.WriteLine("Appointment on the entered date already exists! ");
            }
        } 
        static void viewAppointments(){
            Console.Clear();
            Console.WriteLine("  APPOINTMENTS ");
            Console.WriteLine("_________________");
            Console.Write("\n");
            Console.WriteLine("Name" + "\t" + "Date" );
            string[] data;
            data = File.ReadAllLines("E:/oop SUMMER/week 01/Appointment Diary/diary.txt");
            foreach(string line in data){
                Console.WriteLine(getStuff(0,line) + "\t" + getStuff(1,line));
            }
        }
        static void cancelAppointment(string date){
            string[] data ;
            data = File.ReadAllLines("E:/oop SUMMER/week 01/Appointment Diary/diary.txt");
            foreach( string line in data){
                string Date = getStuff(1,line);
                if(date == Date){
                    int idx = Array.IndexOf(data,line);
                    data[idx] = "";
                }
            }
            File.WriteAllLines("E:/oop SUMMER/week 01/Appointment Diary/diary.txt",data);
            Console.WriteLine("The appointment has been cancelled  ");
        } 
        static void enterMoney(string date , int money){
            string[] data;
            data = File.ReadAllLines("E:/oop SUMMER/week 01/Appointment Diary/diary.txt");
            foreach( string line in data){
                string dateInData = getStuff(1,line);
                if( dateInData == date ){
                    string nameInData = getStuff(0,line);
                    string newLine = nameInData + "," + dateInData + "," + money;
                    int index = Array.IndexOf(data, line);
                    data[index] = newLine;
                }
                
            }
            File.WriteAllLines("E:/oop SUMMER/week 01/Appointment Diary/diary.txt",data);
        }
        static void sortMoney(){
            Console.Clear();
            Console.WriteLine(" Sorted Income ");
            Console.WriteLine("________________");
            Console.Write("\n");
            Console.WriteLine(" Date" + "\t" + "Money");
            string[] data;
            data = File.ReadAllLines("E:/oop SUMMER/week 01/Appointment Diary/diary.txt");
            List<int> money = new List<int>();
            List<string> date = new List<string>();
            int idx = 0;
            foreach( string line in data){
                money[idx] = int.Parse(getStuff(2,line));
                date[idx] = getStuff(1,line);
                idx++;
            }   
            int sortingIdx=0;
            List<int> moneyDuplicate = new List<int>();
            List<int> arrayIdx = new List<int>();
            for(int j=0; j<moneyDuplicate.Count ; j++){
           
                int largest=0;
                for(int i=0; idx<moneyDuplicate.Count;idx++){
                    if (moneyDuplicate[i]>largest)
                    {
                        largest=moneyDuplicate[i];
                        sortingIdx=i;
                    }

                }
                arrayIdx[j]=sortingIdx;
            
                moneyDuplicate[sortingIdx]=-1;
            
        }
            display(arrayIdx,money,date);
        }
        static void display(List<int> indexes, List<int> money, List<string> date){
            for(int i = 0; i<money.Count ; i++){
                int y = indexes[i];
                Console.WriteLine(date[y] + "\t" + money[y]);
            }
        }
        static bool verifyExistance(string date){
            string[] data;
            data = File.ReadAllLines("E:/oop SUMMER/week 01/Appointment Diary/diary.txt");
            foreach(string line in data){
                string Date = getStuff(1,line);
                if(date == Date){
                    return true;
                }
            }
            return false;
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
