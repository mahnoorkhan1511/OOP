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
        public void addTreatment(string name, int charges){
            for(int i = 0; i<treatments.Count ; i++){
                if(treatments[i].name == name){
                   
                }
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
            Console.WriteLine("Hello World!");
        }
    }
}
