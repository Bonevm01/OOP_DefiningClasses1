using System;
using System.Collections.Generic;
//Task1 - Define Class
class GSM
{
    private string model;
    private string manifacturer;
    private double? price;
    private string owner;
    private Battery battery;
    private Display display;
    //Task 6 - Add a static field and a property IPhone4S 
    private static GSM iPhone4S = new GSM("Iphone4S", "Apple", 600);

    //Task 9 - Add a property CallHistory in the GSM class to hold a list of the performed calls. 
    //Try to use the system class List<Call>.
    public List<Call> callHistory { get; internal set; }


    //Task 2 - constructors
    public GSM(string model, string manifacturer)
        : this(model, manifacturer, null)
    {
    }

    public GSM(string model, string manifacturer, double? price)
        : this(model, manifacturer, price, null)
    {
    }

    public GSM(string model, string manifacturer, double? price, string owner)
    {
        this.model = model;
        this.manifacturer = manifacturer;
        this.price = price;
        this.owner = owner;
        this.battery = new Battery();
        this.display = new Display();
        this.callHistory = new List<Call>(); //Call history can't exist without new GSM
    }


    //Task 5 - Use properties to encapsulate the data fields 
    public string Model
    {
        get { return this.model; } //Model can not be changed after the first initialization
    }

    public string Manifacturer
    {
        get { return this.manifacturer; } //Manifacturer can not be changed after the first initialization
    }

    public double? Price
    {
        get { return this.price; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("The price has to be a positive floating point number.");
            }

            //No max limit
            this.price = value;
        }
    }

    public string Owner
    {
        get { return this.owner; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Owner cannot be empty!");
            }
            if (value.Length < 2)
            {
                throw new ArgumentException("Owner name too short! It should be at least 2 letters");
            }
            if (value.Length >= 30)
            {
                throw new ArgumentException("Owner name model too long! It should be less than 30 letters");
            }
            foreach (var sign in value)
            {
                if (!IsAllowedsign(sign))
                {
                    throw new ArgumentException("The owner name is not valid. Please use only letters, space, and \"-\".");
                }
            }
            this.owner = value;
        }
    }

    public Battery Battery
    {
        get { return this.battery; }
        set { this.battery = value; }
    }

    public Display Display
    {
        get { return this.display; }
        set { this.display = value; }
    }

    //Task 6 - Add a static field and a property IPhone4S 
    public static GSM IPhone4S
    {
        get { return iPhone4S; }
    }

    //Task 4 - Method to pring GSM characteristics
    public static void PrintGSMCharacteristics(GSM phone)
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine(phone);
        Console.WriteLine(new string('-', 30));
    }

    //Task4 - override ToString()
    public override string ToString()
    {

        /* if (this.Battery == null && this.Display == null)
         {
             return string.Format("GSM:\nModel-->{0, 22};\nmanifacturer-->{1, 15};\nprice-->{2,18}EURO;\nowner-->{3,22};\nNo info about battery and display.", this.model, this.manifacturer, this.price, this.owner);
         }

         if (this.Display == null)
         {
             return string.Format("GSM:\nModel-->{0, 22};\nmanifacturer-->{1, 15};\nprice-->{2,18}EURO;\nowner-->{3,22};\nBATTERY:\nhours Idle-->{4, 17};\nhours talk-->{6,17};\nbattery Type-->{5, 15};\nbattery model-->{7, 14};\nDISPLAY: No info about display.", this.model, this.manifacturer, this.price, this.owner, this.Battery.HoursIdle, this.Battery.BatType, this.Battery.HoursTalk, this.Battery.Model);
         }
         if (this.Battery == null)
         {
             return string.Format("GSM:\nModel-->{0, 22};\nmanifacturer-->{1, 15};\nprice-->{2,18}EURO;\nowner-->{3,22};\nBATTERY:\nNo info about the battery.;\nDISPLAY:\ndisplay size-->{4, 13}'';\nnumber of colours-->{5, 10}.", this.model, this.manifacturer, this.price, this.owner, this.Display.Size, this.Display.NumberOfColours);
         }*/

        return string.Format("GSM:\nModel-->{0, 22};\nmanifacturer-->{1, 15};\nprice-->{2,18}EURO;\nowner-->{3,22};\nBATTERY:\nhours Idle-->{4, 17};\nhours talk-->{6,17};\nbattery Type-->{5, 15};\nbattery model-->{9, 14};\nDISPLAY:\ndisplay size-->{7, 13}'';\nnumber of colours-->{8, 10}.", this.model, this.manifacturer, this.price, this.owner, this.Battery.HoursIdle, this.Battery.BatType, this.Battery.HoursTalk, this.Display.Size, this.Display.NumberOfColours, this.Battery.Model);
    }

    private bool IsAllowedsign(char sign)
    {
        bool isAllowed = char.IsLetter(sign) || sign == ' ' || sign == '-';
        return isAllowed;
    }

    //Task 10 - Add methods in the GSM class for adding and deleting calls from the calls history. 
    //Add a method to clear the call history.
    public void AddNewCalls(Call call)
    {

        this.callHistory.Add(call);
    }

    public void RemoveCalls(Call call)
    {
        this.callHistory.Remove(call);
    }

    public void ClearCallList()
    {
        this.callHistory.Clear();
    }

    //Task 11 - Add a method that calculates the total price of the calls in the call history. 
    //Assume the price per minute is fixed and is provided as a parameter.
    public double CalculateTotalPrice(double price)
    {
        double totalPrice = 0;
        foreach (var call in this.callHistory)
        {
            totalPrice += (call.duration / 60.0) * price;
        }
        return totalPrice;
    }
}
