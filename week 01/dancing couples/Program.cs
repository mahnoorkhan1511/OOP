using System;

namespace dancing_couples
{
    class Program
    {
        static void Main(string[] args)
        {
            string [,] couples = new string[3,2] ;
            Console.WriteLine("Enter the names of the dancers in the array: ");
            couples = intoArray(couples);
            string[,] resultingCouples = new string[3,2];
            Console.WriteLine("The unaltered Array : " );
            viewArray(couples);
            Console.WriteLine("Enter the gender (in small letters)..");
            string gender = Console.ReadLine();

            resultingCouples = dancers(couples,gender);
            Console.WriteLine("The altered Array :");
            viewArray(resultingCouples);
        }
        static string[,] dancers(string[,] str , string gender){
            
            int y = 0;
            string storage = "";
            if(gender == "male"){
                y = 1;
                for(int i = 0; i < str.GetLength(0)-1; i++){
                    storage = str[i,y];
                    str[i,y] = str[i+1,y];
                    str[i+1,y] = storage;
                }
                return str;
            }else if(gender == "female"){
                y = 0;
                for(int i = 0; i < str.GetLength(0)-1; i++){
                    //if( i != str.GetLength(0)-1){
                        storage = str[i,y];
                        str[i,y] = str[i+1,y];
                        str[i+1,y] = storage;  
                    //}else if(i == str.GetLength(0)-1)
                    
                }
                return str;
            }
            
            return str;
        }
        static void viewArray(string[,] str){
            for(int i = 0; i<str.GetLength(0); i++){
                for(int y = 0; y<str.GetLength(1); y++){
                    Console.Write(str[i,y]+ " ");
                }
                Console.Write("\n");
            }
        }
        static string[,] intoArray(string[,] str){
            for(int x = 0; x<str.GetLength(0); x++){
                for(int y = 0; y<str.GetLength(1);y++){
                    str[x,y] = Console.ReadLine(); 
                }
            }
            return str;
        }
    }
}
