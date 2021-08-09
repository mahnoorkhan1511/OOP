using System;
using System.Collections.Generic;

namespace appointment_dashi
{
    class Doctor{
        public string name = "";
        public int pin = 0;
        public int moneyEarned = 0;
        public List<Treatments> treatments = new List<Treatments>();
        public List<Patient> patRecord = new List<Patient>();
        public Doctor(string name, int pin ){
            this.name = name;
            this.pin = pin;
        }
        public bool treatmentIs(string name){
            for(int i = 0; i<treatments.Count ; i++){
                if( treatments[i].name == name ){
                    return true;
                }
            }
            return false;
        }
        public bool patCheck(string date){
            for( int i = 0; i< patRecord.Count ; i++){
                if( patRecord[i].date == date ){
                    return true;
                }
            }
            return false;
        }
        public void addTreatment(string name, int charges){
            Treatments t = new Treatments(name,charges);
            treatments.Add(t);
        }
        public void addPatient(string name, string date, string treatment, int moneyPayable){
            Patient p = new Patient(name,date,treatment,moneyPayable);
            patRecord.Add(p);
        }
        public void addMoney(int money ){
            this.moneyEarned = this.moneyEarned + money;
        }
        public void viewAppointments(){
            Console.WriteLine("Name" + "\t" + "Date" + "\t" + "Treatment" + "Money");
            for( int i = 0 ; i < patRecord.Count ; i++){
                Console.WriteLine(patRecord[i].name + "\t" + patRecord[i].date + "\t" + patRecord[i].treatment + "\t" + patRecord[i].moneyPayable);
            }
        }
        public void viewTreatments(){
            Console.WriteLine("sr." +"\t" + "Name" + "\t" + "Payment");
            for(int i =0; i < treatments.Count ; i++){
                Console.WriteLine(i + "\t" + treatments[i].name + "\t" + treatments[i].charges);
            }
        }
    }
    class Patient{
        public string name;
        public string date;
        public string treatment;
        public int moneyPayable;
        public Patient(string name, string date, string treatment, int moneyPayable){
            this.name = name;
            this.date = date;
            this.treatment = treatment;
            this.moneyPayable = moneyPayable;
        }
    }
    class Treatments{
        public string name;
        public int charges;
        public Treatments(string name, int charges){
            this.name = name;
            this.charges = charges;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Doctor doc = new Doctor("xyz", 1234);
            Program p = new Program();
            int option = 0;
            while( option != 3 ){
                option = p.mainPage();
                if(option == 1){
                    Console.Clear();
                    Console.WriteLine("Verify your self by entering your pin ...");
                    int pin = int.Parse(Console.ReadLine());
                    if( pin == doc.pin){
                        int opt= 0;
                        while( opt == 7){
                            opt = p.docPage();
                            if( opt == 1){
                                Console.Clear();
                                Console.WriteLine("  Appointments ");
                                Console.WriteLine("_________________");
                                Console.Write("\n");
                                doc.viewAppointments(); 
                                Console.WriteLine(" Enter any key to continue..");
                                Console.ReadKey();          
                            }
                            else if( opt == 2 ){
                                Console.Clear();
                                Console.WriteLine("  Create Appointment ");
                                Console.WriteLine("_______________________");
                                Console.Write("\n");
                                Console.WriteLine(" Enter the name of the patient ..");
                                string name = Console.ReadLine();
                                Console.WriteLine(" Enter the date of appointment ..");
                                Console.Write(" Date ..  ");
                                int date = int.Parse(Console.ReadLine());
                                Console.Write(" Month ..  ");
                                int month = int.Parse(Console.ReadLine());
                                Console.Write("Year ..  ");
                                int year = int.Parse(Console.ReadLine());
                                string Date = date + "/" + month + "/" + year;
                                bool ok = doc.patCheck(Date);
                                if( ok == false ){
                                    Console.WriteLine(" Enter treatment : ");
                                    string trt = Console.ReadLine();
                                    int charges = 0;
                                    for ( int i = 0; i < doc.treatments.Count ; i++){
                                        if( trt == doc.treatments[i].name){
                                            charges = doc.treatments[i].charges;
                                            doc.addMoney(charges);
                                        }
                                    }
                                    doc.addPatient(name,Date,trt,charges);
                                }
                                else{
                                    Console.WriteLine(" The entered date is already occupied... ");
                                    Console.WriteLine(" try another date ..");
                                }
                                Console.WriteLine(" Enter any key to continue..");
                                Console.ReadKey();
                            } 
                            else if( opt == 3 ){
                                Console.Clear();
                                Console.WriteLine("  Cancel Appointment ");
                                Console.WriteLine("_______________________");
                                Console.Write("\n");
                                Console.WriteLine("Enter the date of the appointment to be cancelled ..");
                                Console.Write("Date .. ");
                                int date = int.Parse(Console.ReadLine());
                                Console.Write(" Month ..  ");
                                int month = int.Parse(Console.ReadLine());
                                Console.Write("Year ..  ");
                                int year = int.Parse(Console.ReadLine());
                                string Date = date + "/" + month + "/" + year;
                                for ( int i = 0; i < doc.patRecord.Count ; i++){
                                    if( Date == doc.patRecord[i].date){
                                        doc.patRecord[i].name = "";
                                        doc.patRecord[i].date = "";
                                        doc.patRecord[i].treatment = "";
                                        doc.moneyEarned = doc.moneyEarned - doc.patRecord[i].moneyPayable;
                                        doc.patRecord[i].moneyPayable = 0;

                                    }
                                }
                                Console.WriteLine(" Enter any key to continue..");
                                Console.ReadKey();
                            }
                            else if( opt == 4){
                                Console.Clear();
                                Console.WriteLine("  View Treatments ");
                                Console.WriteLine("_______________________");
                                Console.Write("\n");
                                doc.viewTreatments();
                                Console.WriteLine(" Enter any key to continue..");
                                Console.ReadKey();
                            }
                            else if( opt == 5 ){
                                Console.Clear();
                                Console.WriteLine("  Add Treatment ");
                                Console.WriteLine("_______________________");
                                Console.Write("\n");
                                Console.WriteLine(" Enter the name of the treatment ..");
                                string name = Console.ReadLine();
                                bool ok = doc.treatmentIs(name);
                                if( ok == false ){
                                    Console.WriteLine("Enter the price of the entered treatment ..");
                                    int price = int.Parse(Console.ReadLine());
                                    doc.addTreatment(name,price);
                                }
                                else{
                                    Console.WriteLine(" This treatment already exist ... ");
                                }
                                Console.WriteLine(" Enter any key to continue..");
                                Console.ReadKey();
                            }
                            else if( opt == 6){
                                Console.Clear();
                                Console.WriteLine("  Total Earning ");
                                Console.WriteLine("__________________");
                                Console.Write("\n");
                                Console.WriteLine(" The total earning made until now is ..");
                                Console.WriteLine("Rs. {0}",doc.moneyEarned );
                                Console.WriteLine(" Enter any key to continue..");
                                Console.ReadKey();
                            }
                        }
                    }    
                }
                else if( option == 2){
                    int opt = 0;
                    while(opt != 5){
                        opt = p.patPage();
                        if(opt == 1){
                            Console.Clear();
                            Console.WriteLine("  Create Appointment ");
                            Console.WriteLine("_______________________");
                            Console.Write("\n");
                            Console.WriteLine(" Enter the name of the patient ..");
                            string name = Console.ReadLine();
                            Console.WriteLine(" Enter the date of appointment ..");
                            Console.Write(" Date ..  ");
                            int date = int.Parse(Console.ReadLine());
                            Console.Write(" Month ..  ");
                            int month = int.Parse(Console.ReadLine());
                            Console.Write("Year ..  ");
                            int year = int.Parse(Console.ReadLine());
                            string Date = date + "/" + month + "/" + year;
                            bool ok = doc.patCheck(Date);
                            if( ok == false ){
                                Console.WriteLine(" Enter treatment : ");
                                string trt = Console.ReadLine();
                                int charges = 0;
                                for ( int i = 0; i < doc.treatments.Count ; i++){
                                    if( trt == doc.treatments[i].name){
                                        charges = doc.treatments[i].charges;
                                        doc.addMoney(charges);
                                    }
                                }
                                doc.addPatient(name,Date,trt,charges);
                            }
                            else{
                                Console.WriteLine(" The entered date is already occupied... ");
                                Console.WriteLine(" try another date ..");
                            }
                            Console.WriteLine(" Enter any key to continue..");
                            Console.ReadKey();
                        }
                        else if( opt == 2){
                            Console.Clear();
                            Console.WriteLine("  Cancel Appointment ");
                            Console.WriteLine("_______________________");
                            Console.Write("\n");
                            Console.WriteLine("Enter the date of the appointment to be cancelled ..");
                            Console.Write("Date .. ");
                            int date = int.Parse(Console.ReadLine());
                            Console.Write(" Month ..  ");
                            int month = int.Parse(Console.ReadLine());
                            Console.Write("Year ..  ");
                            int year = int.Parse(Console.ReadLine());
                            string Date = date + "/" + month + "/" + year;
                            for ( int i = 0; i < doc.patRecord.Count ; i++){
                                if( Date == doc.patRecord[i].date){
                                    doc.patRecord[i].name = "";
                                    doc.patRecord[i].date = "";
                                    doc.patRecord[i].treatment = "";
                                    doc.moneyEarned = doc.moneyEarned - doc.patRecord[i].moneyPayable;
                                    doc.patRecord[i].moneyPayable = 0;
                                }
                            }
                            Console.WriteLine(" Enter any key to continue..");
                            Console.ReadKey();
                        }
                        else if( opt == 3){
                            Console.Clear();
                            Console.WriteLine("  Appointment Status");
                            Console.WriteLine("_______________________");
                            Console.Write("\n");
                            Console.WriteLine("Enter the date of the appointment ..");
                            Console.Write("Date .. ");
                            int date = int.Parse(Console.ReadLine());
                            Console.Write(" Month ..  ");
                            int month = int.Parse(Console.ReadLine());
                            Console.Write("Year ..  ");
                            int year = int.Parse(Console.ReadLine());
                            string Date = date + "/" + month + "/" + year;
                            bool active = doc.patCheck(Date);
                            if(active){
                                Console.WriteLine(" Your appointment is active !");
                            }
                            else {
                                Console.WriteLine(" Your appointment has been cancelled ..");
                            }
                            Console.WriteLine(" Enter any key to continue..");
                            Console.ReadKey();
                        }
                        else if( opt == 4 ){
                            Console.Clear();
                            Console.WriteLine("  View Treatments ");
                            Console.WriteLine("_______________________");
                            Console.Write("\n");
                            doc.viewTreatments();
                            Console.WriteLine(" Enter any key to continue..");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
        int mainPage(){
            Console.Clear();
            Console.WriteLine("Enter your ID ..");
            Console.WriteLine(" 1. Doctor ");
            Console.WriteLine(" 2. Patient");
            Console.WriteLine(" 3. Exit ");
            int opt = int.Parse(Console.ReadLine());
            return opt;    
        }
        int docPage(){
            Console.Clear();
            Console.WriteLine(" Welcome Doctor ..! ");
            Console.Write("\n");
            Console.WriteLine("Enter your option ..");
            Console.WriteLine(" 1. View appointments ");
            Console.WriteLine(" 2. Create appointment ");
            Console.WriteLine(" 3. Cancel Appointment ");
            Console.WriteLine(" 4. View treatments ");
            Console.WriteLine(" 5. Add treatment ");
            Console.WriteLine(" 6. Total money earned ");
            Console.WriteLine(" 7. exit");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        int patPage(){
            Console.Clear();
            Console.WriteLine(" Welcome Sir/ Ma'am ..!");
            Console.Write("\n");
            Console.WriteLine("Enter your option ..");
            Console.WriteLine(" 1. Create Appointment ");
            Console.WriteLine(" 2. Cancel Appointment ");
            Console.WriteLine(" 3. Appointment Status ");
            Console.WriteLine(" 4. View Treatments ");
            Console.WriteLine(" 5. Exit");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        
    }
}
