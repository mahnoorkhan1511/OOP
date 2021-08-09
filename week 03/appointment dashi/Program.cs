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
                            }
                            
                        }
                    }    
                }else if( option == 2){
                    int opt = 0;
                    while(opt != 5){
                        opt = p.patPage();
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
