using System;
using System.Collections.Generic;

class GSMtest
{
    static void Main()
    {
        //GSM Test
        //Task 7 
        Console.WriteLine("Test 1:");
        GSM myGSM = new GSM("Xperia SP", "Sony");
        GSM.PrintGSMCharacteristics(myGSM);

        Console.WriteLine();
        Console.WriteLine("Test 2:");
        myGSM.Price = 330;
        myGSM.Battery.BatType = BatteryType.LiIon;
        myGSM.Battery.HoursTalk = 13;
        myGSM.Battery.Model = "AB/D-F G";
        GSM.PrintGSMCharacteristics(myGSM);

        Console.WriteLine();
        Console.WriteLine("Test 3:");
        myGSM.Display.Size = 4.3;
        myGSM.Display.NumberOfColours = 16000000;
        GSM.PrintGSMCharacteristics(myGSM);

        Console.WriteLine();
        Console.WriteLine("Test 4:");
        GSM doughtersGSM = new GSM("Desire 500", "HTC");
        doughtersGSM.Owner = "Sofi";
        doughtersGSM.Price = 230.5;
        doughtersGSM.Battery.BatType = BatteryType.NiCd;
        doughtersGSM.Battery.Model = "afaf - asfg";
        doughtersGSM.Battery.HoursTalk = 14.5;
        doughtersGSM.Battery.HoursIdle = 240;
        doughtersGSM.Display.Size = 4;
        doughtersGSM.Display.NumberOfColours = 16000000;
        GSM.PrintGSMCharacteristics(doughtersGSM);


        Console.WriteLine();
        Console.WriteLine("Test 5:");
        GSM wifeGSM = new GSM("C7", "Nokia", 350.4, "Zorka");
        wifeGSM.Display = new Display(3.6, 1000000);
        GSM.PrintGSMCharacteristics(wifeGSM);

        GSM fatherGSM = new GSM("100", "Nokia");
        fatherGSM.Battery = new Battery();

        //Task 7 - Create an array of few instances of the GSM class.
        //Display the information about the GSMs in the array.
        //Display the information about the static property IPhone4S.
        Console.WriteLine();
        Console.WriteLine("Print all GSMs from a list:");
        List<GSM> gsmList = new List<GSM> { myGSM, doughtersGSM, wifeGSM, fatherGSM };

        foreach (var item in gsmList)
        {
            GSM.PrintGSMCharacteristics(item);
            Console.WriteLine();
        }

        GSM IPhone = GSM.IPhone4S;
        GSM.PrintGSMCharacteristics(IPhone);


        //Task 12 - GSMCallHistoryTest - I decided to combine GSM Test and GSMCallHistoryTest
        Console.WriteLine();
        Console.WriteLine("Call History Test:");
        GSM testGSM = new GSM("100", "Nokia");
        Call call1 = new Call(DateTime.Now, "14:59", 132, "0888 885 654");
        Call call2 = new Call(DateTime.Now, "15:39", 112, "0888 885 456");
        Call call3 = new Call(DateTime.Now, "16:22", 32, "0888 885 564");
        Call call4 = new Call(DateTime.Now, "17:15", 12, "0888 885 444");
        Call call5 = new Call(DateTime.Now, "18:12", 145, "0888 885 444");

        testGSM.AddNewCalls(call1);
        testGSM.AddNewCalls(call2);
        testGSM.AddNewCalls(call3);
        testGSM.AddNewCalls(call4);
        testGSM.AddNewCalls(call5);


        PrintCallHistory(testGSM);

        Console.WriteLine("GSM {1} {2} - Total cost of calls-->{0:f2}", testGSM.CalculateTotalPrice(0.37),
                    testGSM.Manifacturer, testGSM.Model);

        RemoveLongestCall(testGSM);
        Console.WriteLine();

        Console.WriteLine("After deleting the longest call, total cost is {0:f2}", testGSM.CalculateTotalPrice(0.37));
        Console.WriteLine();
        testGSM.ClearCallList();
        Console.WriteLine("New call history (after clearing the list):");
        PrintCallHistory(testGSM);
    }

    private static void PrintCallHistory(GSM testGSM)
    {
        Console.WriteLine("Call History:");
        if (testGSM.callHistory.Count == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            Console.WriteLine(" Date     Time   Sec.     Dialed Number");
            foreach (var call in testGSM.callHistory)
            {

                Console.WriteLine("{0:d.M.yy}, {1, 4}, {2, 5}, {3, 15}", call.date, call.time, call.duration, call.dialedNumber);
            }
            Console.WriteLine();
        }

    }

    private static void RemoveLongestCall(GSM testGSM)
    {
        uint longestCall = 0;
        int index = 0;
        int longestCallindex = 0;
        foreach (var call in testGSM.callHistory)
        {
            if (longestCall < call.duration)
            {
                longestCall = call.duration;
                longestCallindex = index;
            }
            index++;
        }
        testGSM.RemoveCalls(testGSM.callHistory[longestCallindex]);
    }
}
