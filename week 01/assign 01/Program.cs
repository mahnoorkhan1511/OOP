using System;

namespace assign_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int minPurchase = 0;
            int maxSell = 0;
            int savedIdx = 0;
            int[] dayPrices = new int[6];

            
            //taking input for the array
            Console.WriteLine("Enter the prices of stock for a week :");
            for(int idx = 0; idx<6 ; idx++){
                int v = int.Parse(Console.ReadLine());
                dayPrices[idx] = v;
            }

            
            //finding the minimum value
            int smallest = 100;
            for(int idx = 0; idx<6 ; idx++){
                minPurchase = dayPrices[idx];
                if(minPurchase < smallest){
                    smallest = minPurchase;
                    //saving the index at which minimum value occurs
                    savedIdx = idx;
                    
                }
            }

            
            //finding maximum values
            int largest=0;
            for(int idx = savedIdx; idx<6; idx++){
                maxSell = dayPrices[idx];
                if(largest < maxSell){
                    largest = maxSell;
                }
            }
            
            
            //calulating the resulting outcome
            int result = 0;
            result = largest - smallest;


            //showing the outcome
            Console.WriteLine("The maximum money earned is :  " +  result);
             
        }
    }
}
