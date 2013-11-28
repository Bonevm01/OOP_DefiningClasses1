using System;
//Task 3 - add enumerator
public enum BatteryType
{
   NiMH, LiIon, NiCd
}
//Task 1 - define Class
class Battery
{
    private string model;
    private BatteryType? batType;
    private double? hoursIdle;
    private double? hoursTalk;

    //Task 2 - Constructors
    public Battery() : this(null)
    {
    }
    public Battery(BatteryType? batType) : this(null, batType)
    {
    }
    public Battery(string model, BatteryType? batType) : this (model, batType, null)
    {
    }
    public Battery(string model, BatteryType? batType, double? hoursIdle)
        : this(model, batType, hoursIdle, null)
    {
    }

    public Battery(string model, BatteryType? batType, double? hoursIdle, double? hoursTalk)
    {
        this.model = model;
        this.batType = batType;
        this.hoursIdle = hoursIdle;
        this.hoursTalk = hoursTalk;
    }

    //Task 5 - Use properties to encapsulate the data fields 
    public string Model
    {
        get {return this.model ;}
        set 
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Battery model cannot be empty!");
            }
            if (value.Length < 2)
            {
                throw new ArgumentException("Battery model too short! It should be at least 2 letters");
            }
            if (value.Length >= 50)
            {
                throw new ArgumentException("Battery model too long! It should be less than 50 letters");
            }
            foreach (var sign in value)
            {
                if (!IsAllowedsign(sign))
                {
                    throw new ArgumentException("The name of the battery model is not valid. Please use only letters, numbers, space, \"/\" and \"-\".");
                }
            }
            this.model = value ;
        }
    }

    private bool IsAllowedsign(char sign)
    {
        bool isAllowed = char.IsLetterOrDigit(sign) || sign == ' ' || sign == '/' || sign == '-';
        return isAllowed;
    }

    public double? HoursIdle
    {
        get { return this.hoursIdle;}
        set 
        {
            if (value<24) //My choice
            {
                throw new ArgumentOutOfRangeException("HoursIdle  can't be less than 24.");
            }
            if (value>300) //My choice
            {
                throw new ArgumentOutOfRangeException("HoursIdle can't be more than 300.");
            }
            this.hoursIdle = value;
        }
    }

    public double? HoursTalk
    {
        get {return this.hoursTalk ;}
        set 
        {
            if (value < 8) //My choice
            {
                throw new ArgumentOutOfRangeException("Hours talk  can't be less than 8.");
            }
            if (value > 18) //My choice
            {
                throw new ArgumentOutOfRangeException("Hours talk can't be more than 18.");
            }
            this.hoursTalk = value;
        }
    }

    public BatteryType? BatType
    {
        get { return this.batType;}
        set {this.batType = value ;}
    }
}
