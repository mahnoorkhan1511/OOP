using System;
using System.Collections.Generic;

namespace arrayTrue
{
    class Program
    {
        static bool isTrue(List<int> int1, List<int> int2){
            bool isOkay = false;
            for (int i = 0; i<int1.Count-1; i++){
                if ( int1[i]== int2[i+1]){
                    isOkay = true;
                }
            }
            return isOkay;
        }
        static void Main(string[] args)
        {
            List<int> int1 = new List<int>();
            List<int> int2 = new List<int>();
            string word = "";
            int idx = 0;
            Console.WriteLine("Enter the enteries of the first array : ");

            while(word != "ok"){
                int1.Add(int.Parse(Console.ReadLine()))  ;
                Console.WriteLine("Enter 'ok' to stop entering values or enter any other key to continue ..");
                word = Console.ReadLine();
                idx++;
            }
            Console.WriteLine("Enter the enteries for the second array : ");
            for(int i = 0; i<idx ; i++){
                int2.Add(int.Parse(Console.ReadLine()));
            }
            bool isOkay = isTrue(int1,int2);
            if(isOkay == true ){
                Console.WriteLine("True");
            } 
            else{
                Console.WriteLine("False");
            }
        }
    }
}
