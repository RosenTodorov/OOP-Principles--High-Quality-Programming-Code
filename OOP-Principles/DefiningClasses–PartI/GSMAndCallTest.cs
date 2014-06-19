using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses_PartI
{
    class GSMAndCallTest
    {
        public void Main()
        {
            //Create an array of few instances of the GSM class.

            Console.WriteLine("Testing GSM class");
            GSM[] array = new GSM[] { 
                                       new GSM("5S", "Iphone", 1100, "Atanas Valev"),
                                       new GSM("GT-I9100", "Samsung", 680),
                                       new GSM("Xperia Z", "Sony", 880, "Nikolay Georgiev", new Battery(BatteryType.NiMh), new Display(14,16000000)),
                                       new GSM("3G", "Iphone", 300, "Rosen Todorov")
            };

            //Display the information about the GSMs in the array
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString());
            }

            //Display the information about the static property IPhone4S.
            Console.WriteLine("IPhone info");
            Console.WriteLine("Model: " + GSM.iPhone.model);
            Console.WriteLine("Manufacturer: " + GSM.iPhone.manufacturer);
            Console.WriteLine("Price: " + GSM.iPhone.price);
            Console.WriteLine();

            //test the call history functionality of the GSM class.
            Console.WriteLine("Testing call class");

            //Create an instance of the GSM class.
            GSM personalPhone = new GSM("4S", "IPhone", 600, "Rosen Sofroniev", new Battery(BatteryType.LiIon, "IOP456", 500, 250), new Display(640, 14000000));

            //Add few calls.
            personalPhone.AddCallToHistory("088312349", 921);
            personalPhone.AddCallToHistory("088453531", 412);
            personalPhone.AddCallToHistory("*88", 122);

            //Display the information about the calls.
            foreach (var call in personalPhone.CallHistory)
            {
                Console.WriteLine("{0} {1} {2}", call.DateAndTime, call.PhoneNumber, call.Duration);
            }
            
            // Print total costs of calls in history         
            Console.WriteLine("Total Costs: ");         
            Console.WriteLine(personalPhone.CalculateTotalPriceOfCalls(0.37)); 
       
            // Total costs after removing the call with the longes duration       
            Console.WriteLine("New Total Costs :");
            personalPhone.RemoveCallsFromHistoryViaDuration(921);
            Console.WriteLine(personalPhone.CalculateTotalPriceOfCalls(0.37));  
 
            // Print the new call history, after the call is removed      
            Console.WriteLine("New Call History :");
            foreach (var call in personalPhone.CallHistory)         
            {             
                Console.WriteLine("{0} {1} {2}", call.DateAndTime, call.PhoneNumber, call.Duration);          
            }       
            
            // Clearing the call history and printing it(suppose nothing is expected to be printed)       
            personalPhone.ClearCallHistory();
            foreach (var call in personalPhone.CallHistory)   
            {               
                Console.WriteLine("{0} {1} {2}", call.DateAndTime, call.PhoneNumber, call.Duration);      
            }    
        }  
    }
}

		